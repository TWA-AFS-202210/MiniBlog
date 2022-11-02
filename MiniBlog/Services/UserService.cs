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
    }
}
