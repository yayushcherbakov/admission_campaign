using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionCampaign.DataAccess.models
{
    public class PaginationModel
    {
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 12;
    }
}
