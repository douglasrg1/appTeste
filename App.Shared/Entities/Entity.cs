using System;
using Flunt.Notifications;

namespace App.Shared.Entity
{
    public abstract class Entity : Notifiable
    {
        public Entity(Guid id)
        {
            Id = id;
        }
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}