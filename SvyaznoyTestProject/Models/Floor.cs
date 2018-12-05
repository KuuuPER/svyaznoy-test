using System;
using System.Collections.Generic;
using System.Text;

namespace SvyaznoyTestProject.Models
{
    class Floor
    {
        private FloorPanel _panel;

        public Floor(int floorNum, FloorPanel panel)
        {
            _panel = panel;
            Num = floorNum;
        }

        public int Num { get; }

        public DoorsStates DoorsState { get; private set; }
    }
}
