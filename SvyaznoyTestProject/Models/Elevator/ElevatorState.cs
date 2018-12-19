namespace SvyaznoyTestProject.Models
{
    struct ElevatorState
    {
        public ElevatorState(byte currentStage, ElevatorStatuses status, DoorsStates doorsState)
        {
            CurrentStage = currentStage;
            Status = status;
            DoorsState = doorsState;
        }

        public byte CurrentStage { get; }

        public ElevatorStatuses Status { get; }

        public DoorsStates DoorsState { get; }
    }
}
