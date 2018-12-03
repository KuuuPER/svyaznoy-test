using SvyaznoyTestProject.Models.Buttons;
using System;
using System.Collections.Generic;
using System.Text;

namespace SvyaznoyTestProject.Models
{
    class Floor
    {
        public Floor()
        {
            this.Buttons = new Dictionary<ElevatorCallDirections, IButton>(2);

            this.Buttons.Add(ElevatorCallDirections.Up, new ElevatorCallButton());
            this.Buttons.Add(ElevatorCallDirections.Down, new ElevatorCallButton());
        }

        public Dictionary<ElevatorCallDirections, IButton> Buttons { get; set; }
    }
}
