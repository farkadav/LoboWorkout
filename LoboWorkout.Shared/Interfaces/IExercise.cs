using System;
using System.Collections.Generic;
using System.Text;

namespace LoboWorkout.Shared.Interfaces
{
    public interface IExercise
    {
        string Title { get; }

        TimeSpan Duration { get; }

        string Description { get; }
    }
}
