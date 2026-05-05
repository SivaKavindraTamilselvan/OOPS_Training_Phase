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

        Company company = new Company();
        Console.WriteLine(company);

        UserService userService = new UserService();

        while (true)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Enter 1 To Add User");
            Console.WriteLine("Enter 2 To Get The User By Email");
            Console.WriteLine("Enter 3 To Get The User By PhoneNumber");
            Console.WriteLine("Enter 4 To Display All The Users");
            Console.WriteLine("Enter 5 To Delete The User By Email");
            Console.WriteLine("Enter 6 To Delete The User By PhoneNumber");
            Console.WriteLine("Enter 7 To Deliver The Message To A User By Email");
            Console.WriteLine("Enter 8 To Deliver The Message To A User By Phone Number");
            Console.WriteLine("Enter 0 To Quit The Loop");
            Console.WriteLine("------------------------------------------------");

            int typechoice;

            while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice > 8 || typechoice < 0)
            {
                Console.WriteLine("Enter Vaild Input");
            }

            switch (typechoice)
            {
                case 1:
                    {
                        //used to add the user
                        var user = userService.AddUser();
                        break;
                    }

                case 2:
                    {
                        //get the user by email id entered
                        Console.WriteLine("Enter the Email To Get The User");
                        string email = Console.ReadLine()?.Trim() ?? string.Empty;
                        //loop until valid email is entered
                        while (!EmailValidation.isValidEmail(email))
                        {
                            Console.WriteLine("Invalid Email Entered.Enter Vaild Email Address");
                            email = Console.ReadLine()?.Trim() ?? string.Empty;
                        }
                        var user = userService.GetUserByEmail(email);
                        //check null condition
                        if (user == null)
                        {
                            Console.WriteLine($"No User Found With Email Address {email}");
                            break;
                        }
                        Console.WriteLine(user);
                        break;
                    }

                case 3:
                    {
                        //get the user details by entering the phone number
                        Console.WriteLine("Enter the PhoneNumber To Get The User");
                        string phone = Console.ReadLine()?.Trim() ?? string.Empty;
                        //loop until valid phone number format is entered
                        while (!PhoneNumberValidation.isValidPhoneNumber(phone))
                        {
                            Console.WriteLine("Invalid Phone Number Entered.Enter Valid PhoneNumber");
                            phone = Console.ReadLine()?.Trim() ?? string.Empty;
                        }
                        var user = userService.GetUserByPhoneNumber(phone);
                        //check condition if no user found
                        if (user == null)
                        {
                            Console.WriteLine($"No User Found With Phone Number {phone}");
                            break;
                        }
                        Console.WriteLine(user);
                        break;
                    }

                case 4:
                    {
                        //print all the users alone
                        userService.PrintAllUsers();
                        break;
                    }

                case 5:
                    {
                        //delete the user by entering the email
                        Console.WriteLine("Enter the Email To Delete The User");
                        string email = Console.ReadLine()?.Trim() ?? string.Empty;
                        //loop until valid email entered.
                        while (!EmailValidation.isValidEmail(email))
                        {
                            Console.WriteLine("Invalid Email Entered.Enter Vaild Email Address");
                            email = Console.ReadLine()?.Trim() ?? string.Empty;
                        }
                        var user = userService.DeleteUserByEmail(email);
                        //check null condition
                        if (user == null)
                        {
                            Console.WriteLine($"No User Found With Email Address {email}");
                            break;
                        }
                        Console.WriteLine(user);
                        break;
                    }

                case 6:
                    {
                        //delete the user by entering the phone number
                        Console.WriteLine("Enter the PhoneNumber To Delete The User");
                        string phone = Console.ReadLine()?.Trim() ?? string.Empty;
                        //loop until valid phone number entered
                        while (!PhoneNumberValidation.isValidPhoneNumber(phone))
                        {
                            Console.WriteLine("Invalid Phone Number Entered.Enter Valid PhoneNumber");
                            phone = Console.ReadLine()?.Trim() ?? string.Empty;
                        }
                        var user = userService.DeleteUserByPhoneNumber(phone);
                        //check null condition
                        if (user == null)
                        {
                            Console.WriteLine($"No User Found With Phone Number {phone}");
                            break;
                        }
                        Console.WriteLine(user);
                        break;
                    }

                case 7:
                    {
                        //send email case with customised message to aldready registered users alone
                        Console.WriteLine("Enter Email To Send Message To The User");
                        string email = Console.ReadLine()?.Trim() ?? string.Empty;
                        //loop until valis email is entered
                        while (!EmailValidation.isValidEmail(email))
                        {
                            Console.WriteLine("Invalid Email Entered.Enter Vaild Email Address");
                            email = Console.ReadLine()?.Trim() ?? string.Empty;
                        }
                        var user = userService.GetUserByEmail(email);
                        //check null condition
                        if (user == null)
                        {
                            Console.WriteLine($"No User Found With Email Address {email}");
                            break;
                        }
                        Console.WriteLine($"Enter The Message That needed to be sent to {email}");
                        string message = Console.ReadLine()?.Trim() ?? string.Empty;
                        //loop until some message is entered not the whitespace
                        while (message == "")
                        {
                            message = Console.ReadLine()?.Trim() ?? string.Empty;
                        }
                        //calling the services to send notification
                        EmailService emailService = new EmailService();
                        emailService.Send(message, user);
                        break;
                    }

                case 8:
                    {
                        //send the customised message to aldready registered users alone
                        Console.WriteLine("Enter PhoneNumber To Send Message To The User");
                        string phone = Console.ReadLine()?.Trim() ?? string.Empty;
                        //loop until valid phone number entered
                        while (!PhoneNumberValidation.isValidPhoneNumber(phone))
                        {
                            Console.WriteLine("Invalid Phone Number Entered.Enter Valid PhoneNumber");
                            phone = Console.ReadLine()?.Trim() ?? string.Empty;
                        }
                        var user = userService.GetUserByPhoneNumber(phone);
                        //check null condition
                        if (user == null)
                        {
                            Console.WriteLine($"No User Found With Phone Number {phone}");
                            break;
                        }
                        Console.WriteLine($"Enter The Message That needed to be sent to {phone}");
                        string message = Console.ReadLine()?.Trim() ?? string.Empty;
                        //loop until some message is entered not the whitespace
                        while (message == "")
                        {
                            message = Console.ReadLine()?.Trim() ?? string.Empty;
                        }
                        //calling the services to send notification
                        SMSService smsService = new SMSService();
                        smsService.Send(message, user);
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