
using static Supplier.API.Supplier.CreateSupplier.CreateSupplierEndpoint;

namespace Supplier.API.Supplier.GetAllSupplier;

public record GetAllSupplierResponse (IEnumerable<Models.Supplier> Suppliers);
public class GetAllSupplierEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Suppliers" , async(ISender sender) =>
        {
            var result = await sender.Send(new GetAllSupplierQuery());
            var response = result.Adapt<GetAllSupplierResponse>();
            return Results.Ok(response);
        })
        .WithName("GetAllSupplier")
        .WithSummary("Create a new supplier")
        .WithDescription("Creates a new supplier and returns its ID")
        .Produces<GetAllSupplierResponse>(StatusCodes.Status201Created)
        .ProducesValidationProblem(); ;

    }
}

