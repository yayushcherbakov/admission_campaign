using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionCampaign.ViewModels.Entrants
{
    public class GetEntrantsByEntryYearViewModel: PaginationViewModel
    {
        public int EntryYear { get; set; }
    }
}
