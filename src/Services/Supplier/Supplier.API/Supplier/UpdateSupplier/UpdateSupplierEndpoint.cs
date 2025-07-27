
using Supplier.API.Supplier.GetSupplierByCategory;

namespace Supplier.API.Supplier.UpdateSupplier;

    public record UpdateSupplierRequest 
    (
        Guid Id,
        string Name,
        List<string> Category,
        string ContactPerson,
        string PhoneNumber,
        string Email,
        string Address,
        string EconomicID,
        bool IsActive,
        int Rate
    );
   public record UpdateSupplierResponse(bool Success);

public class UpdateSupplierEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/supplier/{id}", async (Guid id, UpdateSupplierRequest request, ISender sender) =>
        {
            if (id != request.Id)
            {
                return Results.BadRequest("Id in URL and request body do not match.");
            }

            var command = request.Adapt<UpdateSupplierCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<UpdateSupplierResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateSuppliersByCategory")
        .WithSummary("Update suppliers")
        .WithDescription("Update SUpplier")
        .Produces<UpdateSupplierResponse>(StatusCodes.Status200OK)
        .ProducesValidationProblem();
    }
}

