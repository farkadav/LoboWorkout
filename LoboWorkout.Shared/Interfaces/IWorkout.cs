using System;
using System.Collections.Generic;
using System.Text;

namespace LoboWorkout.Shared.Interfaces
{
    public interface IWorkout
    {
        string Title { get; }
        string Description { get; }

        int Rounds { get; }

        TimeSpan RestAfterRound { get; }

        IEnumerable<IExercise> Exercises { get; }
    }
}
