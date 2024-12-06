using Microsoft.AspNetCore.Identity;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.WebApi.Auth.Interface;
using PublishingHouse.WebApi.Dto.AuthDto;
using PublishingHouse.WebApi.Mapper.General;

namespace PublishingHouse.WebApi.Auth.Impl
{
    public class CustomerRegisterService(UserManager<IdentityUser> userManager, ICustomerService customerService, IUserMapper<ICustomer, RegisterCustomerRequestDto> mapper) : ICustomerRegisterService
    {
        private const string RoleName = "Customer";

        public async Task<RegisterCustomerResponseDto> RegisterAsync(RegisterCustomerRequestDto entity)
        {
            var user = new IdentityUser
            {
                UserName = entity.UserName,
                Email = entity.Email,
            };

            var identityResult = await userManager.CreateAsync(user, entity.Password);
            if (!identityResult.Succeeded)
            {
                var errors = string.Join(", ", identityResult.Errors.Select(e => e.Description));
                throw new AccessException($"Failed to create user. Errors: {errors}");
            }

            identityResult = await userManager.AddToRoleAsync(user, RoleName);
            if (!identityResult.Succeeded)
            {
                var errors = string.Join(", ", identityResult.Errors.Select(e => e.Description));
                throw new AccessException($"Failed to add user role. Errors: {errors}");
            }

            await customerService.AddAsync(mapper.ToEntity(entity, user.Id));
            var customerId = await customerService.GetIdByUserIdAsync(user.Id);

            return new RegisterCustomerResponseDto()
            {
                UserName = user.UserName,
                Role = RoleName,
                CustomerId = customerId,
            };
        }
    }
}
