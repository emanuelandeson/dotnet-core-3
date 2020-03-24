using GolLabs.Domain.Contracts;
using GolLabs.Domain.Entities;
using GolLabs.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GolLabs.Infra.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly GLContext _context;
        public TripRepository(GLContext context)
        {
            _context = context;
        }

        public async Task<Trip> Add(Trip trip)
        {
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();
            return trip;
        }

        public async Task<Trip> Delete(Trip trip)
        {
            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
            return trip;
        }

        public async Task<Trip> Get(string tripId)
        {
            return await _context.Trips.FirstOrDefaultAsync(x => x.Id == tripId);

        }

        public async Task<IList<Trip>> GetAll()
        {
            return await _context.Trips.ToListAsync();
        }

        public async Task<Trip> Update(Trip trip)
        {
            _context.Trips.Update(trip);
            await _context.SaveChangesAsync();
            return trip;
        }
    }
}