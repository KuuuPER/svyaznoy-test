using SvyaznoyTestProject.Models.Buttons;
using System;
using System.Collections.Generic;
using System.Text;

namespace SvyaznoyTestProject.Models.ElevatorEventArgs
{
    class ElevatorCallEventArgs: EventArgs
    {
        public ElevatorCallEventArgs(ushort floorNum, ElevatorCallDirections direction)
        {
            FloorNum = floorNum;
            Direction = direction;
        }

        public ushort FloorNum { get; }

        public ElevatorCallDirections Direction { get; }
    }
}
