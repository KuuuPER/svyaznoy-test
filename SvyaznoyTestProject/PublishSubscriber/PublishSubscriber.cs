using System;

namespace SvyaznoyTestProject
{
    class PublishSubscriber<T> where T: EventArgs
    {
        public event EventHandler<T> OnChange;

        public void Raise(object sender, T args)
        {
            OnChange?.Invoke(sender, args);
        }
    }

    class PublishSubscriber
    {
        public event EventHandler OnChange;

        public void Raise(object obj)
        {
            OnChange?.Invoke(obj, null);
        }
    }
}
