namespace NotificationApp.Models;

internal class User
{
    public string Name {get;set;}
    public string Email {get;set;}
    public string PhoneNumber{get;set;}

    public User()
    {
        
    }
    public User(string name,string email,string phonenumber)
    {
        Name = name;
        Email = email;
        PhoneNumber = phonenumber;
    }

    public override string ToString()
    {
        return $"Name : {Name}\nEmail : {Email}\nPhoneNumber : {PhoneNumber}";
    }
}