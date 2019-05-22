using AngularNetCore.Repositories;
using AngularNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngularNetCore.DataAccess
{
    public class AngularNetCoreUnitOfWork : IUnitOfWork
    {
        public AngularNetCoreUnitOfWork(string connectionString)
        {
            Customer = new CustomerRepository(connectionString);
            User = new UserRepository(connectionString);
            Supplier = new SupplierRepository(connectionString);
            Order = new OrderRepository(connectionString);
            
        }
        public ICustomerRepository Customer { get; private set; }
        public IUserRepository User { get; private set; }
        public ISupplierRepository Supplier { get; private set; }
        public IOrderRepository Order { get; private set; }
    }
}
