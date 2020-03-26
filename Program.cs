using System;

namespace ObserverReactiveExtensionReactiveProgrammin
{
    class Program
    {
        static void Main(string[] args)
        {
            var baggageProvider = new BaggageHandler(); // observable

            // elegant way of subscribing
            var observerSteve = new BaggageObserver("Steve"); // observer
            observerSteve.SubscribeTo(baggageProvider);
            baggageProvider.NewBaggageArrived(14, "San-Franciso");
            baggageProvider.NewBaggageArrived(16, "San-Franciso");
            observerSteve.Unsubscribe();
            baggageProvider.LastBaggageClaimed();

        }
    }
}
