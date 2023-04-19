using AdmissionCampaign.DataAccess.models;
using AdmissionCampaign.Services.Helpers;
using AdmissionCampaign.Services.Mappers;
using AdmissionCampaign.ViewModels.Entrants;
using AdmissionСampaign.DataAccess.Entities;
using AdmissionСampaign.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionСampaign.Services.Services
{
    public class EntrantService
    {
        private readonly EntrantRepository _entrantRepository;

        public EntrantService(EntrantRepository entrantRepository)
        {
            _entrantRepository = entrantRepository;
        }


        public long AddEntrant(AddEntrantViewModel entrant)
        {
            var newEntrant = new Entrant();
            EntrantMapper.MapEntrantViewModelToEntity(entrant, newEntrant);
            return _entrantRepository.AddEntrant(newEntrant);
        }

        public void RemoveAllEntrants()
        {
            _entrantRepository.RemoveAllEntrants();
        }

        public void UpdateEntrant(UpdateEntrantViewModel model)
        {
            var entrant = _entrantRepository.FindEntrantById(model.Id);
            if (entrant is null)
            {
                throw new ApplicationException("Entrant not found");
            }

            EntrantMapper.MapEntrantViewModelToEntity(model, entrant);
            _entrantRepository.UpdateEntrant(entrant);
        }

        public void RemoveEntrant(long id)
        {
            var entrant = _entrantRepository.FindEntrantById(id);
            if (entrant is null)
            {
                throw new ApplicationException("Entrant not found");
            }

            _entrantRepository.RemoveEntrant(entrant);
        }

        public EntrantView FindEntrantById(long id)
        {
            var entrant = _entrantRepository.FindEntrantById(id);
            return EntrantMapper.MapEntrantEntityToView(entrant);
        }

        public FiltredEntrantsView GetAllEntrants(PaginationViewModel request)
        {
            var model = GetPaginationModel(request);
            var entrantsResult = _entrantRepository.GetAllEntrants(model);
            var responseModel = new FiltredEntrantsView()
            {
                Entrants = entrantsResult.Entrants.Select(x => EntrantMapper.MapEntrantEntityToView(x)).ToList(),
                Total = entrantsResult.Total
            };
            return responseModel;
        }

        private PaginationModel GetPaginationModel(PaginationViewModel request)
        {
            var paginationModel = new PaginationModel()
            {
                Skip = request.Page < 2 ? 0 : (request.Page - 1) * request.ItemsPerPage,
                Take = request.ItemsPerPage,
            };

            return paginationModel;
        }

        public FiltredEntrantsView GetEntrantsByEntryYear(GetEntrantsByEntryYearViewModel request)
        {
            var paginationModel = GetPaginationModel(request);
            var entrantsResult = _entrantRepository.GetEntrantsByEntryYear(request.EntryYear, paginationModel);
            var responseModel = new FiltredEntrantsView()
            {
                Entrants = entrantsResult.Entrants.Select(x => EntrantMapper.MapEntrantEntityToView(x)).ToList(),
                Total = entrantsResult.Total
            };
            return responseModel;
        }

        public FiltredEntrantsView FilterEntrants(FilterEntrantsViewModel request)
        {
            var filter = new FilterEntrantsModel()
            {
                EntryYear = request.EntryYear,
                EducationProgram = request.EducationProgram,
                NameSearch = request.NameSearch,
                RegistrationRegion = request.RegistrationRegion,
                IsDormitoryNeeded = request.IsDormitoryNeeded,
                MinTotalUse = request.MinTotalUse,
                MaxTotalUse = request.MaxTotalUse,
                MinRussianLanguageUSE = request.MinRussianLanguageUSE,
                MaxRussianLanguageUSE = request.MaxRussianLanguageUSE,
                MinMathUSE = request.MinMathUSE,
                MaxMathUSE = request.MaxMathUSE,
                MinInformaticsUSE = request.MinInformaticsUSE,
                MaxInformaticsUSE = request.MaxInformaticsUSE,
                HasSpecialQuota = request.HasSpecialQuota,
                HasTargetQuota = request.HasTargetQuota,
                IsDocumentsReturned = request.IsDocumentsReturned
            };
            var paginationModel = GetPaginationModel(request);
            var entrantsResult = _entrantRepository.FilterEntrants(filter, paginationModel);
            var responseModel = new FiltredEntrantsView()
            {
                Entrants = entrantsResult.Entrants.Select(x => EntrantMapper.MapEntrantEntityToView(x)).ToList(),
                Total = entrantsResult.Total
            };
            return responseModel;
        }

        public GetStaticticByRegionsView GetStaticticByRegions(GetStaticticByRegionsViewModel request)
        {
            var filter = new FilterEntrantsModel()
            {
                EntryYear = request.EntryYear,
                EducationProgram = request.EducationProgram
            };
            var paginationModel = GetPaginationModel(request);
            var statisticResult = _entrantRepository.GetStaticticByRegions(filter, paginationModel);

            var responseModel = new GetStaticticByRegionsView()
            {
                RegionStatictic = statisticResult.RegionStatictic.Select(x => new RegionStaticticView()
                {
                    Region = x.Region,
                    Count = x.Count
                }).ToList(),
                Total = statisticResult.Total
            };
            return responseModel;
        }

        public void UploadDocument(int entryYear, string educationProgram, Stream fileStream)
        {
            var entrants = new List<Entrant>();

            using (var reader = new StreamReader(fileStream))
            {
                // Skip first row with headers
                string line = reader.ReadLine();
                var lineNumber = 1;
                while ((line = reader.ReadLine()) != null)
                {
                    ++lineNumber;
                    try
                    {
                        var entrant = ParseEntrantFromCsv(line);
                        entrant.EntryYear = entryYear;
                        entrant.EducationProgram = educationProgram;
                        entrants.Add(entrant);
                    }
                    catch (Exception)
                    {
                        throw new ApplicationException($"Parse error in {lineNumber} ");
                    }
                }
            }

            _entrantRepository.AddRange(entrants);
        }

        private Entrant ParseEntrantFromCsv(string entrantString)
        {
            var entrantFields = CsvParser.Parse(entrantString);
            var result = new Entrant();

            result.RegistrationNumber = ParseStringToInt(entrantFields[1]);
            result.FullName = entrantFields[2];
            result.SNILS = entrantFields[3];
            result.ApplicationType = entrantFields[4];
            result.WithoutExamsReason = entrantFields[5];
            result.SpecialQuota = ParseStringToBool(entrantFields[6]);
            result.TargetQuota = ParseStringToBool(entrantFields[7]);
            result.InformaticsUSE = ParseStringToInt(entrantFields[8]);
            result.MathUSE = ParseStringToInt(entrantFields[9]);
            result.RussianLanguageUSE = ParseStringToInt(entrantFields[10]);
            result.IndividualAchievementScore = ParseStringToInt(entrantFields[11]);
            result.EducationForm = entrantFields[13];
            result.PreemptiveRight = entrantFields[14];
            result.IsDormitoryNeeded = ParseStringToBool(entrantFields[15]);
            result.DocumentsReturned = ParseStringToBool(entrantFields[16]);
            result.Specialization = entrantFields[17];
            result.EducationCompetitions = entrantFields[18];
            result.RegistrationRegion = entrantFields.Count > 19 ? entrantFields[19] : string.Empty;

            return result;
        }

        private int ParseStringToInt(string input)
        {
            if (int.TryParse(input, out int result))
            {
                return result;
            }

            return 0;
        }

        private bool ParseStringToBool(string input)
        {
            return input.Trim() == "+";
        }
    }
}
