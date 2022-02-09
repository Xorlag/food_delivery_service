namespace FoodDeliveryService.DataAccess.DataOperation
{
    public class DataOperationResult
    {
        public DataOperationResult(DataOperationResultStatus status, string message = null)
        {
            Status = status;
            Message = message;
        }
        public bool IsSuccess => Status == DataOperationResultStatus.Success;
        public DataOperationResultStatus Status { get; }
        public string Message { get; }
    }
}