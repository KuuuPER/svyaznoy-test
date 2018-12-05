using System;
using System.Collections.Generic;
using System.Text;

namespace SvyaznoyTestProject.Models.Buttons
{
    abstract class BaseButton : IButton
    {
        private bool _pushed;

        public virtual void Push()
        {
            this._pushed = true;
        }

        public virtual void SetPushedFalse()
        {
            this._pushed = false;
        }
    }
}
