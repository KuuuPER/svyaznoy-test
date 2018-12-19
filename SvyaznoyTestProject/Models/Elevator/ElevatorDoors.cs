using System;
using System.Threading.Tasks;

namespace SvyaznoyTestProject.Models
{
    class Doors
    {
        private DoorsStates _doorsState;
        private PublishSubscriber _doorsPs;

        public Doors(PublishSubscriber doorsPs)
        {
            _doorsState = DoorsStates.Closed;
            _doorsPs = doorsPs;
        }

        public Task CloseDoors()
        {
            Console.WriteLine("Осторожно, двери закрываются...");
            return Task.Factory.StartNew(() => {
                Task.Delay(2000).Wait();
                _doorsState = DoorsStates.Closed;
                _doorsPs.Raise(this);
            });
        }

        public Task OpenDoors()
        {
            Console.WriteLine("Двери открываются...");
            return Task.Factory.StartNew(() => {
                Task.Delay(2000).Wait();
                _doorsPs.Raise(this);
            });
        }

        public DoorsStates DoorsState { get { return _doorsState; } }
    }
}
