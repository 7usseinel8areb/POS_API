using PointofSalesApi.DTO.AppUsersDTO;
using System.Security.Claims;

namespace PointofSalesApi.Services.AppUsersService
{
    public interface IAppUserService
    {
        Task CreateUser(AddAppUserDTO appUserDTO);
        Task<bool?> UpdateUser(string userName, AddAppUserDTO appUserDTO);
        Task<bool?> DeleteUser(string userName);
        Task<GetAppUserDTO?> GetUser(string userName);
        Task<(string token, DateTime expiration)> LogIn(LoginDTO userDTO);
        Task<List<GetAppUserDTO>> GetAppUsers();

        Task<(int statuscode,string message)> AddRole(string email, UserRolesDTO role);

    }
}
