using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface IPaymentService: IService<Payment>
{
    Task<Payment> QueryAsync(PaymentQuery query);
}