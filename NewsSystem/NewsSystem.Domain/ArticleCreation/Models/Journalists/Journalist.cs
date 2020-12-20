namespace NewsSystem.ArticleCreation.Models.Journalists
{
    using System.Collections.Generic;
    using System.Linq;

    using NewsSystem.Domain.Common;
    using NewsSystem.Domain.Common.Models;
    using NewsSystem.Domain.ArticleCreation.Models.Articles;
    using NewsSystem.Domain.ArticleCreation.Exceptions;
    using NewsSystem.Domain.ArticleCreation.Models;

    public class Journalist : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Article> articles;

        internal Journalist(
            string userId,
            string nickName
            ) 
        {
            Validate(nickName);

            this.UserId = userId;
            this.NickName = nickName;

            this.articles = new HashSet<Article>();
        }

        public string UserId { get; set; }

        public string NickName { get; private set; }

        public IReadOnlyCollection<Article> Articles => this.articles.ToList().AsReadOnly();

        public void AddArticle(Article Article) => this.articles.Add(Article);

        private void Validate(string nickName)
            => Guard.ForStringLength<InvalidJournalistException>(
                nickName,
                ModelConstants.Journalist.MinNameLength,
                ModelConstants.Journalist.MaxNameLength,
                nameof(this.NickName));
    }
}
