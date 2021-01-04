namespace NewsSystem.Application.ArticleCreation.Journalists.Queries.Details
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class JournalistDetailsQuery : IRequest<JournalistDetailsOutputModel>
    {
        public int Id { get; set; }

        public class JournalistDetailsQueryHandler : IRequestHandler<JournalistDetailsQuery, JournalistDetailsOutputModel>
        {
            private readonly IJournalistRepository journalistRepository;

            public JournalistDetailsQueryHandler(IJournalistRepository journalistRepository) 
                => this.journalistRepository = journalistRepository;

            public async Task<JournalistDetailsOutputModel> Handle(
                JournalistDetailsQuery request,
                CancellationToken cancellationToken)
                => await this.journalistRepository.GetDetails(request.Id, cancellationToken);
        }
    }
}
