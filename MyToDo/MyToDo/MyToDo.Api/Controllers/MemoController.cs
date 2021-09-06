using Microsoft.AspNetCore.Mvc;
using MyToDo.Api.Context;
using MyToDo.Api.Service;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDo.Api.Controllers
{
    /// <summary>
    /// 备忘录控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MemoController : ControllerBase
    {
        private readonly IMemoService service;

        public MemoController(IMemoService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ApiResponse> Get(int id) => await service.GetSingleAsync(id);

        [HttpGet]
        public async Task<ApiResponse> GetAll([FromQuery] QueryParameter param) => await service.GetAllAsync(param);
         
        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] MemoDto model) => await service.AddAsync(model);

        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] MemoDto model) => await service.UpdateAsync(model);

        [HttpDelete]
        public async Task<ApiResponse> Delete(int id) => await service.DeleteAsync(id);
    }
}
