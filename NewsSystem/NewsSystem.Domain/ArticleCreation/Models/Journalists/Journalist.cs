namespace NewsSystem.ArticleCreation.Models.Journalists
{
    using System.Collections.Generic;
     
    using NewsSystem.Domain.Common;
    using NewsSystem.Domain.Common.Models;
    using NewsSystem.Domain.ArticleCreation.Models.Articles;

    public class Journalist : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Article> articles;

        internal Journalist(
            string userId,
            string nickName
            ) 
        {
            this.UserId = userId;
            this.NickName = nickName;
            
            
        }

        public string UserId { get; set; }

        public string NickName { get; private set; }
    }
}
