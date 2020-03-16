using LoboWorkout.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoboWorkout.Models
{
    public class Exercise : IExercise
    {
        public string Title { get; }

        public TimeSpan Duration { get; }

        public string Description { get; }

        public Exercise(string title, TimeSpan duration, string description)
        {
            Title = title;
            Duration = duration;
            Description = description;
        }

    }
}
