namespace NewsSystem.Domain.ArticleCreation.Models.Articles
{
    using NewsSystem.Domain.ArticleCreation.Exceptions;
    using NewsSystem.Domain.Common.Models;

    public class Comment : Entity<int>
    {
        internal Comment(
           string title,
           string content,
           string createdBy,
           int articleId) 
        {
            this.Validate(title, content, createdBy, articleId);

            this.Title = title;
            this.Content = content;
            this.CreatedBy = createdBy;
            this.ArticleId = articleId;
        }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public string CreatedBy { get; private set; }

        public int ArticleId { get; private set; }

        public Article Article { get; private set; }

        public Comment UpdateComment(string title, string content, string createdBy, int articleId, int commentId)
        {
            this.Title = title;
            this.Content = content;
            this.CreatedBy = createdBy;
            this.ArticleId = articleId;

            return this;
        }

        private void Validate(string title, string content, string categoryBy, int articleId)
        {
            this.ValidateTitle(title);
            this.ValidateContent(content);
            this.ValidateCreatedBy(categoryBy);
            this.ValidateArticleId(articleId);
        }

        private void ValidateTitle(string title)
            => Guard.ForStringLength<InvalidCommentException>(
                title,
                ModelConstants.Comment.MinTitleLength,
                ModelConstants.Comment.MaxTitleLength,
                nameof(this.Title));

        private void ValidateContent(string content)
            => Guard.ForStringLength<InvalidCommentException>(
                content,
                ModelConstants.Comment.MinContentLength,
                ModelConstants.Comment.MaxContentLength,
                nameof(this.Content));

        private void ValidateCreatedBy(string createdBy)
            => Guard.AgainstEmptyString<InvalidCommentException>(
                createdBy,
                nameof(this.CreatedBy));

        private void ValidateArticleId(int articleId)
            => Guard.AgainstOutOfRange<InvalidCommentException>(
                articleId,
                ModelConstants.Common.Zero,
                int.MaxValue,
                nameof(this.ArticleId));
    }
}
