using System;
using System.Collections.Generic;
using System.Text;

namespace SvyaznoyTestProject.Models
{
    class Elevator
    {
        private ushort _maxWeight;

        public Elevator(ElevatorOptions options,
            PublishSubscriber<ElevatorFloorButtonEventArgs> floorButtonPs,
            PublishSubscriber<ElevatorDoorButtonEventArgs> doorButtonPs,
            PublishSubscriber<PressureChangeEventArgs> pressureChangePs,
            PublishSubscriber detectMovePs)
        {
            this.Panel = new ElevatorPanel(
                options.Minfloors,
                options.Maxfloors,
                floorButtonPs,
                doorButtonPs);
            this.PressureSensor = new PressureSensor(pressureChangePs);
            this.DoorSensor = new DoorSensor(detectMovePs);

            _maxWeight = options.MaxWeight;
        }

        public ElevatorPanel Panel { get; }

        public PressureSensor PressureSensor { get; }

        public DoorSensor DoorSensor { get; }
    }
}
