namespace FoodDeliveryService.APIGateway.Core.Mappers
{
    public interface IMapper<TSource,TTarget>
    {
        TTarget Map(TSource source);
    }
}
