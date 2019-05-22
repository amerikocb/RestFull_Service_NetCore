using AngularNetCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngularNetCore.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
        User ValidateUser(String email, string password);
    }
}
