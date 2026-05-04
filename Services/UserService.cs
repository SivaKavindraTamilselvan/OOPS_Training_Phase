using NotificationApp.Models;
using NotificationApp.Validation;
using NotificationApp.Interfaces;

namespace NotificationApp.Services;

internal class UserService : IUserService
{
    List<User> users = new List<User>();

    public User AddUser()
    {
        User user = new User();
        Console.WriteLine("Enter Your Name");

        string name = Console.ReadLine() ?? "";
        while(name.Trim() == "")
        {
            Console.WriteLine("Inavlid Name.Name Should Not be Empty.Enter Valid Name");
            name = Console.ReadLine() ?? "";
        }

        Console.WriteLine("Enter Your Email");

        string email = Console.ReadLine() ?? "";
        while(!EmailValidation.isValidEmail(email))
        {
            Console.WriteLine("Invalid Email Entered.Enter Vaild Email Address");
            email = Console.ReadLine() ?? "";
        }

        Console.WriteLine("Enter Your PhoneNumber");

        string phone = Console.ReadLine() ?? "";
        while (!PhoneNumberValidation.isValidPhoneNumber(phone))
        {
            Console.WriteLine("Invalid Phone Number Entered.Enter Valid PhoneNumber");
            phone = Console.ReadLine() ?? "";
        }
        user.Name = name;
        user.Email = email;
        user.PhoneNumber = phone;

        users.Add(user);
        Console.WriteLine("User Added Successfully");

        return user;
    }

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

    public void PrintAllUsers()
    {
        foreach(var item in users)
        {
            Console.WriteLine(item);
        }
    }

    public User? DeleteUserByEmail(string email)
    {
        foreach(var item in users)
        {
            if(item.Email == email)
            {
                users.Remove(item);
                return item;
            }
        }
        return null;
    }

    public User? DeleteUserByPhoneNumber(string phonenumber)
    {
        foreach(var item in users)
        {
            if(item.PhoneNumber == phonenumber)
            {
                users.Remove(item);
                return item;
            }
        }
        return null;
    }
}
