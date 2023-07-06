using ModelLibrary;

namespace UserServices
{
    public interface IUserService
    {
        Task<bool> UserCreate(UserModel user);
        Task<bool> UserLoggin(UserModel user);
        Task<LogModelFront> LogData(string userName);
        Task<MessageModel> CreateMessageModel(TestModel model, string ipv4Address);
        Task<LogModelFront> CreateFrontModel(string model);

    }
}