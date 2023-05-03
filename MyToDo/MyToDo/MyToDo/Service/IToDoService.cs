using Detection_System.Shared.Contact;
using Detection_System.Shared.Dtos;
using Detection_System.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detection_System.Service
{
    public interface IToDoService : IBaseService<ToDoDto>
    {
        Task<ApiResponse<PagedList<ToDoDto>>> GetAllFilterAsync(ToDoParameter parameter);

        Task<ApiResponse<SummaryDto>> SummaryAsync();
    }
}
