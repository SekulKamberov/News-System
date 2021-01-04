namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Search
{
    using System.Collections.Generic;
    using Common;

    public class SearchArticlesOutputModel : ArticlesOutputModel<ArticleOutputModel>
    {
        public SearchArticlesOutputModel(
            IEnumerable<ArticleOutputModel> carAds, 
            int page, 
            int totalPages) 
            : base(carAds, page, totalPages)
        {
        }
    }
}
