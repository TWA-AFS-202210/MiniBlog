using MiniBlog.Model;

namespace MiniBlog.Services;

public interface IArticleService
{
    List<Article> GetAllArticles();
    Article? CreateArticle(Article article);
    Article GetArticle(Guid id);
}