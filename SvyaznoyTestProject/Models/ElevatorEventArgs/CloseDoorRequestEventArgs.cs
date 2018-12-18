using System;

namespace SvyaznoyTestProject.Models
{
    class CloseDoorRequestEventArgs: EventArgs
    {
        public CloseDoorRequestEventArgs(ushort currentWeight, ushort maxWeight)
        {
            CurrentWeight = currentWeight;
            MaxWeight = maxWeight;
        }

        public ushort CurrentWeight { get; }

        public ushort MaxWeight { get; }
    }
}
