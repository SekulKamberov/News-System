namespace NewsSystem.Domain.ArticleCreation.Models.Articles
{
    using NewsSystem.Domain.ArticleCreation.Exceptions;
    using NewsSystem.Domain.Common.Models;

    public class Category : Entity<int>
    {
        public Category(string name, string description)
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
                ModelConstants.Category.MinDescriptionLength,
                ModelConstants.Category.MaxDescriptionLength,
                nameof(this.Name));
        }
    }
}
