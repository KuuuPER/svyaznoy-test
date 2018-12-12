using SvyaznoyTestProject.Models.Buttons;
using System.Collections.Generic;
using SvyaznoyTestProject.Models.ElevatorEventArgs;

namespace SvyaznoyTestProject.Models
{
    class ElevatorPanel
    {
        private PublishSubscriber<ElevatorFloorButtonEventArgs> _floorButtonPushed;
        private PublishSubscriber<ElevatorDoorButtonEventArgs> _doorButtonPushed;

        private Dictionary<sbyte, FloorButton> _floorButtons;
        private DispatcherButton _dispatcherButton;
        private Dictionary<ElevatorDoorButtonTypes, ElevatorDoorButton> _doorButtons;

        public ElevatorPanel(sbyte minfloors,
            sbyte maxfloors,
            PublishSubscriber<ElevatorFloorButtonEventArgs> floorButtonPushed,
            PublishSubscriber<ElevatorDoorButtonEventArgs> doorButtonPushed)
        {
            _floorButtonPushed = floorButtonPushed;
            _doorButtonPushed = doorButtonPushed;

            _floorButtons = new Dictionary<sbyte, FloorButton>();
            _doorButtons = new Dictionary<ElevatorDoorButtonTypes, ElevatorDoorButton>(2);

            for (sbyte i = minfloors; i < maxfloors; i++)
            {
                _floorButtons.Add(i, new FloorButton());
            }

            _dispatcherButton = new DispatcherButton();
            _doorButtons.Add(ElevatorDoorButtonTypes.Open, new ElevatorOpenDoorButton());
            _doorButtons.Add(ElevatorDoorButtonTypes.Close, new ElevatorCloseDoorButton());
        }

        public void PushFloorButton(sbyte floorNum)
        {
            _floorButtons[floorNum].Push();
            _floorButtonPushed.Raise(this, new ElevatorFloorButtonEventArgs(floorNum));
        }

        public void PushDoorButton(ElevatorDoorButtonTypes buttonType)
        {
            _doorButtons[buttonType].Push();
            _doorButtonPushed.Raise(this, new ElevatorDoorButtonEventArgs(buttonType));
        }
    }
}
