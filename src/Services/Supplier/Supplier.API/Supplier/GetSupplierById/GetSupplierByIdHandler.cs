
namespace Supplier.API.Supplier.GetSupplierById;

public record GetSupplierByIDQuery(Guid Id) : IQuery<GetSupplierByIdResult>;
public record GetSupplierByIdResult(Models.Supplier Supplier);
public class GetSupplierByIdHandler(IDocumentSession session , ILogger<GetSupplierByIdHandler> logger) : IQueryhandler<GetSupplierByIDQuery, GetSupplierByIdResult>
{
    public async Task<GetSupplierByIdResult> Handle(GetSupplierByIDQuery query, CancellationToken cancellationToken)
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

