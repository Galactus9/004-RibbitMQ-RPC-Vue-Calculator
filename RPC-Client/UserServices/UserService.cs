using DbContext;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Core;
using Microsoft.Azure.Cosmos.Linq;
using ModelLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UserServices
{
    public class UserService : IUserService
    {
        private readonly ICosmosContext _context;
        public UserService(ICosmosContext context)
        {
            _context = context;
        }
        public async Task<bool> UserCreate(UserModel user)
        {
            try
            {
                user.Id = new Guid().ToString();
                await _context.userContainer.CreateItemAsync<UserModel>(user);
                return true;               
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> UserLoggin(UserModel user)
        {
            try
            {
                FeedIterator<UserModel>? query = _context.userContainer.GetItemLinqQueryable<UserModel>()
                    .Where(x => x.UserName == user.UserName)
                    .ToFeedIterator();

                var response = await query.ReadNextAsync();
                var result = response.SingleOrDefault();

                if (result.Password != user.Password)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<LogModelFront> CreateFrontModel(string model)
        {
            try
            {

                LoggingModel? logModel = JsonConvert.DeserializeObject<LoggingModel>(model);
                var final = new LogModelFront
                {
                    UserName = logModel?.UserName ?? string.Empty,
                    Duration = logModel?.Duration ?? 0,
                    Ip = logModel?.IP ?? string.Empty,
                    Number1 = logModel?.Number1 ?? 0,
                    Number2 = logModel?.Number2 ?? 0,
                    Result = logModel?.Result ?? 0,
                };

                return final;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<MessageModel> CreateMessageModel(TestModel model, string ipv4Address)
        {
            var messageData = new MessageModel
            {
                UserName = model.userName,
                Ip = ipv4Address,
                Number1 = model.Number1,
                Number2 = model.Number2,
                Task = model.Task,
                intialTime = DateTime.Now
            };
            return messageData;
        }
    }
}
