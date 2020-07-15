namespace ECommerce.Domain.Mappers
{
    public interface IMapper<TEntity, TDto>
    {
        TEntity ToEntity(TDto dto);

        TEntity ToEntity(TDto dto, TEntity entity);

        TDto ToDto(TEntity entity); 

        TDto ToDto(TEntity entity, TDto dto);    
    }
}