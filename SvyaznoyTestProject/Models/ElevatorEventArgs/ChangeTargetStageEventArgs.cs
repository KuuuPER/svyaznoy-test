using System;

namespace SvyaznoyTestProject.Models
{
    class ChangeTargetStageEventArgs: EventArgs
    {
        public ChangeTargetStageEventArgs(byte value)
        {
            TargetStage = value;
        }

        public byte TargetStage { get; }
    }
}
