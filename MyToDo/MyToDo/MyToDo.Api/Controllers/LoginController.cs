using Microsoft.AspNetCore.Mvc;
using Detection_System.Api.Context;
using Detection_System.Api.Service;
using Detection_System.Shared.Dtos;
using Detection_System.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detection_System.Api.Controllers
{
    /// <summary>
    /// 账户控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService service;

        public LoginController(ILoginService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ApiResponse> Login([FromBody] UserDto param) =>
            await service.LoginAsync(param.Account, param.PassWord);

        [HttpPost]
        public async Task<ApiResponse> Resgiter([FromBody] UserDto param) =>
            await service.Resgiter(param);

    }
}
