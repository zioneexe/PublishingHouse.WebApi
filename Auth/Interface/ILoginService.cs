using PublishingHouse.WebApi.Dto.AuthDto;

namespace PublishingHouse.WebApi.Auth.Interface
{
    public interface ILoginService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequest);
    }
}
