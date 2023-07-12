using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevvaCoins.Domain.Shared.Notifications
{
    public abstract class Notice<T> where T : Notification
    {
        private readonly List<T> _notifications;
        public bool IsValid => !_notifications.Any();
        public IReadOnlyCollection<T> Notifications => _notifications;
        protected Notice()
        {
            _notifications = new List<T>();
        }

        private static T GetNotificationInstance(string key, string message)
        {
            return (Activator.CreateInstance(typeof(T), new object[] { key, message }) as T)!;
        }
        public void AddNotification(string key, string message)
        {
            var notification = GetNotificationInstance(key, message);
            _notifications.Add(notification);
        }
        public void AddNotification(T notification)
        {
            _notifications.Add(notification);
        }
        public void AddNotifications(IReadOnlyCollection<T> notifications)
        {
            _notifications.AddRange(notifications);
        }
        public void AddNotifications(Notice<T> item)
        {
            AddNotifications(item.Notifications);
        }
        public void AddNotifications(params Notice<T>[] items)
        {
            foreach (var item in items)
                AddNotifications(item);
        }
        public void Clear()
        {
            _notifications.Clear();
        }
    }
}
