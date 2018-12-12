﻿using System;
using System.Threading.Tasks;

namespace SvyaznoyTestProject.Models
{
    class ElevatorDoors
    {
        private DoorsStates _doorsState;
        private PublishSubscriber _doorsPs;

        public ElevatorDoors(PublishSubscriber doorsPs)
        {
            _doorsState = DoorsStates.Closed;
            _doorsPs = doorsPs;
        }

        public Task CloseDoors()
        {
            Console.WriteLine("Осторожно, двери закрываются...");
            return Task.Factory.StartNew(async () => {
                await Task.Delay(2000);
                _doorsState = DoorsStates.Closed;
                _doorsPs.Raise(this);
            });
        }

        public Task OpenDoors()
        {
            Console.WriteLine("Двери открываются...");
            return Task.Factory.StartNew(async () => {
                await Task.Delay(2000);
                _doorsPs.Raise(this);
            });
        }

        public DoorsStates DoorsState { get { return _doorsState; } }
    }
}