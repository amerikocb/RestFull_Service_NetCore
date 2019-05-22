using System.Collections.Generic;
using AngularNetCore.BusinessLogic.Interfaces;
using AngularNetCore.Models;
using AngularNetCore.UnitOfWork;

namespace AngularNetCore.BusinessLogic.Implementations
{
    public class CustomerLogic : ICustomerLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        public IEnumerable<Customer> CustomerPagedList(int page, int rows) => _unitOfWork.Customer.CustomerPagedList(page, rows);

        public bool Delete(Customer customer) => _unitOfWork.Customer.Delete(customer);

        public Customer GetById(int id) => _unitOfWork.Customer.GetById(id);

        public int Insert(Customer customer) => _unitOfWork.Customer.Insert(customer);

        public bool Update(Customer customer) => _unitOfWork.Customer.Update(customer);
    }
}
