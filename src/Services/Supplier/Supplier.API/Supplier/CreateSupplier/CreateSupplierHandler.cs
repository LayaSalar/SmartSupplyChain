using MediatR;

namespace Supplier.API.Supplier.CreateSupplier
{
    public record CreateSupplierCommand(
               string Name,
        List<string> Category,
        string ContactPerson,
        string PhoneNumber,
        string Email,
        string Address,
        string EconomicID,
        bool IsActive,
        int Rate,
        DateTime CreatedAt,
        DateTime? UpdatedAt
    ):IRequest<CreateSupplierResult>;

    public record CreateSupplierResult(Guid Id);

    internal class CreateSupplierHandler : IRequestHandler<CreateSupplierCommand, CreateSupplierResult>
    {
        public Task<CreateSupplierResult> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            //business Logic to create a product
            throw new NotImplementedException();
        }
    }
}
