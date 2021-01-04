//namespace NewsSystem.Application.ArticleCreation.Articles.Commands.Common
//{
//    using System.Threading;
//    using System.Threading.Tasks;
//    using Application.Common;
//    using Application.Common.Contracts;
//    using Journalists;

//    internal static class ChangeArticleCommandExtensions
//    {
//        public static async Task<Result> JournalistHasArticle(
//            this ICurrentUser currentUser,
//            IJournalistRepository journalistRepository,
//            int articleId,
//            CancellationToken cancellationToken)
//        {
//            var journalistId = await journalistRepository.GetJournalistId(
//                currentUser.UserId,
//                cancellationToken);

//            var journalistHasArticle = await journalistRepository.HasArticle(
//                journalistId,
//                articleId,
//                cancellationToken);

//            return journalistHasArticle
//                ? Result.Success
//                : "You cannot edit this Article.";
//        }
//    }
//}
