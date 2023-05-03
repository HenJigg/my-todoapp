using Detection_System.Api.Context;
using Detection_System.Shared.Dtos;
using Detection_System.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detection_System.Api.Service
{
    public interface IToDoService : IBaseService<ToDoDto>
    {
        Task<ApiResponse> GetAllAsync(ToDoParameter query);

        Task<ApiResponse> Summary();
    }
}
