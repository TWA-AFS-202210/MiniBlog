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
        private IArticleStore articleStore;
        private IUserStore userStore;
        private ArticleService articleService;
        public ArticleController(IArticleStore articleStore,IUserStore userStore, ArticleService articleService)
        {
            this.articleStore = articleStore;
            this.userStore = userStore;
            this.articleService = articleService;
        }
        [HttpGet]
        public ActionResult<List<Article>> List()
        {
            return articleService.List();
        }

        [HttpPost]
        public ActionResult<Article> Create(Article article)
        {
            var articleId = articleService.Create(article);

            return Created("", article);
        }

        [HttpGet("{id}")]
        public ActionResult<Article> GetById(Guid id)
        {
            return articleService.GetById(id);
        }
    }
}