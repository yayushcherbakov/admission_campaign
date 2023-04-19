using AdmissionСampaign.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionCampaign.DataAccess.models
{
    public class FilteredEntrantsModel
    {
        public List<Entrant> Entrants { get; set; }
        public int Total { get; set; }
    }
}
