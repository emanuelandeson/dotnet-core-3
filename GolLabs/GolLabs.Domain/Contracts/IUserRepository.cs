using GolLabs.Domain.Entities;
using System.Threading.Tasks;

namespace GolLabs.Domain.Contracts
{
    public interface IUserRepository
    {
        Task<User> Get(string user);
        Task<User> Add(User user);
    }
}