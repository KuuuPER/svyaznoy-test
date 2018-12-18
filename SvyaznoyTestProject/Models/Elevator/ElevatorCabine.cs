using System.Threading.Tasks;

namespace SvyaznoyTestProject.Models
{
    class ElevatorCabine
    {
        private ushort _maxWeight;

        private PublishSubscriber<CloseDoorRequestEventArgs> _closeDoorPs;
        private PublishSubscriber _readyToMovePs;

        public ElevatorCabine(ElevatorOptions options,
            PublishSubscriber<ElevatorFloorButtonEventArgs> floorButtonPs,
            PublishSubscriber<ElevatorDoorButtonEventArgs> doorButtonPs,
            PublishSubscriber<PressureChangeEventArgs> pressureChangePs,
            PublishSubscriber detectMovePs,
            PublishSubscriber<CloseDoorRequestEventArgs> closeDoorPs,
            PublishSubscriber readyToMovePs)
        {
            this.Panel = new ElevatorPanel(
                options.Minfloors,
                options.Maxfloors,
                floorButtonPs,
                doorButtonPs);
            doorButtonPs.OnChange += OnCloseDoorButtonPush;
            this.PressureSensor = new PressureSensor(pressureChangePs);
            this.DoorSensor = new DoorSensor(detectMovePs);

            var doorPs = new PublishSubscriber();
            this._doors = new Doors(doorPs);
            doorPs.OnChange += OnDoorsEvent;

            _readyToMovePs = readyToMovePs;
            _closeDoorPs = closeDoorPs;
            _maxWeight = options.MaxWeight;
        }

        public ElevatorPanel Panel { get; }

        public PressureSensor PressureSensor { get; }

        public DoorSensor DoorSensor { get; }

        private Doors _doors;

        public async Task CloseDoor()
        {
            await this._doors.CloseDoors();
        }

        private void OnCloseDoorButtonPush(object sender, ElevatorDoorButtonEventArgs args)
        {
            _closeDoorPs.Raise(this, new CloseDoorRequestEventArgs(PressureSensor.Value, _maxWeight));
        }

        private void OnDoorsEvent(object sender, object eventArgs)
        {
            var doors = sender as Doors;

            if (doors.DoorsState == DoorsStates.Closed)
            {
                _readyToMovePs.Raise(this);
            }
        }
    }
}
