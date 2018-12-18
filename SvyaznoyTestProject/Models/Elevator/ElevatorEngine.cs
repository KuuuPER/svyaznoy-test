using System;
using System.Threading.Tasks;

namespace SvyaznoyTestProject.Models
{
    class ElevatorEngine
    {
        private volatile byte _targetStage;

        public ElevatorEngine(
            PublishSubscriber<ElevatorMoveEventArgs> elevatorMovePs,
            PublishSubscriber<ElevatorStageChangedEventArgs> elevatorStageChangePs)
        {
            CurrentStage = 0;
        }

        public byte CurrentStage { get; private set; }

        public event EventHandler<ElevatorStageChangedEventArgs> ElevatorStageChanged;
        

        public void MoveToStage(byte targetStage)
        {
            _targetStage = targetStage;
            Task.Factory.StartNew(async () =>
             {
                 if (CurrentStage > _targetStage)
                 {
                     for (int i = 0; i < CurrentStage - _targetStage; i++)
                     {
                         Console.WriteLine("Движемся вниз...");
                         await Task.Delay(3000);

                         ElevatorStageChanged?.Invoke(this, new ElevatorStageChangedEventArgs(CurrentStage, MoveDirections.Down));
                     }
                 }
                 else
                 {
                     var count = CurrentStage - _targetStage;
                     for (int i = 0; i < _targetStage - CurrentStage; i++)
                     {
                         Console.WriteLine("Движемся вверх...");
                         await Task.Delay(3000);
                         ElevatorStageChanged?.Invoke(this, new ElevatorStageChangedEventArgs(++CurrentStage, MoveDirections.Up));
                     }
                 }
             });
        }

        public void ChangeTargetStage(byte targetStage)
        {
            _targetStage = targetStage;
        }
    }
}
