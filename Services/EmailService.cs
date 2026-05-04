using System.Net;
using System.Net.Mail;
using NotificationApp.Interfaces;
using NotificationApp.Models;
using NotificationApp.Validation;

namespace NotificationApp.Services;

internal class EmailService : INotification
{
    private string status = "pending";
    public void Send(string message,User user)
    {
        try
        {
            var from = new MailAddress(Environment.GetEnvironmentVariable("FromEmail"),"BusBookingApp");
            var to = new MailAddress(user.Email, user.Name);

            string? password = Environment.GetEnvironmentVariable("Password");

            var smtp = new SmtpClient("smtp.gmail.com",587)
            {
                Credentials = new NetworkCredential(from.Address,password),
                EnableSsl = true
            };

            var mail = new MailMessage(from,to)
            {
                Subject = "Notification",
                Body = message,
                IsBodyHtml = true
            };
            smtp.Send(mail);

            status = "Sent";
        }
        catch (Exception ex)
        {
            status = "Failed" + ex.Message;
        }
        Log(message,user);
    }
    private void Log(string message,User user)
    {
        Console.WriteLine("Logging the Information - Email Service");
        Console.WriteLine($"The Email Services\nFrom : sivakavindra@gmail.com\nTo : {user.Email}\nStatus : {status}\nMessage : {message}");
    }

    private bool CheckValidation(User user)
    {
        return EmailValidation.isValidEmail(user.Email);
    }

}