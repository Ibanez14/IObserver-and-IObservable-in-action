using ObserverReactiveExtensionReactiveProgrammin.Observer_and_Observerable;
using System;
using System.Collections.Generic;

namespace ObserverReactiveExtensionReactiveProgrammin
{
    // Observable
    public class BaggageHandler : IObservable<BaggageInfo>
    {
        List<IObserver<BaggageInfo>> observers;
        List<BaggageInfo> fligts;

        public BaggageHandler()
        {
            observers = new List<IObserver<BaggageInfo>>();
            fligts = new List<BaggageInfo>();
        }

        public IDisposable Subscribe(IObserver<BaggageInfo> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
                // provide newly subscribed observer with exiting data
                foreach (BaggageInfo baggegeInfo in fligts)
                    observer.OnNext(baggegeInfo);
                    
            }
            return new UnSubscriber<BaggageInfo>(observers, observer);
        }

        public void NewBaggageArrived(int flightNumber, string location)
        {
            var newBaggage = new BaggageInfo(flightNumber, location);
            try
            {
                fligts.Add(newBaggage);

                // notify observers
                foreach (var observer in observers)
                    observer.OnNext(newBaggage);
            }
            catch (Exception ex)
            {
                foreach (var observer in observers)
                    observer.OnError(ex);
            }
        }

        public void LastBaggageClaimed()
        {
            foreach (var observer in observers)
                observer.OnCompleted();

            observers.Clear();
        }
    }
}
