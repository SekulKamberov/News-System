namespace NewsSystem.Application.Identity
{
    using System.Threading.Tasks; 

    using NewsSystem.Application.Common; 
    using NewsSystem.Application.Identity.Commands;
    using NewsSystem.Application.Identity.Commands.ChangePassword;
    using NewsSystem.Application.Identity.Commands.LoginUser;

    public interface IIdentity
    {
        Task<Result<IUser>> Register(UserInputModel userInput);

        Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);

        Task<Result> AddToRoleJournalist(string userId);   
    }
}
