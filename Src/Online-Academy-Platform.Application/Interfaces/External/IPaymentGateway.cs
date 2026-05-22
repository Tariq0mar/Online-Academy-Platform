namespace Online_Academy_Platform.Application.Interfaces.External;

public interface IPaymentGateway
{
    Task<bool> ProcessPaymentAsync(decimal amount, string currency, string transactionId);
}