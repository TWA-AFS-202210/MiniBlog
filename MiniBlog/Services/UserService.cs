using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Services
{
    public class UserService
    {
        private IArticleStore _articleStore;
        private IUserStore _userStore;

        public UserService(IArticleStore articleStore, IUserStore userStore)
        {
            _articleStore = articleStore;
            _userStore = userStore;
        }
        public User Register(User user)
        {
            if (!_userStore.GetAll().Exists(_ => user.Name.ToLower() == _.Name.ToLower()))
            {
                _userStore.Save(user);
            }

            return user;
        }
        public List<User> GetAll()
        {
            return _userStore.GetAll();
        }
        public User Update(User user)
        {
            var foundUser = _userStore.GetAll().FirstOrDefault(_ => _.Name == user.Name);
            if (foundUser != null)
            {
                foundUser.Email = user.Email;
            }

            return foundUser;
        }
    }
}
