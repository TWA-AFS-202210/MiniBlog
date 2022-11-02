using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Services;

public class UserService 
{
    private readonly IArticleStore _articleStore;
    private readonly IUserStore _userStore;

    public UserService(IUserStore userStore, IArticleStore articleStore)
    {
        _userStore = userStore;
        _articleStore = articleStore;
    }

    public User? RegisterUser(User user)
    {
        if (!_userStore.GetAll().Exists(_ => user.Name.ToLower() == _.Name.ToLower()))
        {
            _userStore.Save(user);
            return user;
        }

        return null;
    }

    public List<User> GetAllUsers()
    {
        return _userStore.GetAll();
    }

    public User? UpdateUser(User user)
    {
        var foundUser = _userStore.GetAll().FirstOrDefault(_ => _.Name == user.Name);
        if (foundUser != null)
        {
            foundUser.Email = user.Email;
        }

        return foundUser;
    }

    public bool DeleteUser(string name)
    {
        var foundUser = _userStore.GetAll().FirstOrDefault(_ => _.Name == name);
        if (foundUser != null)
        {
            _userStore.Delete(foundUser);
            var articles = _articleStore.GetAll()
                .Where(article => article.UserName == foundUser.Name)
                .ToList();
            articles.ForEach(article => _articleStore.Delete(article));
            return true;
        }

        return false;
    }

    public User? GetUserByName(string name)
    {
        return _userStore.GetAll()
            .FirstOrDefault(_ => string.Equals(_.Name, name, StringComparison.CurrentCultureIgnoreCase));
    }
}
