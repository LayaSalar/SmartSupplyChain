namespace Supplier.API.Supplier.UpdateSupplier;

public record UpdateSupplierCommand(
       Guid Id,
        string Name,
        List<string> Category,
        string ContactPerson,
        string PhoneNumber,
        string Email,
        string Address,
        string EconomicID,
        bool IsActive,
        int Rate) : ICommand<UpdateSupplierResult>;

public record UpdateSupplierResult(bool Success);

public class UpdateSupplierHandler(IDocumentSession session, ILogger<UpdateSupplierHandler> logger) : ICommandHandler<UpdateSupplierCommand, UpdateSupplierResult>
{
    public async Task<UpdateSupplierResult> Handle(UpdateSupplierCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("UpdateSupplierHandler.Handle called with {@request}", command);

        var supplier = await session.LoadAsync<Models.Supplier>(command.Id, cancellationToken);

        if (supplier == null)
        {
            logger.LogWarning("Supplier with Id {Id} not found", command.Id);
            throw new SupplierNotFoundException();
        }
            
        supplier.Name = command.Name;
        supplier.Category = command.Category;
        supplier.ContactPerson = command.ContactPerson;
        supplier.PhoneNumber = command.PhoneNumber;
        supplier.Email = command.Email;
        supplier.Address = command.Address;
        supplier.EconomicID = command.EconomicID;
        supplier.IsActive = command.IsActive;
        supplier.Rate = command.Rate;
        session.Update(supplier);

        await session.SaveChangesAsync(cancellationToken);
        return new UpdateSupplierResult(true);
    }
}

