using AngularNetCore.Models;
using System.Collections.Generic;

namespace AngularNetCore.Repositories
{
    public interface IOrderRepository:IRepository<Order>
    {
        IEnumerable<OrderList> getPaginatedOrder(int page, int rows);
        OrderList GetOrderById(int orderId);
    }
}
