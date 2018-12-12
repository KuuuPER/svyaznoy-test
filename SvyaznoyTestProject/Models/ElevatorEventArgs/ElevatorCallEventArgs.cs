using SvyaznoyTestProject.Models.Buttons;
using System;

namespace SvyaznoyTestProject.Models
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
