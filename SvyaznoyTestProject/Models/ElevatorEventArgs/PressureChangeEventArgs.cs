using System;
using System.Collections.Generic;
using System.Text;

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
