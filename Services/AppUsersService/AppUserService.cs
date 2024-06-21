using Microsoft.AspNetCore.Identity;
using PointofSalesApi.DTO.AppUsersDTO;
using PointofSalesApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PointofSalesApi.Services.AppUsersService
{
    public class AppUserService : IAppUserService
    {
        private readonly AppDbContext appDbContext;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole> roleManager;

        public AppUserService(AppDbContext appDbContext,UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,IConfiguration configuration,RoleManager<IdentityRole> roleManager)
        {
            this.appDbContext = appDbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.roleManager = roleManager;
        }

        public async Task<(int statuscode, string message)> AddRole(string email, UserRolesDTO role)
        {
            var roleExists = await roleManager.RoleExistsAsync(role.RoleName);
            var user = await userManager.FindByEmailAsync(email);
            if (user == null || !roleExists)
            {
                return (StatusCodes.Status404NotFound,$"User '{email}' or role name '{role.RoleName}' may not exist!");
            }
            var userHasRole = await userManager.IsInRoleAsync(user, role.RoleName);
            if (userHasRole)
            {
                return (StatusCodes.Status409Conflict,$"User '{email}' already have the role '{role.RoleName}'"); // User already has the role
            }

            var result = await userManager.AddToRoleAsync(user,role.RoleName);
            if(result.Succeeded)
            {
                return (StatusCodes.Status200OK,$"The role '{role.RoleName}' applied to the user '{email}' succesfully");
            }
            return (StatusCodes.Status400BadRequest, $"Internal Server Error");
        }

        public async Task CreateUser(AddAppUserDTO appUserDTO)
        {
            AppUser user = new AppUser()
            {
                Name = appUserDTO.EmployeeName,
                Email = appUserDTO.EmployeeEmail,
                UserName = appUserDTO.EmployeeEmail,
                Gender = appUserDTO.Gender,
                IsActive = appUserDTO.IsActive,
                Salary = appUserDTO.SalaryPerMonth,
                PhoneNumber = appUserDTO.PhoneNumber,
                DepartmerntId = appUserDTO.DepartmentId,
                BirthDate = appUserDTO.BirthDate,
            };

            await userManager.CreateAsync(user,appUserDTO.Password);
            
        }

        public async Task<bool?> DeleteUser(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new ApplicationException($"User with username '{userName}' was not found.");
            }

            var result = await userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<List<GetAppUserDTO>> GetAppUsers()
        {
            var users = await userManager.Users.Include(u => u.Department).ToListAsync();
            var usersDTo = users.Select(user => new GetAppUserDTO
            {
                EmployeeName = user.Name,
                DepartmentName = user.Department.Name,
                SalaryPerMonth = user.Salary,
                PhoneNumber = user.PhoneNumber,
                EmployeeEmail = user.UserName,
                EmployeeStatus = user.IsActive?"Active":"Not Active",
                BirthDate = user.BirthDate
            }).ToList();

            return usersDTo;
        }

        public  async Task<GetAppUserDTO?> GetUser(string userName)
        {
            var user = await userManager.Users.Include(u=>u.Department).SingleOrDefaultAsync(u=>u.UserName == userName);

            if(user == null)
                return null;

            var usersDTo = new GetAppUserDTO()
            {
                EmployeeName = user.Name,
                DepartmentName = user.Department.Name,
                SalaryPerMonth = user.Salary,
                PhoneNumber = user.PhoneNumber,
                EmployeeEmail = user.UserName,
                EmployeeStatus = user.IsActive ? "Active" : "Not Active",
                BirthDate = user.BirthDate
            };

            return usersDTo;
        }

        public async Task<(string token, DateTime expiration)> LogIn(LoginDTO userDTO)
        {
            var user = await userManager.FindByNameAsync(userDTO.Email);
            if (user != null)
            {
                var check = await userManager.CheckPasswordAsync(user, userDTO.Password);
                if (check)
                {
                    //Claims of Token
                    var result = await userManager.CheckPasswordAsync(user, userDTO.Password);
                    if (result)
                    {
                        //Claims of Token
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                        //get role
                        var roles = await userManager.GetRolesAsync(user);
                        foreach (var role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role));
                        }

                        SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));


                        SigningCredentials signincred =
                            new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                        //Create token => JwtSecurityToken
                        //This class represent token not to create it
                        JwtSecurityToken Token = new JwtSecurityToken(
                            issuer: configuration["JWT:ValidIssuer"],//Provider API
                            audience: configuration["JWT:ValidAudience"], //Consumer Angular, HTML, MVC .....
                            claims: claims,
                            expires: DateTime.Now.AddHours(1),
                            signingCredentials: signincred
                            );
                        return (new JwtSecurityTokenHandler().WriteToken(Token), Token.ValidTo);
                    }
                }
            }
            throw new UnauthorizedAccessException("Invalid username or password");
        }

        public Task<bool?> UpdateUser(string userName, AddAppUserDTO appUserDTO)
        {
            throw new NotImplementedException();
        }
    }
}
