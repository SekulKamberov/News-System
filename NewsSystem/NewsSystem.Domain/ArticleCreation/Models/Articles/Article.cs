namespace NewsSystem.Domain.ArticleCreation.Models.Articles
{
    using NewsSystem.Domain.ArticleCreation.Exceptions;
    using NewsSystem.Domain.Common;
    using NewsSystem.Domain.Common.Models;

    public class Article : Entity<int>, IAggregateRoot
    {
        internal Article(
            string title,
            string content,
            string imageUrl,
            int journalistId) 
        {
            Validate(title, content, imageUrl);
            this.Title = title;
            this.Content = content;
            this.ImageUrl = imageUrl;
            this.JournalistId = journalistId;
        }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public string ImageUrl { get; private set; }

        public int JournalistId { get; private set; }

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
                nameof(this.Title));

        private void ValidateImageUrl(string imageUrl)
            => Guard.ForValidUrl<InvalidArticleException>(
              imageUrl, 
              nameof(this.ImageUrl));

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

    }
}
