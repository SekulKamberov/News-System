namespace NewsSystem.Infrastructure.Identity
{
    using System.Linq;
    using System.Threading.Tasks;
    
    using Microsoft.AspNetCore.Identity;

    using Application.Identity; 
    using Application.Common; 
    using Application.Identity.Commands;
    using Application.Identity.Commands.ChangePassword;
    using Application.Identity.Commands.LoginUser; 
    using static Infrastructure.Common.ConstantsInfrastructure;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    internal class IdentityService : IIdentity
    {
        private const string InvalidErrorMessage = "Invalid credentials.";

        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IJwtTokenGenerator jwtTokenGenerator;

        public IdentityService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<Result<IUser>> Register(UserInputModel userInput)
        {
            var user = new User(userInput.Email, userInput.UserName, userInput.PhoneNumber);

            var identityResult = await this.userManager.CreateAsync(user, userInput.Password);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result<IUser>.SuccessWith(user)
                : Result<IUser>.Failure(errors);
        }

        public async Task<Result<LoginSuccessModel>> Login(UserInputModel userInput)
        {
            var user = await this.userManager.FindByEmailAsync(userInput.Email);
            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, userInput.Password);
            if (!passwordValid)
            {
                return InvalidErrorMessage;
            }

            var token = this.jwtTokenGenerator.GenerateToken(user);

            return new LoginSuccessModel(user.Id, token);
        }

        public async Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput)
        {
            var user = await this.userManager.FindByIdAsync(changePasswordInput.UserId);

            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var identityResult = await this.userManager.ChangePasswordAsync(
                user,
                changePasswordInput.CurrentPassword,
                changePasswordInput.NewPassword);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result.Success
                : Result.Failure(errors);
        }

        public async Task<Result> AddToRoleJournalist(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user is null)
            {
                return Result.Failure(System.Array.Empty<string>());
            }

            var roles = await roleManager.RoleExistsAsync(Roles.Journalist);

            if (roles)
            {
                return Result.Failure(new string[] { IdentityErrors.AlreadyJournalist });
            }

            //luje che zapisva uj IdentityResult.Success 
            var created = await roleManager.CreateAsync(new IdentityRole(Roles.Journalist));

            if(!created.Succeeded)
            {
                return Result.Failure(new string[] { IdentityErrors.RoleInvalid });
            }

            // and here throw: "Role JOURNALIST does not exist."
            //var result = await userManager.AddToRoleAsync(user, Roles.Journalist);  

            //if (!result.Succeeded)
            //{
            //    return Result.Failure(result.Errors.Select(e => e.Description));
            //}

            return Result.Success;
        }
    }
}
