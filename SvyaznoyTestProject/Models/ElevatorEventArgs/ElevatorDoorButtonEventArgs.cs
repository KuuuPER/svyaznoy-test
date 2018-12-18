using SvyaznoyTestProject.Models.Buttons;
using System;

namespace SvyaznoyTestProject.Models
{
    class ElevatorDoorButtonEventArgs: EventArgs
    {
        public ElevatorDoorButtonEventArgs(ElevatorDoorButtonTypes buttonType)
        {
            ButtonType = buttonType;
        }

        public ElevatorDoorButtonTypes ButtonType { get; }
    }
}
