namespace PublishingHouse.WebApi.Mapper.General
{

    public interface IUserMapper<out T, in TRegisterRequestDto>
    {
        public T ToEntity(TRegisterRequestDto regDto, string userId);
    }
}
