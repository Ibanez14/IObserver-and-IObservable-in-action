using System;

namespace ObserverReactiveExtensionReactiveProgrammin
{
    public class BaggageObserver : IObserver<BaggageInfo>
    {
        public BaggageObserver(string name)
        {
            Name = name;
        }

        public string Name { get; }
        private IDisposable cancellation { get; set; }   


        public void SubscribeTo(IObservable<BaggageInfo> subject)
        {
            cancellation = subject.Subscribe(this);
        }

        public void Unsubscribe()
            => cancellation.Dispose();


        public void OnCompleted()
            => Console.WriteLine("Baggages are completed");
        


        public void OnError(Exception error)
        => Console.WriteLine(error.Message);
        

        public void OnNext(BaggageInfo value)
        {
            Console.WriteLine(value.FlightNumber);

            if (true) // something then we can unsubscribe
                cancellation.Dispose();

        }
    }
}
