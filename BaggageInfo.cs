namespace ObserverReactiveExtensionReactiveProgrammin
{
    // Subject
    public class BaggageInfo
    {
        public int FlightNumber { get; set; }
        public string Location { get; set; }

        public BaggageInfo(int flightNumber, string location)
        {
            FlightNumber = flightNumber;
            Location = location;
        }
    }
}
