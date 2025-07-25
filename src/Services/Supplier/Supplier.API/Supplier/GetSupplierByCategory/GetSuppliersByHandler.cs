
using ImTools;
using Supplier.API.Supplier.GetSupplierById;

namespace Supplier.API.Supplier.GetSupplierByCategory
{
    public record GetSuppliersByCategoryQuery(string Category) : IQuery<GetSuppliersByCategoryResult>;
    public record GetSuppliersByCategoryResult(IEnumerable<Models.Supplier> Suppliers);
    internal class GetSuppliersByHandler(IDocumentSession session, ILogger<GetSuppliersByHandler> logger)
        : IQueryhandler<GetSuppliersByCategoryQuery, GetSuppliersByCategoryResult>
    {
        public async Task<GetSuppliersByCategoryResult> Handle(GetSuppliersByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetSuppliersByHandler.Handle Handle called with {@query}", query);
            var suppliers = await session
    .Query<Models.Supplier>()
    .Where(s => s.Category.Contains(query.Category))
    .ToListAsync(cancellationToken);
            if (suppliers is null)
            {
                throw new SupplierNotFoundException();
            }
            return new GetSuppliersByCategoryResult(suppliers);
        }
    }
}
