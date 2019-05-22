using AngularNetCore.Models;
using System.Collections.Generic;

namespace AngularNetCore.Repositories
{
    public interface ISupplierRepository: IRepository<Supplier>
    {
        IEnumerable<Supplier> SupplierPagedList(int page, int rows, string searchTerm);
    }
}
