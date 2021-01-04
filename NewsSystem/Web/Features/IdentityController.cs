namespace NewsSystem.Web.Features
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using System.Threading.Tasks;

    using Application.Identity.Commands.ChangePassword;
    using Application.Identity.Commands.CreateUser;
    using Application.Identity.Commands.LoginUser;
    using Application.Identity.Commands.CreateJournalist;

    public class IdentityController : ApiController
    {
        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(
            CreateUserCommand command)
            => await this.Send(command);

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginOutputModel>> Login(
            LoginUserCommand command)
            => await this.Send(command);

        [HttpPut]
        [Authorize]
        [Route(nameof(ChangePassword))]
        public async Task<ActionResult> ChangePassword(
            ChangePasswordCommand command)
            => await this.Send(command);

        [HttpPost]
        [Authorize]
        [Route(nameof(Journalist))]
        public async Task<ActionResult> Journalist(RegisterJournalistCommand command)
            => await base.Send(command);
    }
}
