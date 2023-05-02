using AppBanca.Api.Context;
using AppBanca.Api.Repository.Iterfaces;
using AppBanca.Models.Domain;

namespace AppBanca.Api.Repository;

public class SupplierRepository : Repository<Supplier>
{
    public SupplierRepository(AppBancaDbContext context) : base(context)
    {
    }
}
