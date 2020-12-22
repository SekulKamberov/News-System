namespace NewsSystem.Domain.Statistics.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using NewsSystem.Domain.Common;

    public class Statisrics : IAggregateRoot
    {
        private readonly HashSet<ArticleView> articleViews;

        internal Statisrics()
        {
            this.TotalArticles = 0;
            this.articleViews = new HashSet<ArticleView>();
        }

        public int TotalArticles { get; private set; }

        public IReadOnlyCollection<ArticleView> ArticleViews
            => this.articleViews.ToList().AsReadOnly();

        public void AddArticles()
            => this.TotalArticles++;

        public void AddArticleViews(int articleId, string? userrId)
            => this.articleViews.Add(new ArticleView(articleId, userrId));      
    }
}
