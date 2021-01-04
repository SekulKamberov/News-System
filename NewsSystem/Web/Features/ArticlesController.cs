namespace NewsSystem.Web.Features
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Application.Common;
    using Application.ArticleCreation.Articles.Commands.Create;
    using Application.ArticleCreation.Articles.Commands.Delete;
    using Application.ArticleCreation.Articles.Commands.Edit;
    using Application.ArticleCreation.Articles.Queries.Categories;
    using Application.ArticleCreation.Articles.Queries.Details;
    using Application.ArticleCreation.Articles.Queries.Search;

    public class ArticlesController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<SearchArticlesOutputModel>> Search(
            [FromQuery] SearchArticlesQuery query)
            => await this.Send(query);

        [HttpGet]
        [Route(Id)]
        [Authorize]
        public async Task<ActionResult<ArticleDetailsOutputModel>> Details(
            [FromRoute] ArticleDetailsQuery query)
            => await this.Send(query);


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateArticleOutputModel>> Create(
            CreateArticleCommand command)
            => await this.Send(command);

        [HttpPost]
        [Route("Comment")]
        [Authorize]
        public async Task<ActionResult<CreateCommentOutputModel>> CreateComment(
            CreateCommentCommand command)
            => await this.Send(command);

        [HttpPost]
        [Route("Subcomment")]
        [Authorize]
        public async Task<ActionResult<CreateCommentOutputModel>> SubComment(
            CreateSubCommentCommand command)
            => await this.Send(command);

        [HttpPut]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Edit(
            int id, EditArticleCommand command)
            => await this.Send(command.SetId(id));

        [HttpDelete]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Delete(
            [FromRoute] DeleteArticleCommand command)
            => await this.Send(command);
        
        [HttpGet]
        [Route(nameof(Categories))]
        public async Task<ActionResult<IEnumerable<GetArticleCategoryOutputModel>>> Categories(
            [FromQuery] GetArticleCategoriesQuery query)
            => await this.Send(query);
    }
}
