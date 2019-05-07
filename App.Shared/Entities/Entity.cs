using System;
using Flunt.Notifications;

namespace App.Shared.Entity
{
    public abstract class Entity : Notifiable
    {
        public Entity(int id)
        {
            Id = id;
        }
        public Entity()
        {
        }

        public int Id { get; private set; }
    }
}