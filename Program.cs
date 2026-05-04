using NotificationApp.Validation;
using NotificationApp.Models;
using NotificationApp.Services;
using DotNetEnv;
using System.Collections;
using System.Reflection.Metadata;

internal class Program
{
    static void Main(string[] args)
    {
        Env.Load();

        //User user = new User("Siva Kavindra","sivakavindratamilselvan@gmail.com","9442378188");
        //bool result = EmailValidation.isValidEmail("sivakavindra");
        //Console.WriteLine(result);
        //result = PhoneNumberValidation.isValidPhoneNumber("9442378188");
        //Console.WriteLine(result);
        //EmailService email= new EmailService();
        //email.Send("hii",user);
        //SMSService sms = new SMSService();
        //sms.Send("hii",user);
        UserService userService = new UserService();
        while(true)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Enter 1 To Add User");
            Console.WriteLine("Enter 2 To Get The User By Email");
            Console.WriteLine("Enter 3 To Get The User By PhoneNumber");
            Console.WriteLine("Enter 4 To Display All The Users");
            Console.WriteLine("Enter 5 To Delete The User By Email");
            Console.WriteLine("Enter 6 To Delete The User By PhoneNumber");
            Console.WriteLine("Enter 0 To Quit The Loop");
            Console.WriteLine("------------------------------------------------");


            int typechoice;
            while(!int.TryParse(Console.ReadLine(),out typechoice) || typechoice>6 || typechoice<0)
            {
                Console.WriteLine("Enter Vaild Input");
                continue;
            }
            switch(typechoice)
            {
                case 1:
                    {
                        User user = userService.AddUser();
                        Console.WriteLine(user);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Enter the Email To Get The User");
                        string email = Console.ReadLine() ?? "";
                        while(!EmailValidation.isValidEmail(email))
                        {
                            Console.WriteLine("Invalid Email Entered.Enter Vaild Email Address");
                            email = Console.ReadLine() ?? "";
                        }
                        User user = userService.GetUserByEmail(email);
                        if(user == null)
                        {
                            Console.WriteLine($"No User Found With Email Address {email}");
                            break;
                        }
                        Console.WriteLine(user);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Enter the PhoneNumber To Get The User");
                        string phone = Console.ReadLine() ?? "";
                        while (!PhoneNumberValidation.isValidPhoneNumber(phone))
                        {
                            Console.WriteLine("Invalid Phone Number Entered.Enter Valid PhoneNumber");
                            phone = Console.ReadLine() ?? "";
                        }
                        User user = userService.GetUserByPhoneNumber(phone);
                        if(user == null)
                        {
                            Console.WriteLine($"No User Found With Phone Number {phone}");
                            break;
                        }
                        Console.WriteLine(user);
                        break;
                    }
                case 4:
                    {
                        userService.PrintAllUsers();
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Enter the Email To Delete The User");
                        string email = Console.ReadLine() ?? "";
                        while(!EmailValidation.isValidEmail(email))
                        {
                            Console.WriteLine("Invalid Email Entered.Enter Vaild Email Address");
                            email = Console.ReadLine() ?? "";
                        }
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("Enter the PhoneNumber To Get The User");
                        string phone = Console.ReadLine() ?? "";
                        while (!PhoneNumberValidation.isValidPhoneNumber(phone))
                        {
                            Console.WriteLine("Invalid Phone Number Entered.Enter Valid PhoneNumber");
                            phone = Console.ReadLine() ?? "";
                        }
                        User user = userService.GetUserByPhoneNumber(phone);
                        Console.WriteLine(user);
                        break;
                    }
                case 0:
                    {
                        return;
                    }
            }
        }

    }
}