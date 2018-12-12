using System;

namespace SvyaznoyTestProject
{
    class PublishSubscriber<T> where T: EventArgs
    {
        public event EventHandler<T> OnChange;

        public void Raise(T args)
        {
            OnChange?.Invoke(this, args);
        }
    }
}
