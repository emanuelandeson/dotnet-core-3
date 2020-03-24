using Flunt.Notifications;
using Flunt.Validations;
using GolLabs.Application.Core;
using GolLabs.Domain.Contracts;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace GolLabs.Application.Commands
{
    public class TripCommand : Notifiable
    {
        private readonly ITripRepository _tripRepository;
        private readonly Response _response;


        public TripCommand(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
            _response = new Response();
        }

        public async Task<Response> Create(string passengerName, string date, string time, string origin, string destination)
        {
            ValidateEntity(passengerName, date, time, origin, destination);

            if (!IsValid())
            {
                _response.AddNotifications(Notifications);
                return _response;
            }
                
             
            var trip = await _tripRepository.Add(new Domain.Entities.Trip(passengerName, GetDate(date), GetTime(time), origin, destination));
            _response.AddValue(trip);
            return _response;
        }

        public async Task<Response> Update(string id, string passengerName, string date, string time, string origin, string destination)
        {
            ValidateEntity(passengerName, date, time, origin, destination, id);

            if (!IsValid())
                _response.AddNotifications(Notifications);

            var trip = await _tripRepository.Update(new Domain.Entities.Trip(passengerName, GetDate(date), GetTime(time), origin, destination, id));
            _response.AddValue(trip);
            return _response;
        }

        public async Task<Response> Delete(string tripId)
        {
            AddNotifications(new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(tripId, "Trip identifier", "cannot be null or empty"));

            if (!IsValid())
            {
                _response.AddNotifications(Notifications);
                return _response;
            }

            var trip = await _tripRepository.Get(tripId);

            if (trip == null)
            {
                _response.AddNotification(new Notification("", "Trip not found"));
                return _response;
            }

            await _tripRepository.Delete(trip);

            _response.AddValue(trip);

            return _response;
        }

        public void ValidateEntity(string passengerName, string date, string time, string origin, string destination, string id= null)
        {
            try
            {
                 GetDate(date);
                  GetTime(time);
            }
            catch (Exception)
            {
                AddNotification(new Notification("","invalid format for date and time"));
            }

            AddNotifications(new Contract()
            .Requires()
            .IsNotNullOrEmpty(passengerName, "Passenger Name", "cannot be null or empty")
            .IsNotNullOrEmpty(origin, "Origin", "cannot be null or empty")
            .IsNotNullOrEmpty(destination, "Destination", "cannot be null or empty")
            .IsNotNull(date, "Date", "cannot be null or empty")
            .IsNotNull(time, "Time", "cannot be null or empty"));
        }

        private DateTime GetDate(string date)
        {
            DateTime d = DateTime.Parse(date);
            return d;
        }

        private string GetTime(string time)
        {
            DateTime t = DateTime.ParseExact(time, "HH:mm",
                                               CultureInfo.InvariantCulture);

            return t.ToString("HH:mm");
        }

        public bool IsValid()
        {
            if (Notifications.Count > 0)
                return false;
            return true;
        }
    }
}
