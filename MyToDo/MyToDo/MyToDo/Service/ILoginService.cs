 using Detection_System.Shared.Contact;
using Detection_System.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detection_System.Service
{
    public interface ILoginService
    {
        Task<ApiResponse> Login(UserDto user);

        Task<ApiResponse> Resgiter(UserDto user);
    }
}
