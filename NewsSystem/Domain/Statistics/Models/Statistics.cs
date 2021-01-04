namespace NewsSystem.Domain.Statistics.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Common;

    public class Statistics : IAggregateRoot
    {
        private readonly HashSet<ArticleView> articleViews;

        internal Statistics()
        {
            this.TotalArticles = 0;

            this.articleViews = new HashSet<ArticleView>();
        }

        public int TotalArticles { get; private set; }

        public IReadOnlyCollection<ArticleView> ArticleViews
            => this.articleViews.ToList().AsReadOnly();

        public void AddArticle()
            => this.TotalArticles++;

        public void AddArticleView(int аrticleId, string? userId)
            => this.articleViews.Add(new ArticleView(аrticleId, userId));
    }
}
