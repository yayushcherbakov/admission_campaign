using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionCampaign.ViewModels.Entrants
{
    public class FiltredEntrantsView
    {
        public List<EntrantView> Entrants { get; set; }
        public int Total { get; set; }
    }
}
