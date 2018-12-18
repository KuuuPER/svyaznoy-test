using System;

namespace SvyaznoyTestProject.Models
{
    class ElevatorStageChangedEventArgs: EventArgs
    {
        public ElevatorStageChangedEventArgs(byte currentStage, MoveDirections direction)
        {
            this.CurrentStage = currentStage;
            Direction = direction;
        }

        public byte CurrentStage { get; }

        public MoveDirections Direction { get; }
    }
}
