
using Supplier.API.Models;

namespace Supplier.API.Supplier.GetAllSupplier;

public record GetAllSupplierQuery() : IQuery <GetAllSupplierResult>;
public record GetAllSupplierResult(IEnumerable<Models.Supplier> Suppliers);

internal class GetAllSupplierHandler(IDocumentSession session, ILogger<GetAllSupplierHandler> logger) 
    : IQueryhandler<GetAllSupplierQuery, GetAllSupplierResult>
{
   
    public async Task<GetAllSupplierResult> Handle(GetAllSupplierQuery query, CancellationToken cancellationToken)
    {
       logger.LogInformation("GetAllSupplierHandler.Handle called with {@query}", query);
        // Fetch all suppliers from the database
        var suppliers =await session.Query<Models.Supplier>().ToListAsync(cancellationToken);
        // Log the number of suppliers retrieved
        logger.LogInformation($"Retrieved {suppliers.Count} suppliers from the database");
        // Return the result containing the list of suppliers
        return new GetAllSupplierResult(suppliers);
    }
}
