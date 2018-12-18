using System;
using System.Collections.Generic;
using System.Text;

namespace SvyaznoyTestProject.Models
{
    class DoorSensor
    {
        private PublishSubscriber _detectMovePs;

        public DoorSensor(PublishSubscriber detectMovePs)
        {
            _detectMovePs = detectMovePs;
        }

        public void DetectMove()
        {
            _detectMovePs.Raise(this);
        }
    }
}
