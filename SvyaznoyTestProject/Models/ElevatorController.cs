using System;
using System.Collections.Generic;
using System.Text;

namespace SvyaznoyTestProject.Models.Buttons
{
    class ElevatorController
    {
        public event EventHandler ElevatorStarted;

        public event EventHandler ElevatorArrived;
    }
}
