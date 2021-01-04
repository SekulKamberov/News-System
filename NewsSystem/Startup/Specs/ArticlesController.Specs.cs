namespace NewsSystem.Startup.Specs
{
    using System.Linq;

    using Xunit;
    using MyTested.AspNetCore.Mvc;
    using FluentAssertions;

    using Application.ArticleCreation.Articles.Queries.Search;
    using Domain.ArticleCreation.Models.Journalists;
    using Web.Features;

    public class ArticlesControllerSpecs
    {
        [Fact]
        public void SearchShouldHaveCorrectAttributes()
            => MyController<ArticlesController>
                .Calling(c => c.Search(With.Default<SearchArticlesQuery>()))

                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Get));

        [Theory]
        [InlineData(2)]
        public void SearchShouldReturnAllArticlesWithoutAQuery(int totalArticles)
            => MyPipeline
                .Configuration()
                .ShouldMap("/Articles")

                .To<ArticlesController>(c => c.Search(With.Empty<SearchArticlesQuery>()))
                .Which(instance => instance
                    .WithData(JournalistFakes.Data.GetJournalist(totalArticles: totalArticles)))

                .ShouldReturn()
                .ActionResult<SearchArticlesOutputModel>(result => result
                    .Passing(model => model
                        .Articles.Count().Should().Be(totalArticles)));

        [Fact]
        public void SearchShouldReturnAvailableArticlesWithoutAQuery()
            => MyPipeline
                .Configuration()
                .ShouldMap("/Articles")

                .To<ArticlesController>(c => c.Search(With.Empty<SearchArticlesQuery>()))
                .Which(instance => instance
                    .WithData(JournalistFakes.Data.GetJournalist()))

                .ShouldReturn()
                .ActionResult<SearchArticlesOutputModel>(result => result
                    .Passing(model => model
                        .Articles.Count().Should().Be(10)));
    }
}
