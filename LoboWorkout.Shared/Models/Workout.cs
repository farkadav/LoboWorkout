using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoboWorkout.Models
{
    public class Workout
    {
        public string Description { get; set; }

        public int Rounds { get; set; }

        public TimeSpan RestAfterRound { get; set; }

        public List<Exercise> Exercies { get; set; }

    }
}
