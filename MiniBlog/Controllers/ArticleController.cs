using System.Reflection.Metadata.Ecma335;
using MiniBlog.Services;

namespace MiniBlog.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using MiniBlog.Model;
    using MiniBlog.Stores;

    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private IArticleStore _articleStore;
        private IUserStore _userStore;
        private IArticleService _articleService;
        private IUserService _userService;

        public ArticleController(IArticleStore articleStore, IUserStore userStore, IArticleService articleService,IUserService userService )
        {
            this._articleStore = articleStore;
            this._userStore = userStore;
            this._articleService = articleService;
            this._userService = userService;
        }

        [HttpGet]
        public ActionResult<List<Article>> List()
        {
            return Ok(this._articleService.GetAllArticles());
        }

        [HttpPost]
        public ActionResult<Article> Create(Article article)
        {
            var newArticle = _articleService.CreateArticle(article);
            return new CreatedResult($"/articles/{newArticle.Id}", newArticle);
        }

        [HttpGet("{id}")]
        public ActionResult<Article> GetById(Guid id)
        {
            try
            {
                var articleResult = _articleService.GetArticle(id);
                return Ok(articleResult);
            }

            catch (NullReferenceException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}