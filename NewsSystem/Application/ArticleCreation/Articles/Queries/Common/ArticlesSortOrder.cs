namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Common
{
    using System;
    using System.Linq.Expressions;

    using Application.Common;
    using Domain.ArticleCreation.Models.Articles;

    public class ArticlesSortOrder : SortOrder<Article>
    {
        public ArticlesSortOrder(string? sortBy, string? order)
            : base(sortBy, order)
        {
        }

        public override Expression<Func<Article, object>> ToExpression()
            => this.SortBy switch
            {
                "title" => article => article.Title,   
                "category" => article => article.Category.Name,   
                _ => article => article.Id
            };
    }
}
