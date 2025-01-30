using Lab3.Services;

namespace Lab3;

public class Exercise7
{
    public static void TestNotificationService()
    {
        NotificationService notificationService = new NotificationService();
        notificationService.SendNotification("Hello World!");
        NotificationService notificationService2 = new AdvancedNotificationService();
        notificationService2.SendNotification("This is from advanced notification service");
    }
}