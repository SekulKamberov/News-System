namespace NewsSystem.Domain.ArticleCreation.Models.Articles
{
    using System;
    using System.Collections.Generic;

    using NewsSystem.Domain.Common;

    internal class CategoryData : IInitialData
    {
        public Type EntityType => typeof(Category);

        public IEnumerable<object> GetData()
            => new List<Category>
            {
                new Category("Business", "Financial news and WWW information."),
                new Category("Crimes", "Crimes news and WWW Crimes information."),
                new Category("Political", "Political news and WWW Political information."),
                new Category("World", "World news and WWW World information."),
            };
    }
}
