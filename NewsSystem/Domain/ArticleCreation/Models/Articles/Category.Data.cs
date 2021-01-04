namespace NewsSystem.Domain.ArticleCreation.Models.Articles
{
    using System;
    using System.Collections.Generic;
    using Common;

    internal class CategoryData : IInitialData
    {
        public Type EntityType => typeof(Category);

        public IEnumerable<object> GetData()
            => new List<Category>
            {
                new Category("Business", "Business is a financial news and information website."),
                new Category("Crimes", "Latest news on crime, corruption, scandals, and more."),
                new Category("Political", "Political News, Analysis and Opinion."),
                new Category("World", "International news, Breaking news, features and analysis from."),
            };
    }
}
