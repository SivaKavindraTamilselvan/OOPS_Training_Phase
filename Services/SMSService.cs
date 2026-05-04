using NotificationApp.Interfaces;
using NotificationApp.Models;

internal class SMSService : INotification
{
    private string status = "pending";
    public void Send(string message,User user)
    {
       Console.WriteLine("MessageService");
       Console.WriteLine("From - 944237XXXX");
       Console.WriteLine($"To - {user.PhoneNumber}");
       Console.WriteLine($"Message - {message}");
       status = "sent";
    }
}