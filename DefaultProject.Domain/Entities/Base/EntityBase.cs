using Flunt.Notifications;
using System;

namespace DefaultProject.Domain.Entities.Base
{
    public abstract class EntityBase : Notifiable
    {        
        public long Id { get; set; }
    }
}
