namespace NewsSystem.Application.ArticleCreation.Articles.Commands.Create
{
    using System.Threading.Tasks;
    using System.Threading;
    using System.Linq;

    using MediatR;

    using Application.ArticleCreation.Articles.Commands.Common;
    using NewsSystem.Application.Common.Contracts;

    public class CreateCommentCommand : CommentCommand<CreateCommentCommand>, IRequest<CreateCommentOutputModel>
    {
        public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CreateCommentOutputModel>
        {
            private readonly ICurrentUser currentuser;
            private readonly IArticleRepository articleRepository;

            public CreateCommentCommandHandler(
                ICurrentUser currentuser,
                IArticleRepository articleRepository
                )
            {
                this.currentuser = currentuser;
                this.articleRepository = articleRepository;
            }

            public async Task<CreateCommentOutputModel> Handle(
                CreateCommentCommand request,
                CancellationToken cancellationToken
                )
            {
                var article = await this.articleRepository.Find(
                    request.ArticleId, cancellationToken);

                article.AddComment(request.Title, request.Content, currentuser.UserId, request.ArticleId);

                await this.articleRepository.Save(article, cancellationToken);

                return new CreateCommentOutputModel(article.Id);
            }

        }
    }
}
