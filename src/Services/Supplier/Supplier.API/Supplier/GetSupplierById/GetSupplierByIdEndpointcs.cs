
using Supplier.API.Supplier.GetAllSupplier;

namespace Supplier.API.Supplier.GetSupplierById
{
    //اول request , Response
    // public record GetSupplierByIDRequest();
    public record GetSupplierByIdResponse(Models.Supplier Supplier);
    public class GetSupplierByIdEndpointcs() : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/Suppliers/{id}/", async (Guid Id, ISender sender) =>
         {
             var result = await sender.Send(new GetProductByIDQuery(Id));
             var response = result.Adapt<GetSupplierByIdResponse>();
             return Results.Ok(response);

         })

        .WithName("GetSupplierById")
        .WithSummary("Create a new supplier")
        .WithDescription("Creates a new supplier and returns its ID")
        .Produces<GetSupplierByIdResponse>(StatusCodes.Status201Created)
        .ProducesValidationProblem(); ;
        }
    }
}
