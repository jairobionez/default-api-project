using Flunt.Notifications;
using System.Collections.Generic;

namespace DefaultProject.Domain.Interfaces.Notifications
{
    public interface INotifiable
    {
        IReadOnlyCollection<Notification> Notifications { get; }
        bool Invalid { get; }
        bool Valid { get; }

        void AddNotification(string property, string message);
        void AddNotification(Notification notification);
        void AddNotifications(IReadOnlyCollection<Notification> notifications);
        void AddNotifications(IList<Notification> notifications);
        void AddNotifications(ICollection<Notification> notifications);
        void AddNotifications(Notifiable item);
        void AddNotifications(params Notifiable[] items);
    }
}
