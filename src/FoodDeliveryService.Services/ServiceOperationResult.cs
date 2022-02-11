namespace FoodDeliveryService.Services
{
    public class ServiceOperationResult
    {
        public ServiceOperationResult(ServiceOperationResultStatus status, string message = null)
        {
            Status = status;
            Message = message;
        }
        public string Message { get; }
        public bool IsSuccess => Status == ServiceOperationResultStatus.Success;
        public ServiceOperationResultStatus Status { get; }
    }

    public class ServiceOperationResult<T> : ServiceOperationResult
    {
        public ServiceOperationResult(ServiceOperationResultStatus status, string message = null) : base(status, message)
        {
        }

        public ServiceOperationResult(T result, ServiceOperationResultStatus status = ServiceOperationResultStatus.Success) : base(status)
        {
            Result = result;
        }

        public T? Result { get; }
    }
}