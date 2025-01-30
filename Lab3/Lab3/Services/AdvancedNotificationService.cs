namespace Lab3.Services;

public class AdvancedNotificationService:NotificationService
{
    public override void SendNotification(string message)
    {
        base.SendNotification(message);
        Console.WriteLine(DateTime.Now.ToShortTimeString());
    }
    
}