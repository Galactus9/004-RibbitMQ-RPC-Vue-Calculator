using DbContext;
using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPC_Server
{
    internal class Logging
    {
        private readonly ICosmosContext _context;

        public Logging(ICosmosContext context)
        {
            _context = context;
        }
        internal async Task Log(MessageModel mModel, float? result)
        {
            var log = new LoggingModel
            {
                Id = Guid.NewGuid().ToString(),
                IP = mModel.Ip,
                UserName = mModel.UserName,
                DateOfLog = DateTime.Now,
                Duration = (DateTime.Now - mModel.intialTime).TotalMilliseconds,
                Number1 = mModel.Number1,
                Number2 = mModel.Number2,
                Result = result,
                Action = mModel.Task
            };
            await _context.logContainer.CreateItemAsync(log);
        }
    }
}
