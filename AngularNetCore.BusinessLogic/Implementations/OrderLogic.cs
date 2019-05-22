using System.Collections.Generic;
using AngularNetCore.BusinessLogic.Interfaces;
using AngularNetCore.Models;
using AngularNetCore.UnitOfWork;

namespace AngularNetCore.BusinessLogic.Implementations
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        public bool Delete(Order Order) => _unitOfWork.Order.Delete(Order);

        public Order GetById(int id) => _unitOfWork.Order.GetById(id);

        public int Insert(Order Order) => _unitOfWork.Order.Insert(Order);

        public IEnumerable<OrderList> getPaginatedOrders(int page, int rows) => _unitOfWork.Order.getPaginatedOrder(page, rows);

        public bool Update(Order Order) => _unitOfWork.Order.Update(Order);
    }
}
