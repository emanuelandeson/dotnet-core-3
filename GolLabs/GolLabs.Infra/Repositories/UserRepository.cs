using GolLabs.Domain.Contracts;
using GolLabs.Domain.Entities;
using GolLabs.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GolLabs.Infra.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly GLContext _context;
        public UserRepository(GLContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Get(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}