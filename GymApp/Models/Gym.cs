using System.Collections.Generic;

namespace GymApp.Models
{
    public class Gym
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Website { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public bool IsActive { get; set; }

        public ICollection<GymOpinion> Opinions { get; set; }

        public Gym()
        {
            Opinions = new List<GymOpinion>();
        }
    }
}
