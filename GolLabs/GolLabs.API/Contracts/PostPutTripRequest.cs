using System;

namespace GolLabs.API.Contracts
{
    public class PostPutTripRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
    }
}
