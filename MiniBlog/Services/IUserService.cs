using MiniBlog.Model;

namespace MiniBlog.Services;

public interface IUserService
{
    User? RegisterUser(User user);
    List<User> GetAllUsers();
    User? UpdateUser(User user);
    bool DeleteUser(string name);
    User? GetUserByName(string name);
}