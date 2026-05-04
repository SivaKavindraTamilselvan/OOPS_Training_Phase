using NotificationApp.Models;
namespace NotificationApp.Interfaces;

internal interface IUserService
{
    internal User AddUser();
    internal User? GetUserByEmail(string email);
    internal User? GetUserByPhoneNumber(string phonenumber);
    internal void PrintAllUsers();
    internal User? DeleteUserByPhoneNumber(string phonenumber);
    internal User? DeleteUserByEmail(string email);

}