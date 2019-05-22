using AngularNetCore.Models;
using System.Collections.Generic;

namespace AngularNetCore.BusinessLogic.Interfaces
{
    public interface ICustomerLogic
    {
        Customer GetById(int id);
        IEnumerable<Customer> CustomerPagedList(int page, int rows);
        int Insert(Customer customer);
        bool Update(Customer customer);
        bool Delete(Customer customer);
    }
}
