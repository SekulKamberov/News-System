//namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Mine
//{
//    using System.Threading;
//    using System.Threading.Tasks;

//    using MediatR;

//    using Application.Common.Contracts;
//    using Common;
//    using Journalists;

//    public class MineArticlesQuery : ArticlesQuery, IRequest<MineArticlesOutputModel>
//    {
//        public class MineArticlesQueryHandler : ArticlesQueryHandler, IRequestHandler<
//            MineArticlesQuery,
//            MineArticlesOutputModel>
//        {
//            private readonly IJournalistRepository journalistRepository;
//            private readonly ICurrentUser currentUser;

//            public MineArticlesQueryHandler(
//                IArticleRepository articleRepository, 
//                IJournalistRepository journalistRepository,
//                ICurrentUser currentUser)
//                : base(articleRepository)
//            {
//                this.currentUser = currentUser;
//                this.journalistRepository = journalistRepository;
//            }

//            public async Task<MineArticlesOutputModel> Handle(
//                MineArticlesQuery request,
//                CancellationToken cancellationToken)
//            {
//                var journalistId = await this.journalistRepository.GetJournalistId(
//                    this.currentUser.UserId, 
//                    cancellationToken);

//                var mineArticleListings = await base.GetArticleListings<MineArticleOutputModel>(
//                    request,
//                    onlyAvailable: false,
//                    journalistId,
//                    cancellationToken);

//                var totalPages = await base.GetTotalPages(
//                    request,
//                    onlyAvailable: false,
//                    journalistId,
//                    cancellationToken);

//                return new MineArticlesOutputModel(mineArticleListings, request.Page, totalPages);
//            }
//        }
//    }
//}
