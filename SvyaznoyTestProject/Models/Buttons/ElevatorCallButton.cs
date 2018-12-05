using System;
using System.Collections.Generic;
using System.Text;

namespace SvyaznoyTestProject.Models.Buttons
{
    class ElevatorCallButton : BaseButton
    {
        public ElevatorCallButton(ElevatorCallDirections direction)
        {
            Direction = direction;
        }

        public ElevatorCallDirections Direction { get; private set; }
    }
}
