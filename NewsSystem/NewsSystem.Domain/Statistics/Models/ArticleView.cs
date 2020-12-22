namespace NewsSystem.Domain.Statistics.Models
{
    using NewsSystem.Domain.Common.Models;

    public class ArticleView : Entity<int>
    {
        internal ArticleView(int articleId, string? userId)
        {
            this.ArticleId = articleId;
            this.UserId = userId; 
        }

        public int ArticleId { get; }

        public string? UserId { get; }
    }
}
