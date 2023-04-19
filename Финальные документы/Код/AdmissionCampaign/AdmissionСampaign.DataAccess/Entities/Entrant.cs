using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionСampaign.DataAccess.Entities
{
    public class Entrant
    {
        public long Id { get; set; }

        public int EntryYear { get; set; }

        public string EducationProgram { get; set; }

        public int RegistrationNumber { get; set; }

        public string FullName { get; set; }

        public string SNILS { get; set; }

        public string ApplicationType { get; set; }

        public string WithoutExamsReason { get; set; }

        public bool SpecialQuota { get; set; }

        public bool TargetQuota { get; set; }

        public int InformaticsUSE { get; set; }

        public int MathUSE { get; set; }

        public int RussianLanguageUSE { get; set; }

        public int IndividualAchievementScore { get; set; }

        public string EducationForm { get; set; }

        public string PreemptiveRight { get; set; }

        public bool IsDormitoryNeeded { get; set; }

        public bool DocumentsReturned { get; set; }

        public string Specialization { get; set; }

        public string EducationCompetitions { get; set; }

        public string RegistrationRegion { get; set; }
    }
}
