using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionCampaign.ViewModels.Entrants
{
    public class GetStaticticByRegionsView
    {
        public List<RegionStaticticView> RegionStatictic { get; set; }
        public int Total { get; set; }
    }
}
