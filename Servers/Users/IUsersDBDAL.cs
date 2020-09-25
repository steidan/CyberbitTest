using System.Collections.Generic;
using System.Threading.Tasks;
namespace Users
{
    public interface IUsersDBDAL
    {
        Task<bool> DoesExist(string userName);
    }
}