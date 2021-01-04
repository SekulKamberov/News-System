namespace NewsSystem.Domain.ArticleCreation.Models.Journalists
{
    using System.Collections.Generic;
    using System.Linq;

    using Bogus;

    using Common.Models;
    using static Articles.ArticleFakes.Data;

    public class JournalistFakes
    {
        public static class Data
        {
            public static IEnumerable<Journalist> GetJournalists(int count = 10)
                => Enumerable
                    .Range(1, count)
                    .Select(GetJournalist)
                    .ToList();

            public static Journalist GetJournalist(int id = 1, int totalArticles = 10)
            {
                var journalist = new Faker<Journalist>()
                    .CustomInstantiator(f => new Journalist(
                        $"UserId{id}",
                        f.Name.FirstName(),
                        f.Phone.PhoneNumber("+########"),
                        f.Address.FullAddress()))
                    .Generate()
                    .SetId(id);

                foreach (var article in GetArticles().Take(totalArticles))
                {
                    journalist.AddArticle(article);
                }

                return journalist;
            }
        }
    }
}
