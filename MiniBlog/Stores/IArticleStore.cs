using MiniBlog.Model;

namespace MiniBlog.Stores
{
    public interface IArticleStore
    {
        bool Delete(Article articles);
        List<Article> GetAll();
        Article Save(Article article);
    }
}