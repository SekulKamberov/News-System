namespace NewsSystem.Application.Identity.Commands.CreateUser
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Common;
    using NewsSystem.Application.Identity;

    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {  
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity identity;

            public CreateUserCommandHandler(
                IIdentity identity) 
            {
                this.identity = identity; 
            }

            public async Task<Result> Handle(
                CreateUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Register(request);

                if (!result.Succeeded)
                {
                    return result;
                } 

                return result;
            }
        }
    }
}
