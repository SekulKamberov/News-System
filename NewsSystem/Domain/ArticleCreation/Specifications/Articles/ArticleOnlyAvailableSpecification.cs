namespace NewsSystem.Domain.ArticleCreation.Specifications.Articles
{
    using System;
    using System.Linq.Expressions;

    using Common; 
    using Domain.ArticleCreation.Models.Articles;

    public class ArticleOnlyAvailableSpecification : Specification<Article>
    {
        private readonly bool onlyAvailable;

        public ArticleOnlyAvailableSpecification(bool onlyAvailable) 
            => this.onlyAvailable = onlyAvailable;

        public override Expression<Func<Article, bool>> ToExpression()
        {
            //if (this.onlyAvailable)
            //{
            //    return article => article.IsAvailable;
            //}

            return article => true;
        }
    }
}
