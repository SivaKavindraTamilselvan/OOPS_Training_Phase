using NotificationApp.Validation;
using NotificationApp.Models;
internal class Program
{
    static void Main(string[] args)
    {
        User user = new User("Siva Kavindra","sivakavindra@gmail.com","9442378188");
        bool result = EmailValidation.isValidEmail("sivakavindra");
        Console.WriteLine(result);
    }
}