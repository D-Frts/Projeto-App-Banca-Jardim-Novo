using AppBanca.Api.Context;
using AppBanca.Api.Repository.Iterfaces;
using AppBanca.Models.Domain;

namespace AppBanca.Api.Repository;

public class CategoryRepository : Repository<Category>
{
    public CategoryRepository(AppBancaDbContext context) : base(context)
    {
        
    }

}
