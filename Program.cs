using NotificationApp.Validation;
using NotificationApp.Models;
using NotificationApp.Services;
using DotNetEnv;

internal class Program
{
    static void Main(string[] args)
    {
        Env.Load();

        User user = new User("Siva Kavindra","sivakavindratamilselvan@gmail.com","9442378188");
        bool result = EmailValidation.isValidEmail("sivakavindra");
        Console.WriteLine(result);
        result = PhoneNumberValidation.isValidPhoneNumber("9442378188");
        Console.WriteLine(result);
        //EmailService email= new EmailService();
        //email.Send("hii",user);
        //SMSService sms = new SMSService();
        //sms.Send("hii",user);
        UserService userService = new UserService();
        Console.WriteLine(userService.AddUser());
        Console.WriteLine(userService.GetUserByEmail("sivakavindra@gmail.com"));
        Console.WriteLine(userService.GetUserByPhoneNumber("9442378188"));

    }
}