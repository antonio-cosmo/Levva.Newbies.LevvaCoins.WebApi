namespace LevvaCoins.Domain.SeedWork.Notification;

public abstract class Notifiable
{
    private readonly List<Notification> _notifications;
    public bool IsValid => !_notifications.Any();
    public IReadOnlyCollection<Notification> Notifications => _notifications;

    protected Notifiable()
    {
        _notifications = new List<Notification>();
    }

    protected void AddNotification(Notification notification)
    {
        _notifications.Add(notification);
    }

    protected void AddNotification(string key, string message)
    {
        _notifications.Add(new Notification(key, message));
    }

    protected void AddNotifications(IReadOnlyCollection<Notification> notifications)
    {
        foreach (var notification in notifications)
        {
            AddNotification(notification);
        }
    }
}