namespace NewsSystem.Domain.ArticleCreation.Models.Articles
{
    using Common.Models;  
    using static ModelConstants.Category;
    using Domain.ArticleCreation.Models;
    using Domain.ArticleCreation.Exceptions;

    public class Category : Entity<int>
    {
        internal Category(string name, string description)
        {
            this.Validate(name, description);

            this.Name = name;
            this.Description = description;
        }

        public string Name { get; }

        public string Description { get; }

        private void Validate(string name, string description)
        {
            Guard.ForStringLength<InvalidArticleException>(
                name,
                ModelConstants.Category.MinNameLength,
                ModelConstants.Category.MaxNameLength,
                nameof(this.Name));

            Guard.ForStringLength<InvalidArticleException>(
                description,
                MinDescriptionLength,
                MaxDescriptionLength,
                nameof(this.Description));
        }
    }
}
