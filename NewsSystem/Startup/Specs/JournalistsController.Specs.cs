namespace NewsSystem.Startup.Specs
{
    using MyTested.AspNetCore.Mvc;

    using Xunit; 

    using Web;
    using Web.Features;
    using NewsSystem.Application.ArticleCreation.Journalists.Queries.Details;

    public class JournalistsControllerSpecs
    {
        [Fact]
        public void DetailsShouldHaveCorrectAttributes()
            => MyController<JournalistsController>
                .Calling(c => c.Details(With.Default<JournalistDetailsQuery>()))

                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Get)
                    .SpecifyingRoute(ApiController.Id));
    }
}
