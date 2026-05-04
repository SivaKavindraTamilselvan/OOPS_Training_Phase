using NotificationApp.Interfaces;
using NotificationApp.Models;
using NotificationApp.Validation;

namespace NotificationApp.Services;

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
    private bool checkValidation(User user)
    {
        return PhoneNumberValidation.isValidPhoneNumber(user.PhoneNumber);
    }
}