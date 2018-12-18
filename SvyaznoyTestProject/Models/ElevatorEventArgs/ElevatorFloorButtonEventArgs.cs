using System;

namespace SvyaznoyTestProject.Models
{
    class ElevatorFloorButtonEventArgs: EventArgs
    {
        public ElevatorFloorButtonEventArgs(sbyte floor)
        {
            Floor = floor;
        }

        public sbyte Floor { get; }
    }
}
