using LoboWorkout.Models;
using LoboWorkout.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoboWorkout.Shared
{
    internal static class SpartacusConstants
    {
        private static TimeSpan exerciseDuration = TimeSpan.FromSeconds(60);

        public static IExercise Rest = new Exercise("REST", TimeSpan.FromSeconds(15), "Take a breather");

        public static IExercise GobletSquat = new Exercise("Goblet Squat", exerciseDuration, "Take dumbell into two hands and hold it as goblet and do squads");

        public static IExercise MountainClimber = new Exercise("Mountain Climber", exerciseDuration, "Mountain Climber");

        public static IExercise SingleArmDumbellSwing = new Exercise("Single Arm Dumbell Swing", exerciseDuration, "Single Arm Dumbell Swing");

        public static IExercise TPushUp = new Exercise("T Push Up", exerciseDuration, "T Push Up");

        public static IExercise DumbellRow = new Exercise("Dumbell Row", exerciseDuration, "Dumbell Row");

        public static IExercise SideLunge = new Exercise("Side Lunge", exerciseDuration, "Side lunge");

        public static IExercise PushUpRow = new Exercise("Psuh Up Row", exerciseDuration, "Push up row");

        public static IExercise LungeAndRotate = new Exercise("Lunge and Rorate", exerciseDuration, "Lunge and Rorate");

        public static IExercise PressUp = new Exercise("Press Up", exerciseDuration, "Press Up");

        public static List<IExercise> CreateExercises() => new List<IExercise>
            {
                GobletSquat,
                Rest,

                MountainClimber,
                Rest,

                SingleArmDumbellSwing,
                Rest,

                TPushUp,
                Rest,

                DumbellRow,
                Rest,

                SideLunge,
                Rest,

                PushUpRow,
                Rest,

                LungeAndRotate,
                Rest,

                PressUp
            };
    }
}
