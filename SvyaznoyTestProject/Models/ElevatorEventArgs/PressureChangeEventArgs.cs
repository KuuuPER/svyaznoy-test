using System;

namespace SvyaznoyTestProject.Models
{
    class PressureChangeEventArgs : EventArgs
    {
        public PressureChangeEventArgs(ushort totalWeight)
        {
            TotalWeight = totalWeight;
        }

        public ushort TotalWeight { get; }
    }
}
