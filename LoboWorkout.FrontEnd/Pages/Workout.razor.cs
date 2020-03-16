using LoboWorkout.FrontEnd.Models.Enums;
using LoboWorkout.Shared;
using LoboWorkout.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LoboWorkout.FrontEnd.Pages
{
    public partial class Workout
    {
        private WorkoutState workoutState;

        private CancellationTokenSource workoutCancellationTokenSource;

        private IWorkout workout;

        private int round = 0;

        private string currentExercise = string.Empty;
        private int timeLeftSeconds = 0;
        private string exerciseDescription = string.Empty;

        protected override Task OnInitializedAsync()
        {
            workout = new Spartacus();
            workoutState = WorkoutState.NotStarted;
            return Task.CompletedTask;
        }


        private async Task StartAsync()
        {
            workoutState = WorkoutState.Started;
            workoutCancellationTokenSource = new CancellationTokenSource();
            IEnumerable<IExercise> exercises = workout.Exercises;

            round = workout.Rounds;

            await using Timer timer = new Timer(OnTimerElapsed, null, 0, 1000);

            while (round > 0)
            {
                if (workoutCancellationTokenSource.IsCancellationRequested)
                {
                    break;
                }

                foreach (IExercise exercise in exercises)
                {
                    SetExerciseInfo(exercise);
                    await Task.Delay(exercise.Duration, workoutCancellationTokenSource.Token);
                }

                await Task.Delay(workout.RestAfterRound, workoutCancellationTokenSource.Token);

                round--;
            }

            RestoreDefaults();
            workoutState = WorkoutState.Finished;
        }

        private void OnTimerElapsed(object _)
        {
            if (workoutCancellationTokenSource.IsCancellationRequested)
            {
                RestoreDefaults();
            }

            if (workoutState == WorkoutState.Paused)
            {
                return;
            }

            if (timeLeftSeconds > 0)
            {
                timeLeftSeconds--;
                InvokeAsync(StateHasChanged);
            }  
        }

        private void SetExerciseInfo(IExercise exercise)
        {
            currentExercise = exercise.Title;
            timeLeftSeconds = (int)exercise.Duration.TotalSeconds;
            exerciseDescription = exercise.Description;
        }

        private void RestoreDefaults()
        {
            currentExercise = string.Empty;
            timeLeftSeconds = 0;
            exerciseDescription = string.Empty;
            round = 0;
        }

        private async Task StopAsync()
        {
            workoutCancellationTokenSource?.Cancel();
            workoutState = WorkoutState.NotStarted;
        }

        private async Task PauseAsync()
        {
            workoutState = WorkoutState.Paused;
        }

        private async Task ResumeAsync()
        {
            workoutState = WorkoutState.Started;
        }

    }
}
