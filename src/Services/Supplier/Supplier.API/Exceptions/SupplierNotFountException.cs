
namespace Supplier.API.Exceptions;

    public class SupplierNotFoundException : Exception
    {
        public SupplierNotFoundException(): base ("Supplier not Found!")
        {

        }
    }
