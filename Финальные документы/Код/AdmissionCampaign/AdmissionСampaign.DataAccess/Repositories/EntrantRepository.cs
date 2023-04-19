using AdmissionCampaign.DataAccess.models;
using AdmissionСampaign.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionСampaign.DataAccess.Repositories
{
    public class EntrantRepository
    {
        protected readonly DbSet<Entrant> _dbSet;
        protected readonly ApplicationContext _context;
        private IDbContextTransaction _transaction;
        public EntrantRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<Entrant>();

        }
        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void RollbackTransaction()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

        public void CommitTransaction()
        {
            _transaction.Commit();
            _transaction.Dispose();
        }

        public long AddEntrant(Entrant entrant)
        {
            _dbSet.Add(entrant);
            _context.SaveChanges();

            return entrant.Id;
        }

        public void AddRange(List<Entrant> entrants)
        {
            _dbSet.AddRange(entrants);
            _context.SaveChanges();
        }

        public void UpdateEntrant(Entrant entrant)
        {
            _dbSet.Update(entrant);
            _context.SaveChanges();
        }

        public void RemoveEntrant(Entrant entrant)
        {
            _dbSet.Remove(entrant);
            _context.SaveChanges();
        }

        public Entrant FindEntrantById(long id)
        {
            var entrant = _dbSet.AsQueryable().FirstOrDefault(entrant => entrant.Id == id);
            return entrant;
        }

        public FilteredEntrantsModel GetAllEntrants(PaginationModel paginationModel)
        {
            var query = _dbSet.AsQueryable();
            var retult = new FilteredEntrantsModel()
            {
                Entrants = query.Skip(paginationModel.Skip).Take(paginationModel.Take).ToList(),
                Total = query.Count()
            };
            return retult;
        }
        public void RemoveAllEntrants()
        {
            _dbSet.RemoveRange(_dbSet);
            _context.SaveChanges();
        }

        public FilteredEntrantsModel GetEntrantsByEntryYear(int year, PaginationModel paginationModel)
        {
            var query = _dbSet.AsQueryable();
            query = AddEntryYearFilter(query, year, year);

            var retult = new FilteredEntrantsModel()
            {
                Entrants = query.Skip(paginationModel.Skip).Take(paginationModel.Take).ToList(),
                Total = query.Count()
            };
            return retult;
        }

        public GetStaticticByRegionsModel GetStaticticByRegions(FilterEntrantsModel model, PaginationModel paginationModel)
        {
            var query = _dbSet.AsQueryable();
            query = AddEntryYearFilter(query, model.EntryYear, model.EntryYear);

            if (!string.IsNullOrWhiteSpace(model.EducationProgram))
            {
                query = query.Where(entrant => entrant.EducationProgram == model.EducationProgram);
            }

            var regionStatictic = query.GroupBy(x=>x.RegistrationRegion)
                .Select(g => new RegionStaticticModel { Region = g.Key, Count = g.Count() })
                .OrderByDescending(x=>x.Count);

            var retult = new GetStaticticByRegionsModel()
            {
                RegionStatictic = regionStatictic.Skip(paginationModel.Skip).Take(paginationModel.Take).ToList(),
                Total = regionStatictic.Count()
            };
            return retult;
        }

        public FilteredEntrantsModel FilterEntrants(FilterEntrantsModel model, PaginationModel paginationModel)
        {
            var query = _dbSet.AsQueryable();
            query = AddEntryYearFilter(query, model.EntryYear, model.EntryYear);

            if (!string.IsNullOrWhiteSpace(model.EducationProgram))
            {
                query = query.Where(entrant => entrant.EducationProgram == model.EducationProgram);
            }

            if (!string.IsNullOrWhiteSpace(model.RegistrationRegion))
            {
                query = query.Where(entrant => entrant.RegistrationRegion == model.RegistrationRegion);
            }

            if (!string.IsNullOrWhiteSpace(model.NameSearch))
            {
                query = query.Where(entrant => entrant.FullName.Contains(model.NameSearch));
            }

            if (model.IsDormitoryNeeded is not null)
            {
                query = query.Where(entrant => entrant.IsDormitoryNeeded == model.IsDormitoryNeeded);
            }

            if (model.HasSpecialQuota is not null)
            {
                query = query.Where(entrant => entrant.SpecialQuota == model.HasSpecialQuota);
            }

            if (model.HasTargetQuota is not null)
            {
                query = query.Where(entrant => entrant.TargetQuota == model.HasTargetQuota);
            }

            query = AddDocumentsReturnedFilter(query, model.IsDocumentsReturned);
            query = AddRussianLanguageUSEFilter(query, model.MinRussianLanguageUSE, model.MaxRussianLanguageUSE);
            query = AddMathUSEFilter(query, model.MinMathUSE, model.MaxMathUSE);
            query = AddInformaticsUseFilter(query, model.MinInformaticsUSE, model.MaxInformaticsUSE);
            query = AddTotalUseFilter(query, model.MinTotalUse, model.MaxTotalUse);

            var retult = new FilteredEntrantsModel()
            {
                Entrants = query.Skip(paginationModel.Skip).Take(paginationModel.Take).ToList(),
                Total = query.Count()
            };
            return retult;
        }

        private IQueryable<Entrant> AddDocumentsReturnedFilter(IQueryable<Entrant> query, bool? IsDocumentsReturned)
        {
            if (IsDocumentsReturned is not null)
            {
                query = query.Where(entrant => entrant.DocumentsReturned == IsDocumentsReturned);
            }
            return query;
        }
        private IQueryable<Entrant> AddEntryYearFilter(IQueryable<Entrant> query, int? min, int? max)
        {
            if (min is not null)
            {
                query = query.Where(entrant => entrant.EntryYear >= min);
            }
            if (max is not null)
            {
                query = query.Where(entrant => entrant.EntryYear <= max);
            }
            return query;
        }
        private IQueryable<Entrant> AddRussianLanguageUSEFilter(IQueryable<Entrant> query, int? min, int? max)
        {
            if (min is not null)
            {
                query = query.Where(entrant => entrant.RussianLanguageUSE >= min);
            }
            if (max is not null)
            {
                query = query.Where(entrant => entrant.RussianLanguageUSE <= max);
            }
            return query;
        }
        private IQueryable<Entrant> AddMathUSEFilter(IQueryable<Entrant> query, int? min, int? max)
        {
            if (min is not null)
            {
                query = query.Where(entrant => entrant.MathUSE >= min);
            }
            if (max is not null)
            {
                query = query.Where(entrant => entrant.MathUSE <= max);
            }
            return query;
        }
        private IQueryable<Entrant> AddInformaticsUseFilter(IQueryable<Entrant> query, int? min, int? max)
        {
            if (min is not null)
            {
                query = query.Where(entrant => entrant.InformaticsUSE >= min);
            }
            if (max is not null)
            {
                query = query.Where(entrant => entrant.InformaticsUSE <= max);
            }
            return query;
        }
        private IQueryable<Entrant> AddTotalUseFilter(IQueryable<Entrant> query, int? min, int? max)
        {
            if (min is not null)
            {
                query = query.Where(entrant => entrant.RussianLanguageUSE +
                    entrant.MathUSE + entrant.InformaticsUSE + entrant.IndividualAchievementScore >= min);
            }
            if (max is not null)
            {
                query = query.Where(entrant => entrant.RussianLanguageUSE +
                    entrant.MathUSE + entrant.InformaticsUSE + entrant.IndividualAchievementScore <= max);
            }
            return query;
        }
    }
}
