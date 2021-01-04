namespace NewsSystem.Domain.ArticleCreation.Specifications.Journalists
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Models.Journalists; 

    public class JournalistByNickNameSpecification : Specification<Journalist>
    {
        private readonly string? nickName;

        public JournalistByNickNameSpecification(string? nickName) 
            => this.nickName = nickName;

        protected override bool Include => this.nickName != null;

        public override Expression<Func<Journalist, bool>> ToExpression()
            => journalist => journalist.NickName.ToLower().Contains(this.nickName!.ToLower());
    }
}
