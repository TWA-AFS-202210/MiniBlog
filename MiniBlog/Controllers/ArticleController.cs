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

        public ArticleController(IArticleStore articleStore, IUserStore userStore, IArticleService articleService, )
        {
            this._articleStore = articleStore;
            this._userStore = userStore;
            this._articleService = articleService;
        }

        [HttpGet]
        public List<Article> List()
        {
            return this._articleStore.GetAll();
        }

        [HttpPost]
        public ActionResult<Article> Create(Article article)
        {
            if (article.UserName != null)
            {
                if (!_userStore.GetAll().Exists(_ => article.UserName == _.Name))
                {
                    _userStore.Save(new User(article.UserName));
                }

                this._articleStore.Save(article);
            }

            return new CreatedResult($"/articles/{article.Id}", article);
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
                return NotFound();
            }
        }
    }
}