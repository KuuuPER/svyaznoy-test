using System;
using System.Collections.Generic;
using System.Text;

namespace SvyaznoyTestProject.Models
{
    class Elevator
    {
        private ushort _maxWeight;

        public Elevator(sbyte minfloors, sbyte maxfloors, ushort maxWeight)
        {
            this.Panel = new ElevatorPanel(minfloors, maxfloors);
            this.PressureSensor = new PressureSensor();
            this.DoorSensor = new DoorSensor();

            _maxWeight = maxWeight;
        }

        public ElevatorPanel Panel { get; }

        public PressureSensor PressureSensor { get; }

        public DoorSensor DoorSensor { get; }
    }
}
