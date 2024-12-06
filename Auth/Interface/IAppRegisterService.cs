namespace PublishingHouse.WebApi.Auth.Interface
{
    public interface IAppRegisterService<in TRegisterRequestDto, TRegisterResponseDto>
        where TRegisterRequestDto : class
        where TRegisterResponseDto : class
    {
        Task<TRegisterResponseDto> RegisterAsync(TRegisterRequestDto entity);
    }
}
