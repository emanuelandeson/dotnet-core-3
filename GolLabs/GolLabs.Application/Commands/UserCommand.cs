using Flunt.Notifications;
using Flunt.Validations;
using GolLabs.Application.Core;
using GolLabs.Application.Services;
using GolLabs.Domain.Contracts;
using System.Threading.Tasks;

namespace GolLabs.Application.Commands
{
    public class UserCommand : Notifiable
    {
        private readonly IUserRepository _userRepository;
        private readonly Response _response;

        public UserCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _response = new Response();
        }

        public async Task<Response> Create(string name, string password, string confirmPassword)
        {
            AddNotifications(new Contract()
            .Requires()
            .IsNotNullOrEmpty(name, "Name", "cannot be null or empty")
            .IsNotNullOrEmpty(password, "Password", "cannot be null or empty")
            .AreNotEquals(password, confirmPassword, "Confirm Password", "password does not match"));

            if (!IsValid())
            {
                _response.AddNotifications(Notifications);
                return _response;
            }

            var user = await _userRepository.Add(new Domain.Entities.User(name, password));

            _response.AddValue(user);
            return _response;
        }

        public async Task<Response> Authenticate(string name, string password)
        {
            AddNotifications(new Contract()
           .Requires()
           .IsNotNullOrEmpty(name, "Name", "cannot be null or empty")
           .IsNotNullOrEmpty(password, "Password", "cannot be null or empty"));

            if (!IsValid())
            {
                _response.AddNotifications(Notifications);
                return _response;
            }

            var user = await _userRepository.Get(name);

            if (user == null)
            {
                AddNotification(new Notification("", "user not found"));
                return _response;
            }

            if(user.Password != Security.Security.Encrypt(password))
            {
                AddNotification(new Notification("", "invalid credentials"));
                return _response;
            }

            var token = TokenService.GenerateToken(user);

            _response.AddValue(new {user = user, token = token });
            return _response;
        }

        public bool IsValid()
        {
            if (Notifications.Count > 0)
                return false;
            return true;
        }
    }
}