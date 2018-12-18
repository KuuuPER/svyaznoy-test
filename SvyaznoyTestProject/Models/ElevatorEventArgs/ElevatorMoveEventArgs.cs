using System;
using System.Collections.Generic;
using System.Text;

namespace SvyaznoyTestProject.Models
{
    class ElevatorMoveEventArgs: EventArgs
    {
        public ElevatorMoveEventArgs(byte currentStage, byte moveToStage)
        {
            this.CurrentStage = currentStage;
            this.MoveToStage = moveToStage;
        }

        public byte CurrentStage { get; set; }

        public byte MoveToStage { get; set; }
    }
}
