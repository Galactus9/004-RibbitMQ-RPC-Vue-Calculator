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
        private readonly IRpcClient _rpcClient;
        public CalculatorController(IUserService userService, IRpcClient rpcClient)
        {
            _userService = userService;
            _rpcClient = rpcClient;
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
            try
            {
                var ipv4Address = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

                var messageData = await _userService.CreateMessageModel(model, ipv4Address);

                var response = await _rpcClient.SendAsync(messageData);

                //var frontModel = _userService.CreateFrontModel(response);

                return Ok(response);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
    }
}
