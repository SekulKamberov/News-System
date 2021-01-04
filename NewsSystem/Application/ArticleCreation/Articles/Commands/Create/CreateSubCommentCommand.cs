namespace NewsSystem.Application.ArticleCreation.Articles.Commands.Create
{
    using System.Threading.Tasks;
    using System.Threading;
    using System.Linq;

    using MediatR;

    using Application.ArticleCreation.Articles.Commands.Common;
    using NewsSystem.Application.Common.Contracts;

    public class CreateSubCommentCommand : CommentCommand<CreateSubCommentCommand>, IRequest<CreateCommentOutputModel>
    {
        public class CreateSubCommentCommandHandler : IRequestHandler<CreateSubCommentCommand, CreateCommentOutputModel>
        {
            private readonly ICurrentUser currentuser;
            private readonly IArticleRepository articleRepository;

            public CreateSubCommentCommandHandler(
                ICurrentUser currentuser,
                IArticleRepository articleRepository
                )
            {
                this.currentuser = currentuser;
                this.articleRepository = articleRepository;
            }

            public async Task<CreateCommentOutputModel> Handle(
                CreateSubCommentCommand request,
                CancellationToken cancellationToken
                )
            {
                var article = await this.articleRepository.Find(
                    request.ArticleId, cancellationToken);

                article.AddSubComment(request.Title, request.Content, currentuser.UserId, request.ArticleId, request.CommentId);

                await this.articleRepository.Save(article, cancellationToken);

                return new CreateCommentOutputModel(article.Id);
            }

        }
    }
}

