using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverReactiveExtensionReactiveProgrammin.Observer_and_Observerable
{
    class UnSubscriber<Subject> : IDisposable
    {
        readonly List<IObserver<Subject>> observers;
        readonly IObserver<Subject> observer;

        private readonly object loki = new object();
        public UnSubscriber(List<IObserver<Subject>> observers, IObserver<Subject> observer)
        {
            this.observers = observers;
            this.observer = observer;
        }

        public void Dispose()
        {
            // since removing can be both here and in Handler you had better synhronize it
            lock (loki)
            {
                if (observers.Contains(observer))
                    observers.Remove(observer); 
            }
        }
    }
}
