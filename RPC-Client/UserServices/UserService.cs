using DbContext;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //check if user name exists
            try
            {
                //var responce = _context.userContainer.GetItemLinqQueryable<UserModel>()
                //                         .Single(x => x.UserName == user.UserName);
                if (1 == 0)
                {
                    throw new Exception("The Users allready exists");
                }
                else
                {
                    user.Id = new Guid().ToString();
                    await _context.userContainer.CreateItemAsync<UserModel>(user);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UserLoggin(UserModel user)
        {
            //check if user name exists
            try
            {
                FeedIterator<UserModel>? query = _context.userContainer.GetItemLinqQueryable<UserModel>()
                    .Where(x => x.UserName == user.UserName)
                    .ToFeedIterator();

                //query.AllowSynchronousQueryExecution = false; // Ensure allowSynchronousQueryExecution is set to false (optional)

                var response = await query.ReadNextAsync();
                var result = response.SingleOrDefault();

                if (result.Password != user.Password)
                {
                    throw new Exception("Incorect Password");
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
        public async Task<LogModelFront> LogData(string userName)
        {
            var query = _context.logContainer.GetItemLinqQueryable<LoggingModel>()
                                        .Where(x => x.UserName == userName)
                                        .ToFeedIterator();

            var response = await query.ReadNextAsync();
            var result = response.LastOrDefault();

            var final = new LogModelFront
            {
                UserName = result?.UserName ?? string.Empty,
                Duration = result?.Duration ?? 0,
                Ip = result?.IP ?? string.Empty,
                Result = result?.Result ?? 0,
            };

            return final;
        }
    }
}
