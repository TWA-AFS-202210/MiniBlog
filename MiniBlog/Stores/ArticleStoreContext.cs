using MiniBlog.Model;

namespace MiniBlog.Stores
{
    public class ArticleStoreContext : IArticleStore
    {
        private List<Article> articles = new List<Article>();
        public Article Save(Article article)
        {
            this.articles.Add(article);
            return article;
        }

        public List<Article> GetAll()
        {
            return this.articles;
        }

        public bool Delete(Article articles)
        {
            return this.articles.Remove(articles);
        }
    }
}
