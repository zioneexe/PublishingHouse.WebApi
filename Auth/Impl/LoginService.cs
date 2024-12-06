using Microsoft.AspNetCore.Identity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.WebApi.Auth.Interface;
using PublishingHouse.WebApi.Dto.AuthDto;

namespace PublishingHouse.WebApi.Auth.Impl
{
    public class LoginService(UserManager<IdentityUser> userManager, ITokenService tokenService, ICustomerService customerService, IEmployeeService employeeService) : ILoginService
    {
        private const string CustomerRoleName = "Customer";
        private const string EmployeeRoleName = "Employee";
        private const string AdminRoleName = "Admin";

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequest)
        {
            var identityUser = await userManager.FindByEmailAsync(loginRequest.Email) ?? throw new AccessException("Invalid email.");
            var checkResult = await userManager.CheckPasswordAsync(identityUser, loginRequest.Password);
            if (!checkResult)
            {
                throw new AccessException("Invalid password.");
            }

            var userRoles = await userManager.GetRolesAsync(identityUser);
            if (userRoles == null || !userRoles.Any())
            {
                throw new AccessException($"No roles assigned to user \"{identityUser.UserName}\".");
            }

            var role = userRoles.Contains(AdminRoleName) ? AdminRoleName
                       : userRoles.Contains(EmployeeRoleName) ? EmployeeRoleName
                       : userRoles.Contains(CustomerRoleName) ? CustomerRoleName
                       : userRoles.First();

            var jwtToken = tokenService.CreateJwtToken(identityUser, userRoles);

            var response = new LoginResponseDto
            {
                UserName = identityUser.UserName,
                Role = role,
                Token = jwtToken,
            };

            switch (role)
            {
                case CustomerRoleName:
                {
                    var customerId = await customerService.GetIdByUserIdAsync(identityUser.Id);
                    response.Id = customerId;
                    break;
                }
                case EmployeeRoleName:
                {
                    var employeeId = await employeeService.GetIdByUserIdAsync(identityUser.Id);
                    response.Id = employeeId;
                    break;
                }
                case AdminRoleName:
                {
                    response.Id = 0;
                    break;
                }
            }

            return response;
        }
    }
}
