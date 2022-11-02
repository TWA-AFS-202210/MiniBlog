using MiniBlog.Model;

namespace MiniBlog.Stores;

public interface IUserStore
{
    List<User> GetAll();
    User Save(User user);
    bool Delete(User user);
}