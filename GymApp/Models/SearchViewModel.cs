using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Models
{
    public class SearchViewModel
    {
        public string Search { get; set; }

        public List<GymViewModel> Gyms { get; set; }
    }
}
