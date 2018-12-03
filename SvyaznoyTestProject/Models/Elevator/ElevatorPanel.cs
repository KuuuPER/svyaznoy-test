using SvyaznoyTestProject.Models.Buttons;
using System;
using System.Collections.Generic;
using System.Text;

namespace SvyaznoyTestProject.Models
{
    class ElevatorPanel
    {
        public ElevatorPanel(sbyte minfloors, sbyte maxfloors)
        {
            for (int i = minfloors; i < maxfloors; i++)
            {
                this.FloorButtons.Add(i, new FloorButton());
            }

            this.DispatcherButton = new DispatcherButton();
            this.ElevatorDoorButtons.Add(ElevatorDoorButtonTypes.Open, new ElevatorOpenDoorButton());
            this.ElevatorDoorButtons.Add(ElevatorDoorButtonTypes.Close, new ElevatorCloseDoorButton());
        }

        private Dictionary<int, IButton> FloorButtons { get; set; }

        private DispatcherButton DispatcherButton { get; set; }

        private Dictionary<ElevatorDoorButtonTypes, IButton> ElevatorDoorButtons { get; set; }
    }
}
