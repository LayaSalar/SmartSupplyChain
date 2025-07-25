
namespace Supplier.API.Supplier.GetSupplierById;

public record GetProductByIDQuery(Guid Id) : IQuery<GetSupplierByIdResult>;
public record GetSupplierByIdResult(Models.Supplier Supplier);
public class GetSupplierByIdHandler(IDocumentSession session , ILogger<GetSupplierByIdHandler> logger) : IQueryhandler<GetProductByIDQuery, GetSupplierByIdResult>
{
    public async Task<GetSupplierByIdResult> Handle(GetProductByIDQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetSupplierByIdHandler.Handle Handle called with {@query}", query);
        var supplier =  await session.LoadAsync<Models.Supplier>(query.Id, cancellationToken);
        if (supplier is null)
        {
            throw new SupplierNotFoundException();
        }
        return new GetSupplierByIdResult(supplier);
    }
}

