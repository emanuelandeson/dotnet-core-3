using Flunt.Validations;
using System;

namespace GolLabs.Domain.Entities
{
    public class Trip : Entity
    {
        public Trip(string name, DateTime date, string time, string origin, string destination, string id = null)
        {
            AddNotifications(new Contract()
               .Requires()
               .IsNotNullOrEmpty(name, "Passenger Name", "cannot be null or empty")
               .IsNotNull(date, "Date", "cannot be null or empty")
               .IsNotNull(time, "Time", "cannot be null or empty")
               .IsNotNullOrEmpty(origin, "Origin", "cannot be null or empty")
               .IsNotNullOrEmpty(destination, "Destination", "cannot be null or empty"));

            Name = name;
            Date = date.Date;
            Time = time;
            Origin = origin;
            Destination = destination;
            Id = id!= null? id:Id;
        }
        public Trip()
        {
        }

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
    }
}
