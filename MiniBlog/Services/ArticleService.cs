using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Services
{
    public class ArticleService : IArticleService
    {
        private IArticleStore _articleStore;
        private IUserStore _userStore;

        public ArticleService(IArticleStore articleStore, IUserStore userStore)
        {
            this._articleStore = articleStore;
            this._userStore = userStore;
        }

        public List<Article> GetAllArticles()
        {
            return _articleStore.GetAll();
        }

        public Article? CreateArticle(Article article)
        {
            if (!string.IsNullOrEmpty(article.UserName))
            {
                if (!_userStore.GetAll().Exists(_ => article.UserName == _.Name))
                {
                    _userStore.Save(new User(article.UserName));
                }

                _articleStore.Save(article);
                return article;
            }

            return null;
        }

        public Article GetArticle(Guid id)
        {

            var foundArticle = _articleStore.GetAll().FirstOrDefault(article => article.Id == id);
            if (foundArticle != null)
            {
                return foundArticle;
            }

            throw new NullReferenceException("Article not found");
        }
    }
}
