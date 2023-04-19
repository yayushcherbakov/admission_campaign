using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionCampaign.ViewModels.Entrants
{
    public class FilterEntrantsViewModel: PaginationViewModel
    {
        public int? EntryYear { get; set; }
        public string EducationProgram { get; set; }
        public string NameSearch { get; set; }
        public string RegistrationRegion { get; set; }
        public bool? IsDormitoryNeeded { get; set; }
        public bool? HasTargetQuota { get; set; }
        public bool? HasSpecialQuota { get; set; }
        public bool? IsDocumentsReturned { get; set; }
        public int? MinTotalUse { get; set; }
        public int? MaxTotalUse { get; set; }
        public int? MinRussianLanguageUSE { get; set; }
        public int? MaxRussianLanguageUSE { get; set; }
        public int? MinInformaticsUSE { get; set; }
        public int? MaxInformaticsUSE { get; set; }
        public int? MinMathUSE { get; set; }
        public int? MaxMathUSE { get; set; }
    }
}
