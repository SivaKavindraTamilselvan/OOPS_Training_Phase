using NotificationApp.Models;
namespace NotificationApp.Interfaces;

internal interface IUserService
{
    public User AddUser();
    
    public User? GetUserByEmail(string email);
    public User? GetUserById(int id);
    public User? DeleteUserById(int id);
    public User? GetUserByPhoneNumber(string phonenumber);
    public void PrintAllUsers();
    public User? DeleteUserByPhoneNumber(string phonenumber);
    public User? DeleteUserByEmail(string email);
    public bool CheckUser(User user);

}