namespace NewsSystem.Domain.ArticleCreation.Specifications.Journalists
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Models.Journalists; 

    public class JournalistByIdSpecification : Specification<Journalist>
    {
        private readonly int? id;

        public JournalistByIdSpecification(int? id)
            => this.id = id;

        protected override bool Include => this.id != null;

        public override Expression<Func<Journalist, bool>> ToExpression()
            => journalist => journalist.Id == this.id;
    }
}
