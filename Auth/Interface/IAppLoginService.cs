namespace PublishingHouse.WebApi.Auth.Interface
{
    public interface IAppLoginService<in TLoginRequestDto, TLoginResponseDto>
        where TLoginRequestDto : class
        where TLoginResponseDto : class
    {
        Task<TLoginResponseDto> LoginAsync(TLoginRequestDto entity);
    }
}
