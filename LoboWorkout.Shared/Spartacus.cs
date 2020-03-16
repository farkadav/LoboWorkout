using LoboWorkout.Shared.Interfaces;
using System;
using System.Collections.Generic;
using static LoboWorkout.Shared.SpartacusConstants;

namespace LoboWorkout.Shared
{
    public class Spartacus : IWorkout
    {
        public string Title { get; }

        public string Description { get; }

        public IEnumerable<IExercise> Exercises { get; }

        public int Rounds { get; }

        public TimeSpan RestAfterRound { get; }


        public Spartacus()
        {
            Title = "Spartacus";
            Description = "Scott Herman's Spartacus Workout";
            Exercises = CreateExercises();
            Rounds = 3;
            RestAfterRound = TimeSpan.FromMinutes(2);
        }
    }
}
