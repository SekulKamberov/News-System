namespace NewsSystem.Domain.ArticleCreation.Factories.Journalists
{
    using Common;
    using Models.Journalists; 

    public interface IJournalistFactory : IFactory<Journalist>
    {
        IJournalistFactory WithUserId(string userId);

        IJournalistFactory WithAddress(Address address);

        IJournalistFactory WithNickName(string nickName);

        IJournalistFactory WithAddress(string address);

        IJournalistFactory WithPhoneNumber(PhoneNumber phoneNumber);

        IJournalistFactory WithPhoneNumber(string phoneNumber);
    }
}
