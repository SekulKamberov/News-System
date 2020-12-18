namespace NewsSystem.Domain.ArticleCreation.Models.Articles
{
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
            this.Title = title;
            this.Content = content;
            this.ImageUrl = imageUrl;
            this.JournalistId = journalistId;
        }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public string ImageUrl { get; private set; }

        public int JournalistId { get; private set; }

        

    }
}
