namespace NewsSystem.Domain.ArticleCreation.Models.Articles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Bogus;
    using FakeItEasy;

    using Common.Models;

    public class ArticleFakes
    {
        public class ArticleDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Article);

            public object? Create(Type type) => Data.GetArticle();

            public Priority Priority => Priority.Default;
        }

        public static class Data
        {
            public static IEnumerable<Article> GetArticles(int count = 10)
                => Enumerable
                    .Range(1, count)
                    .Select(i => GetArticle(i))
                    .Concat(Enumerable
                        .Range(count + 1, count * 2)
                        .Select(i => GetArticle(i, false)))
                    .ToList();

            public static Article GetArticle(int id = 1, bool isAvailable = true)
                => new Faker<Article>()
                    .CustomInstantiator(f => new Article(
                        f.Lorem.Letter(60),
                        f.Lorem.Text(),
                        A.Dummy<Category>(), // new Comment($"Title{id}", $"Content{id}", $"CreatedBy{id}", id),
                        f.Image.PicsumUrl(),
                        f.Random.Int()
                        ))
                    .Generate()
                    .SetId(id);
        }
    }
}
