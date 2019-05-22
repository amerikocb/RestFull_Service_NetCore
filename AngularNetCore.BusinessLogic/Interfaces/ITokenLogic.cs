using AngularNetCore.Models;

namespace AngularNetCore.BusinessLogic.Interfaces
{
    public interface ITokenLogic
    {
        User ValidateUser(string email, string password);
    }
}
