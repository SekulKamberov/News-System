namespace NewsSystem.Domain.ArticleCreation.Models.Journalists
{
    using System.Collections.Generic;
    using System.Linq;

    using Common;

    using Exceptions;

    using Domain.Common.Models;
    using Domain.ArticleCreation.Models.Articles;

    public class Journalist : Entity<int>, IAggregateRoot
    {
        private static readonly IEnumerable<Category> AllowedCategories
            = new CategoryData().GetData().Cast<Category>();

        private readonly HashSet<Article> articles;

        internal Journalist(
            string userId, 
            string nickName,
            Address address,
            PhoneNumber phoneNumber
            )
        {
            this.Validate(nickName);

            this.UserId = userId;
            this.NickName = nickName;
            this.Address = address;
            this.PhoneNumber = phoneNumber;

            this.articles = new HashSet<Article>();
        }

        private Journalist(string userId)
        {
            this.UserId = userId;
            this.NickName = default!;
            this.Address = default!;
            this.PhoneNumber = default!;

            this.articles = new HashSet<Article>();
        }

        public string UserId { get; }

        public string NickName { get; private set; }

        public Address Address { get; }

        public PhoneNumber PhoneNumber { get; }

        public Journalist UpdateName(string nickName)
        {
            this.Validate(nickName);
            this.NickName = nickName;

            return this;
        }

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
