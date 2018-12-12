namespace SvyaznoyTestProject.Models
{
    class PressureSensor
    {
        private PublishSubscriber<PressureChangeEventArgs> _pressureChange;
        public PressureSensor(PublishSubscriber<PressureChangeEventArgs> pressureChange)
        {
            _pressureChange = pressureChange;
        }

        public ushort Value { get; private set; }

        public void AddWeight(ushort weight)
        {
            Value += weight;
            _pressureChange.Raise(this, new PressureChangeEventArgs(Value));
        }
    }
}
