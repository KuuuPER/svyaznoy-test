using System;

namespace SvyaznoyTestProject.Models.ElevatorEventArgs
{
    class ElevatorFloorButtonEventArgs: EventArgs
    {
        public ElevatorFloorButtonEventArgs(sbyte floor)
        {
            Floor = floor;
        }

        public ushort Floor { get; }
    }
}
