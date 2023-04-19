using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionCampaign.ViewModels.Entrants
{
    public class PaginationViewModel
    {
        public int Page { get; set; } = 1;
        public int ItemsPerPage { get; set; } = 12;
    }
}
