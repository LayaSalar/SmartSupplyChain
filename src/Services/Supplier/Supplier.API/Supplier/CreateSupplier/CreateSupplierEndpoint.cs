

namespace Supplier.API.Supplier.CreateSupplier;

public class CreateSupplierEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/suppliers", async (
            CreateSupplierRequest request,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = request.Adapt<CreateSupplierCommand>();
            var result = await sender.Send(command, cancellationToken);
            var response = result.Adapt<CreateSupplierResponse>();
            return Results.Created($"/suppliers/{response.Id}", response);
        })
        .WithName("CreateSupplier")
        .WithSummary("Create a new supplier")
        .WithDescription("Creates a new supplier and returns its ID")
        .Produces<CreateSupplierResponse>(StatusCodes.Status201Created)
        .ProducesValidationProblem();
    }

    public record CreateSupplierRequest(
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

    public record CreateSupplierResponse(Guid Id);
}
