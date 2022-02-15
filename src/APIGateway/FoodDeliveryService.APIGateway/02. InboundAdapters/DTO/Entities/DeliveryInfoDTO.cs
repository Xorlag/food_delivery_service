namespace FoodDeliveryService.APIGateway.InboundAdapters.DTO.Entities
{
    public class DeliveryInfoDTO
    {
        public string Street { get; set; }
        public string City { get; set; }
        public int BuildingNumber { get; set; }
        public int? ApartmentsNumber { get; set; }
    }
}
