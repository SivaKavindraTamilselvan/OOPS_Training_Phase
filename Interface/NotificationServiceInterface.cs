using NotificationApp.Models;
namespace NotificationApp.Interfaces;

internal interface INotification
{
    //interface defined for both email and sms notification
    void Send(string message,User user);

    //check condition for valid email or phone
    private bool CheckValidation(User user)
    {
        return user != null;
    }

    //enter the log in console alone
    private void Log(string message,User user)
    {
        Console.WriteLine($"Log: {message} for {user.Name}");
    }
}