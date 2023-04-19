using AdmissionCampaign.ViewModels.Entrants;
using AdmissionСampaign.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionCampaign.Services.Mappers
{
    public static class EntrantMapper
    {
        public static void MapEntrantViewModelToEntity(AddEntrantViewModel model, Entrant entrant)
        {
            entrant.EntryYear = model.EntryYear;
            entrant.EducationProgram = model.EducationProgram;
            entrant.RegistrationNumber = model.RegistrationNumber;
            entrant.FullName = model.FullName;
            entrant.SNILS = model.SNILS;
            entrant.ApplicationType = model.ApplicationType;
            entrant.WithoutExamsReason = model.WithoutExamsReason;
            entrant.SpecialQuota = model.SpecialQuota;
            entrant.TargetQuota = model.TargetQuota;
            entrant.InformaticsUSE = model.InformaticsUSE;
            entrant.MathUSE = model.MathUSE;
            entrant.RussianLanguageUSE = model.RussianLanguageUSE;
            entrant.IndividualAchievementScore = model.IndividualAchievementScore;
            entrant.EducationForm = model.EducationForm;
            entrant.PreemptiveRight = model.PreemptiveRight;
            entrant.IsDormitoryNeeded = model.IsDormitoryNeeded;
            entrant.DocumentsReturned = model.DocumentsReturned;
            entrant.Specialization = model.Specialization;
            entrant.EducationCompetitions = model.EducationCompetitions;
            entrant.RegistrationRegion = model.RegistrationRegion;
        }

        public static EntrantView MapEntrantEntityToView(Entrant entrant)
        {
            var entrantView = new EntrantView();

            entrantView.Id = entrant.Id;
            entrantView.EntryYear = entrant.EntryYear;
            entrantView.EducationProgram = entrant.EducationProgram;
            entrantView.RegistrationNumber = entrant.RegistrationNumber;
            entrantView.FullName = entrant.FullName;
            entrantView.SNILS = entrant.SNILS;
            entrantView.ApplicationType = entrant.ApplicationType;
            entrantView.WithoutExamsReason = entrant.WithoutExamsReason;
            entrantView.SpecialQuota = entrant.SpecialQuota;
            entrantView.TargetQuota = entrant.TargetQuota;
            entrantView.InformaticsUSE = entrant.InformaticsUSE;
            entrantView.MathUSE = entrant.MathUSE;
            entrantView.RussianLanguageUSE = entrant.RussianLanguageUSE;
            entrantView.IndividualAchievementScore = entrant.IndividualAchievementScore;

            int CompetitionPointsSum = entrantView.InformaticsUSE + entrantView.MathUSE +
                entrantView.RussianLanguageUSE + entrantView.IndividualAchievementScore;

            entrantView.CompetitionPoints = CompetitionPointsSum;
            entrantView.EducationForm = entrant.EducationForm;
            entrantView.PreemptiveRight = entrant.PreemptiveRight;
            entrantView.IsDormitoryNeeded = entrant.IsDormitoryNeeded;
            entrantView.DocumentsReturned = entrant.DocumentsReturned;
            entrantView.Specialization = entrant.Specialization;
            entrantView.EducationCompetitions = entrant.EducationCompetitions;
            entrantView.RegistrationRegion = entrant.RegistrationRegion;

            return entrantView;
        }
    }
}
