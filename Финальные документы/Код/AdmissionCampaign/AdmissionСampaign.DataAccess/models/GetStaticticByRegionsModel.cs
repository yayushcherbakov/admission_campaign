using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionCampaign.DataAccess.models
{
    public class GetStaticticByRegionsModel
    {
        public List<RegionStaticticModel> RegionStatictic { get; set; }
        public int Total { get; set; }
    }
}
