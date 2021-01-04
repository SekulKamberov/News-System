namespace NewsSystem.Web.Features
{
    using System.Threading.Tasks;
    using Application.Common;
   // using Application.ArticleCreation.Journalists.Commands.Edit;
    using Application.ArticleCreation.Journalists.Queries.Details;
    using Microsoft.AspNetCore.Mvc;

    public class JournalistsController : ApiController
    {

 

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<JournalistDetailsOutputModel>> Details(
            [FromRoute] JournalistDetailsQuery query)
            => await this.Send(query);

        //[HttpPut]
        //[Route(Id)]
        //public async Task<ActionResult> Edit(
        //    int id, EditJournalistCommand command)
        //    => await this.Send(command.SetId(id));
    }
}
