
namespace Supplier.API.Supplier.GetSupplierByCategory;

//public record GetSuppliersByCategoryRequest(string Category);
public record  GetSuppliersByCategoryResponse(IEnumerable<Models.Supplier> Suppliers);
public class GetSuppliersByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
      app.MapGet("/Suppliers/category/{category}", async (string category, ISender sender) =>
        {
            var result = await sender.Send(new GetSuppliersByCategoryQuery(category));
            var response = result.Adapt<GetSuppliersByCategoryResponse>();
            return Results.Ok(response);
        })
        .WithName("GetSuppliersByCategory")
        .WithSummary("Get suppliers by category")
        .WithDescription("Retrieves a list of suppliers filtered by the specified category")
        .Produces<GetSuppliersByCategoryResponse>(StatusCodes.Status200OK)
        .ProducesValidationProblem();
    }
}

