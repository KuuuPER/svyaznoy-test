using System;
using System.Threading;
using System.Threading.Tasks;

namespace SvyaznoyTestProject.Models
{
    class ElevatorEngine
    {
        private PublishSubscriber<ElevatorStageChangedEventArgs> _elevatorStageChangePs;
        private CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        private CancellationToken _cancellationToken;

        public ElevatorEngine(
            PublishSubscriber<ElevatorMoveEventArgs> elevatorMovePs,
            PublishSubscriber<ElevatorStageChangedEventArgs> elevatorStageChangePs,
            PublishSubscriber<ChangeTargetStageEventArgs> changeTargetStagePs)
        {
            elevatorMovePs.OnChange += MoveToStage;

            _elevatorStageChangePs = elevatorStageChangePs;
            _cancellationToken = cancelTokenSource.Token;
            changeTargetStagePs.OnChange += ChangeTargetStage;
        }

        public byte _currentStage;
        public volatile byte _targetStage;

        private void MoveToStage(object sender, ElevatorMoveEventArgs args)
        {
            _currentStage = args.CurrentStage;
            _targetStage = args.MoveToStage;
            Task.Factory.StartNew(async () =>
             {
                 if (args.CurrentStage > args.MoveToStage)
                 {
                     for (int i = 0; i < _currentStage - _targetStage; i++)
                     {
                         Console.WriteLine("Движемся вниз...");
                         await Task.Delay(3000);

                         _elevatorStageChangePs.Raise(this, new ElevatorStageChangedEventArgs(--_currentStage, MoveDirections.Down));
                     }
                 }
                 else
                 {
                     var count = args.CurrentStage - args.MoveToStage;
                     for (int i = 0; i < _targetStage - _currentStage; i++)
                     {
                         Console.WriteLine("Движемся вверх...");
                         await Task.Delay(3000);
                         _elevatorStageChangePs.Raise(this, new ElevatorStageChangedEventArgs(++_currentStage, MoveDirections.Up));
                     }
                 }
             }, _cancellationToken);
        }

        public void ChangeTargetStage(object sender, ChangeTargetStageEventArgs args)
        {
            _targetStage = args.TargetStage;
        }
    }
}
