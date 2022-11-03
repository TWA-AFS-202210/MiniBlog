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
        private ArticleService articleService;
        public ArticleController(ArticleService articleService)
        {
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
            var newArticle = articleService.Create(article);

            return Created("", newArticle);
        }

        [HttpGet("{id}")]
        public ActionResult<Article> GetById(Guid id)
        {
            return articleService.GetById(id);
        }
    }
}