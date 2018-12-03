using System;
using System.Collections.Generic;
using System.Text;

namespace SvyaznoyTestProject.Models.Buttons
{
    abstract class BaseButton : IButton
    {
        public bool IsPushed { get; protected set; }

        public virtual void Push()
        {
            this.IsPushed = true;
        }

        public virtual void SetPushedFalse()
        {
            this.IsPushed = false;
        }
    }
}
