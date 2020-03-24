using Flunt.Notifications;
using Flunt.Validations;

namespace GolLabs.Domain.Entities
{
    public class User:Entity
    {
        public string Name { get; private set; }
        public string Password { get; private set; }

        public User(string name, string password)
        {
            if (string.IsNullOrEmpty(name))
                AddNotification(new Notification("Name", "invalid name"));

            AddNotifications(
               new Contract()
                   .Requires()
                   .IsNotNullOrEmpty(password, "Password", "Cannot be null or empty.")
                   .HasMaxLen(password, 12, "Password", "minimum of 6 e maximum 12 characters")
                   .HasMinLen(password, 6, "Password", "minimum of 6 e maximum 12 characters"));

            Name = name;
            Password = password;
        }

        public User()
        {

        }
    }
}
