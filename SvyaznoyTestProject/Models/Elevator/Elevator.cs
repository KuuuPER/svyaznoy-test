using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SvyaznoyTestProject.Models.Elevator
{
    class Elevator
    {
        private ElevatorCabine _cabine;
        private ElevatorEngine _engine;

        private ElevatorStatuses _status;

        private List<byte> _targetStages;

        public Elevator(ElevatorOptions options,
            PublishSubscriber<ElevatorFloorButtonEventArgs> floorButtonPs,
            PublishSubscriber<ElevatorDoorButtonEventArgs> doorButtonPs,
            PublishSubscriber<PressureChangeEventArgs> pressureChangePs,
            PublishSubscriber detectMovePs,
            PublishSubscriber<CloseDoorRequestEventArgs> closeDoorPs,
            PublishSubscriber readyToMovePs,
            PublishSubscriber<ElevatorMoveEventArgs> elevatorMovePs,
            PublishSubscriber<ElevatorStageChangedEventArgs> elevatorStageChangePs)
        {
            _cabine = new ElevatorCabine(
                options,
                floorButtonPs,
                doorButtonPs,
                pressureChangePs,
                detectMovePs,
                closeDoorPs,
                readyToMovePs);

            _engine = new ElevatorEngine(elevatorMovePs, elevatorStageChangePs);
            _status = ElevatorStatuses.Awaiting;
            _targetStages = new List<byte>();
        }

        public ElevatorState ElevatorState => new ElevatorState(
                _engine.CurrentStage,
                _status,
                _cabine.DoorsState
            );

        public async Task AddTargetStage(byte stageNum)
        {
            _targetStages.Add(stageNum);

            if(_targetStages.Count == 1)
            {
                await StartMove();
            }
        }

        private async Task StartMove()
        {
            await Task.Factory.StartNew(() =>
            {
                while (_targetStages.Count != 0)
                {
                    var targetStage = _targetStages.First();
                    _status = _engine.CurrentStage > targetStage ? ElevatorStatuses.MovingDown : ElevatorStatuses.MovingUp;
                    Task.WaitAll(
                        _engine.MoveToStage(targetStage)
                    );
                    _status = ElevatorStatuses.Awaiting;
                }
            });
        }
    }
}
