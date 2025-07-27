
namespace Supplier.API.Supplier.DeleteSupplier
{
    //public record DeleteSupplierRequest(Guid Id);
    public record DeleteSupplierResponse(bool Success);
    public class DeleteSupplierEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
           app.MapDelete ("/supplier/{id}", async (Guid id, ISender sender) =>
            {
              var result = await sender.Send(new DeleteSupplierCommand(id));
                var response = result.Adapt<DeleteSupplierResponse>();
                return Results.Ok(response);
            })
            .WithName("DeleteSupplier")
            .WithSummary("Delete a supplier")
            .WithDescription("Deletes a supplier by ID")
            .Produces<DeleteSupplierResponse>(StatusCodes.Status200OK)
            .ProducesValidationProblem();
        }
    }
}
