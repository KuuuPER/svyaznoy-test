using SvyaznoyTestProject.Models.Buttons;
using SvyaznoyTestProject.Models.EventArgs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SvyaznoyTestProject.Models
{
    class FloorPanel
    {
        private ElevatorCallButton _upButton;
        private ElevatorCallButton _downButton;
        private ushort _floorNum;

        public FloorPanel(ushort floorNum, PublishSubscriber<ElevatorCallEventArgs> elevatorCall)
        {
            _floorNum = floorNum;
            _elevatorCall = elevatorCall;
            _buttons = new Dictionary<ElevatorCallDirections, BaseButton>(2);

            _upButton = new ElevatorCallButton(ElevatorCallDirections.Up);
            _downButton = new ElevatorCallButton(ElevatorCallDirections.Down);
        }

        private Dictionary<ElevatorCallDirections, BaseButton> _buttons;

        public void CallElevator(ElevatorCallDirections direction)
        {
            _elevatorCall?.Raise(new ElevatorCallEventArgs(_floorNum, direction));
        }

        public void ElevatorBeenCalled(ElevatorCallDirections direction)
        {
            _buttons[direction].Push();
        }

        public void ElevatorArrived(ElevatorCallDirections direction)
        {
            _buttons[direction].SetPushedFalse();
        }

        private PublishSubscriber<ElevatorCallEventArgs> _elevatorCall;
    }
}
