namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Mine
{
    using System.Collections.Generic;
    using Common;

    public class MineArticlesOutputModel : ArticlesOutputModel<MineArticleOutputModel>
    {
        public MineArticlesOutputModel(
            IEnumerable<MineArticleOutputModel> carAds, 
            int page, 
            int totalPages) 
            : base(carAds, page, totalPages)
        {
        }
    }
}
