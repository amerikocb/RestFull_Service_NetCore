using AngularNetCore.Models;
using System.Collections.Generic;

namespace AngularNetCore.BusinessLogic.Interfaces
{
    public interface IOrderLogic
    {
        Order GetById(int id);
        IEnumerable<OrderList> getPaginatedOrders(int page, int rows);
        int Insert(Order Order);
        bool Update(Order Order);
        bool Delete(Order Order);
    }
}
