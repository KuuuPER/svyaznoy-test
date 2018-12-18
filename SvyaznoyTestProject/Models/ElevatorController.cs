using System;

namespace SvyaznoyTestProject.Models.Buttons
{
    class ElevatorController
    {
        public event EventHandler ElevatorStarted;

        public event EventHandler ElevatorArrived;
    }
}
