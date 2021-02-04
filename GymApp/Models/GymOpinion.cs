using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Models
{
    public class GymOpinion
    {
        public int Id { get; set; }

        public string Opinion { get; set; }

        public string AuthorEmail { get; set; }

        public DateTime Created { get; set; }

        public bool IsVisible { get; set; }
    }
}
