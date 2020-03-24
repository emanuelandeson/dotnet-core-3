using Flunt.Notifications;
using System;
using System.ComponentModel.DataAnnotations;

namespace GolLabs.Domain.Entities
{
    public class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public bool IsValid()
        {
            if (Notifications.Count > 0)
                return false;
            return true;
        }
    }
}
