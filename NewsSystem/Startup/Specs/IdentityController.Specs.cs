namespace NewsSystem.Startup.Specs
{  
    using FluentAssertions; 
    using MyTested.AspNetCore.Mvc;
    using NewsSystem.Application.Identity.Commands.CreateUser;
    using NewsSystem.Application.Identity.Commands.LoginUser;
    using NewsSystem.Web.Features; 
    using Xunit;

    public class IdentityControllerSpecs
    {
        [Fact]
        public void RegisterShouldHaveCorrectAttributes()
            => MyController<IdentityController>
                .Calling(c => c
                    .Register(CreateUserCommandFakes.Data.GetCommand()))

                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Post)
                    .SpecifyingRoute(nameof(IdentityController.Register)));

        [Fact]
        public void LoginShouldHaveCorrectAttributes()
            => MyController<IdentityController>
                .Calling(c => c
                    .Login(With.Default<LoginUserCommand>()))

                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Post)
                    .SpecifyingRoute(nameof(IdentityController.Login)));

        [Theory]
        [InlineData(
            NewsSystem.Infrastructure.Identity.IdentityFakes.TestEmail,
            NewsSystem.Infrastructure.Identity.IdentityFakes.ValidPassword,
            NewsSystem.Infrastructure.Identity.JwtTokenGeneratorFakes.ValidToken)]
        public void LoginShouldReturnTokenWhenUserEntersValidCredentials(string email, string password, string token)
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                    .WithLocation("/Identity/Login")
                    .WithMethod(HttpMethod.Post)
                    .WithJsonBody(new
                    {
                        Email = email,
                        Password = password
                    }))

                .To<IdentityController>(c => c
                    .Login(new LoginUserCommand
                    {
                        Email = email,
                        Password = password
                    }))

                .Which()
                .ShouldReturn()
                .ActionResult<LoginOutputModel>(result => result
                    .Passing(model => model.Token.Should().Be(token)));
    }
}
