using System;
using System.Threading.Tasks;

namespace SvyaznoyTestProject.Models
{
    class ElevatorEngine
    {
        PublishSubscriber<ElevatorMoveEventArgs> _elevatorMovePs;
        PublishSubscriber<ElevatorStageChangedEventArgs> _elevatorStageChangePs;

        public ElevatorEngine(
            PublishSubscriber<ElevatorMoveEventArgs> elevatorMovePs,
            PublishSubscriber<ElevatorStageChangedEventArgs> elevatorStageChangePs)
        {
            _elevatorMovePs = elevatorMovePs;
            _elevatorStageChangePs = elevatorStageChangePs;

            CurrentStage = 0;
        }

        public byte CurrentStage { get; private set; }

        public event EventHandler<ElevatorStageChangedEventArgs> ElevatorStageChanged;

        public async Task MoveToStage(byte targetStage)
        {
            await Task.Factory.StartNew(() =>
             {
                 if (CurrentStage > targetStage)
                 {
                     for (int i = 0; i < CurrentStage - targetStage; i++)
                     {
                         Console.WriteLine("Движемся вниз...");
                         Task.Delay(3000).Wait();

                         _elevatorStageChangePs?.Raise(this, new ElevatorStageChangedEventArgs(--CurrentStage, MoveDirections.Down));
                     }
                 }
                 else
                 {
                     var count = CurrentStage - targetStage;
                     for (int i = 0; i < targetStage - CurrentStage; i++)
                     {
                         Console.WriteLine("Движемся вверх...");
                         Task.Delay(3000).Wait();
                         _elevatorStageChangePs?.Raise(this, new ElevatorStageChangedEventArgs(++CurrentStage, MoveDirections.Up));
                     }
                 }
             });
        }
    }
}
