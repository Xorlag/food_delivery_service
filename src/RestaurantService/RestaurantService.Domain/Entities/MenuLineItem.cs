
namespace RestaurantService.Domain.Entities
{
    public class MenuLineItem
    {
        public Guid MenuLineItemId { get; set; }
        public Guid MenuId { get; set; }
        public string Title { get; set; }
    }
}
