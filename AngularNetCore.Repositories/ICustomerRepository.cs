using AngularNetCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace AngularNetCore.Repositories
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        IEnumerable<CustomerList> CustomerPagedList(int page, int rows);
    }
}
