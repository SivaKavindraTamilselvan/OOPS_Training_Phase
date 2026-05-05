using NotificationApp.Models;
using NotificationApp.Validation;
using NotificationApp.Interfaces;

namespace NotificationApp.Services;

internal class UserService : IUserService
{
    static List<User> users = new List<User>();
    EmailService emailService = new EmailService();
    SMSService smsService = new SMSService();

    public User AddUser()
    {
        User user = new User();
        Console.WriteLine("Enter Your Name");

        string name = Console.ReadLine() ?? "";
        //loop until the user name is not whitespace
        while(name.Trim() == "")
        {
            Console.WriteLine("Inavlid Name.Name Should Not be Empty.Enter Valid Name");
            name = Console.ReadLine() ?? "";
        }

        Console.WriteLine("Enter Your Email");
        string email = Console.ReadLine() ?? "";
        //loop until valid email is entered
        while(!EmailValidation.isValidEmail(email))
        {
            Console.WriteLine("Invalid Email Entered.Enter Vaild Email Address");
            email = Console.ReadLine() ?? "";
        }

        Console.WriteLine("Enter Your PhoneNumber");

        string phone = Console.ReadLine() ?? "";
        //loop until the phone number is valid entered
        while (!PhoneNumberValidation.isValidPhoneNumber(phone))
        {
            Console.WriteLine("Invalid Phone Number Entered.Enter Valid PhoneNumber");
            phone = Console.ReadLine() ?? "";
        }
        user.Name = name;
        user.Email = email;
        user.PhoneNumber = phone;

        //user added in the static variable
        users.Add(user);
        Console.WriteLine("User Added Successfully");

        //email sent to the user added
        string message = $"Successfully created an account with the details\nName : {name}\nPhoneNumber : {phone}\nEmail : {email}\n\nThank You!";
        emailService.Send(message,user);
        smsService.Send(message,user);

        return user;
    }

    //get the user by email if not found null will be returned
    public User? GetUserByEmail(string email)
    {
        foreach(var item in users)
        {
            if(item.Email == email)
            {
                return item;
            }
        }
        return null;
    }

    //get the user by phone number if not found null will be returned
    public User? GetUserByPhoneNumber(string phonenumber)
    {
        foreach(var item in users)
        {
            if(item.PhoneNumber == phonenumber)
            {
                return item;
            }
        }
        return null;
    }

    //print all the registered users
    public void PrintAllUsers()
    {
        foreach(var item in users)
        {
            Console.WriteLine(item);
        }
    }

    //delete the users if user not found null will be returned
    public User? DeleteUserByEmail(string email)
    {
        foreach(var item in users)
        {
            if(item.Email == email)
            {
                users.Remove(item);
                string message = $"Successfully deleted your account with the details\nName : {item.Name}\nPhoneNumber : {item.PhoneNumber}\nEmail : {item.Email}\n\nThank You!";
                emailService.Send(message,item);
                smsService.Send(message,item);
                return item;
            }
        }
        return null;
    }

    //delete the users if user not found null will be returned
    public User? DeleteUserByPhoneNumber(string phonenumber)
    {
        foreach(var item in users)
        {
            if(item.PhoneNumber == phonenumber)
            {
                users.Remove(item);
                string message = $"Successfully deleted your account with the details\nName : {item.Name}\nPhoneNumber : {item.PhoneNumber}\nEmail : {item.Email}\n\nThank You!";
                emailService.Send(message,item);
                smsService.Send(message,item);
                return item;
            }
        }
        return null;
    }

    //check user if the user is registerd by comparing the object used in email and sms check
    public bool CheckUser(User user)
    {
        foreach(var item in users)
        {
            if(item == user)
            {
                return true;
            }
        }
        return false;
    }
}
