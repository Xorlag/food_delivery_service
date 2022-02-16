namespace FoodDeliveryService.Mappers
{
    public interface IMapper<TSource, TTarget>
    {
        TTarget Map(TSource source);
    }
}
