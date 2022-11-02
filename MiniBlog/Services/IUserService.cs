using MiniBlog.Model;

namespace MiniBlog.Services;

public interface IUserService
{
    User? RegisterUser(User user);
    List<User> GetAllUsers();
    User? UpdateUser(User user);
    void DeleteUser(string name);
    User? GetUserByName(string name);
}