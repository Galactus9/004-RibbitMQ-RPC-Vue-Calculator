using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary;
using RpcClientLib;
using UserServices;

namespace RPC_Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly IUserService _userService;
        public CalculatorController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Create(UserModel model)
        {
            var response = await _userService.UserCreate(model);
            return Ok(response);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Login(UserModel model)
        {
            var response = await _userService.UserLoggin(model);
            return Ok(response);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Calculator(TestModel model)
        {
            var ipv4Address = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

            var messageData = new MessageModel
            {
                UserName = model.userName,
                Ip = ipv4Address,
                Number1 = model.Number1,
                Number2 = model.Number2,
                Task = model.Task,
                intialTime = DateTime.Now
            };
            var _rpcClient = new RpcClient();
            var response = await _rpcClient.SendAsync(messageData);
            if (response != null)
            {
                return Ok(await _userService.LogData(model.userName));
            }
            return BadRequest();
        }
    }
}
