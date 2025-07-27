
namespace Supplier.API.Supplier.DeleteSupplier
{
    public record DeleteSupplierCommand(Guid Id) : ICommand<DeleteSupplierResult>;

    public record DeleteSupplierResult(bool Success);
    internal class DeleteSupplierCommandHandler (IDocumentSession session , ILogger<DeleteSupplierCommandHandler> logger) : ICommandHandler<DeleteSupplierCommand, DeleteSupplierResult>
    {
        public async Task<DeleteSupplierResult> Handle(DeleteSupplierCommand command, CancellationToken cancellationToken)
        {
           logger.LogInformation("DeleteSupplierCommandHandler.Handle called with {@command}", command);
          
            // Delete the supplier
           session.Delete<Models.Supplier>(command.Id);
            await session.SaveChangesAsync(cancellationToken);
            logger.LogInformation("Supplier with Id {Id} deleted successfully", command.Id);
            return new DeleteSupplierResult(true);
        }
    }
}
