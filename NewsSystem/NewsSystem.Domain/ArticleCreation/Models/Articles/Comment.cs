namespace NewsSystem.Domain.ArticleCreation.Models.Articles
{
    using NewsSystem.Domain.Common.Models;

    public class Comment : Entity<int>
    {
        internal Comment(
           string title,
           string content,
           string createdBy,
           int articleId) 
        {
            this.Title = title;
            this.Content = content;
            this.CreatedBy = createdBy;
            this.ArticleId = articleId;
        }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public string CreatedBy { get; private set; }

        public int ArticleId { get; private set; }
    }
}
