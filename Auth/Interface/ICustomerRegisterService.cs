using PublishingHouse.WebApi.Dto.AuthDto;

namespace PublishingHouse.WebApi.Auth.Interface
{
    public interface ICustomerRegisterService : IAppRegisterService<RegisterCustomerRequestDto, RegisterCustomerResponseDto> {}
}
