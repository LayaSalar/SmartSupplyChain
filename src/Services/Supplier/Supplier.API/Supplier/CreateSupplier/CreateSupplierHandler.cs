namespace Supplier.API.Supplier.CreateSupplier
{
    public record CreateSupplierCommand(
         string Name,
        List<string> Category,
        string ContactPerson,
        string PhoneNumber,
        string Email,
        string Address,
        string EconomicID,
        bool IsActive,
        int Rate
    ) : ICommand<CreateSupplierResult>;

    public record CreateSupplierResult(Guid Id);

    public class CreateSupplierHandler(IDocumentSession session) :  ICommandHandler<CreateSupplierCommand, CreateSupplierResult>
    {
     
        public async Task<CreateSupplierResult> Handle(CreateSupplierCommand command, CancellationToken cancellationToken)
        {
            //business Logic to create a product

            //Create Product From Command Object 
            var supplier = new Models.Supplier
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Category = command.Category,
                ContactPerson = command.ContactPerson,
                PhoneNumber = command.PhoneNumber,
                Email = command.Email,
                Address = command.Address,
                EconomicID = command.EconomicID,
                IsActive = command.IsActive,
                Rate = command.Rate
            };

            //Save to Database 
            session.Store( supplier );
            await session.SaveChangesAsync(cancellationToken);
            // return CreateSupplierResult as Result
            return new CreateSupplierResult(supplier.Id );

        }
    }
}
