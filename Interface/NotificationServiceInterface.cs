using NotificationApp.Models;
namespace NotificationApp.Interfaces;

internal interface INotification
{
    void Send(string message,User user);
}