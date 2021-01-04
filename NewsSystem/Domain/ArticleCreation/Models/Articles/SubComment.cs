namespace NewsSystem.Domain.ArticleCreation.Models.Articles
{
    using Domain.ArticleCreation.Exceptions;
    using Domain.Common.Models;

    public class SubComment : Entity<int>
    {
        internal SubComment(
            string title,
            string content,
            string createdBy,
            int articleId,
            int commentId
            )
        {
            this.Validate(title, content);

            this.Title = title;
            this.Content = content;
            this.CreatedBy = createdBy;
            this.ArticleId = articleId;
            this.CommentId = commentId;
        }
        private SubComment(

            string content,
            string createdBy,
            int articleId,
            int commentId
            )
        {
            this.Title = default!;
            this.Content = content;
            this.CreatedBy = createdBy;
            this.ArticleId = articleId;
            this.CommentId = commentId;
        }

        public string Title { get; private set; } = default!;

        public string Content { get; private set; } = default!;

        public string CreatedBy { get; private set; } = default!;

        public int CommentId { get; set; }

        public Comment Comment { get; set; } = default!;

        public int ArticleId { get; private set; }

        public Article Article { get; private set; } = default!;

        private void Validate(string title, string content)
        {
            this.ValidateTitle(title);
            this.ValidateContent(content); 
        }

        private void ValidateTitle(string title)
            => Guard.ForStringLength<InvalidSubCommentException>(
                title,
                ModelConstants.SubComment.MinTitleLength,
                ModelConstants.SubComment.MaxTitleLength,
                nameof(this.Title));

        private void ValidateContent(string content)
            => Guard.ForStringLength<InvalidSubCommentException>(
                content,
                ModelConstants.SubComment.MinContentLength,
                ModelConstants.SubComment.MaxContentLength,
                nameof(this.Content));
    }
}
