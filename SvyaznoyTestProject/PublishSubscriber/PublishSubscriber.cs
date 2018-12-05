using System;

namespace SvyaznoyTestProject.PublishSubscriber
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
