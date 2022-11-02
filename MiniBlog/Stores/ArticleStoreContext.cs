using MiniBlog.Model;

namespace MiniBlog.Stores
{
    public class ArticleStoreContext : IArticleStore
    {
        private List<Article> articles = new List<Article>();
        public bool Delete(Article article)
        {
            try
            {
                this.articles.Remove(article);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Article> GetAll()
        {
            return this.articles;
        }

        public Article Save(Article article)
        {
            articles.Add(article);
            return article;
        }
    }
}
