namespace NewsSystem.Domain.ArticleCreation.Models.Articles
{
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using Exceptions;
    using Domain.Common.Models;

    public class Article : Entity<int>, IAggregateRoot
    {
        private static readonly IEnumerable<Category> AllowedCategories
            = new CategoryData().GetData().Cast<Category>();

        private readonly HashSet<Comment> comments;
        private readonly HashSet<SubComment> subComments;

        internal Article(
            string title,
            string content,
            Category category,
            string imageUrl,
            int journalistId
            )
        {
            this.Validate(title, imageUrl, content);
            this.ValidateCategory(category);

            this.Title = title;
            this.Content = content;
            this.Category = category;
            this.ImageUrl = imageUrl;
            this.JournalistId = journalistId;

            this.comments = new HashSet<Comment>();
            this.subComments = new HashSet<SubComment>();
        }

        private Article(
            string title,
            string content,
            string imageUrl,
            int journalistId
            )
        {
            this.Title = title;
            this.Content = content;
            this.ImageUrl = imageUrl;
            this.JournalistId = journalistId;

            this.Category = default!;

            this.comments = new HashSet<Comment>();
            this.subComments = new HashSet<SubComment>();
        }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public Category Category { get; private set; }

        public string ImageUrl { get; private set; }

        public int JournalistId { get; private set; }

        public IReadOnlyCollection<Comment> Comments => this.comments.ToList().AsReadOnly();
        public IReadOnlyCollection<SubComment> SubComments => this.subComments.ToList().AsReadOnly(); //1.

        public void AddComment(string title, string content, string createdBy, int articleId)
        {
            this.comments.Add(new Comment(title, content, createdBy, articleId));

            //TO DO this.AddEvent(new CommentAddedEvent());
        }

        public void AddSubComment(string title, string content, string createdBy, int articleId, int commentId)
        {
            this.subComments.Add(new SubComment(title, content, createdBy, articleId, commentId));

            //TO DO this.AddEvent(new CommentAddedEvent());
        }

        public Article UpdateTitle(string title)
        {
            this.ValidateTitle(title);
            this.Title = title;

            return this;
        }

        public Article UpdateContent(string content)
        {
            this.ValidateContent(content);
            this.Content = content;

            return this;
        }

        public Article UpdateImageUrl(string imageUrl)
        {
            this.ValidateImageUrl(imageUrl);
            this.ImageUrl = imageUrl;

            return this;
        }

        public Article UpdateCategory(Category category)
        {
            this.ValidateCategory(category);
            this.Category = category;

            return this;
        }

        private void Validate(string title, string content, string imageUrl)
        {
            this.ValidateTitle(title);
            this.ValidateContent(content);
            this.ValidateImageUrl(imageUrl);
        }

        private void ValidateTitle(string title)
            => Guard.ForStringLength<InvalidArticleException>(
                title,
                ModelConstants.Article.MinTitleLength,
                ModelConstants.Article.MaxTitleLength,
                nameof(this.Title));

        private void ValidateContent(string content)
            => Guard.ForStringLength<InvalidArticleException>(
                content,
                ModelConstants.Article.MinContentLength,
                ModelConstants.Article.MaxContentLength,
                nameof(this.Content));

        private void ValidateImageUrl(string imageUrl)
            => Guard.ForValidUrl<InvalidArticleException>(
                imageUrl,
                nameof(this.ImageUrl));

        private void ValidateCategory(Category category)
        {
            var categoryName = category?.Name;

            if (AllowedCategories.Any(c => c.Name == categoryName))
            {
                return;
            }

            var allowedCategoryNames = string.Join(", ", AllowedCategories.Select(c => $"'{c.Name}'"));

            throw new InvalidArticleException($"'{categoryName}' is not a valid category. Allowed values are: {allowedCategoryNames}.");
        }
    }
}
