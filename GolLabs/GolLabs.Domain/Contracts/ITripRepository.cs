using GolLabs.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GolLabs.Domain.Contracts
{
    public interface ITripRepository
    {
        Task<IList<Trip>> GetAll();
        Task<Trip> Get(string tripId);
        Task<Trip> Add(Trip trip);
        Task<Trip> Update(Trip trip);
        Task<Trip> Delete(Trip trip);
    }
}
