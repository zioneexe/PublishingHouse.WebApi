namespace PublishingHouse.WebApi.Mapper.General
{
    public interface IMapper<T, in TRequestDto, out TResponseDto>
    {
        public TResponseDto ToResponseDto(T entity);

        public T ToEntity(TRequestDto oth);
    }
}
