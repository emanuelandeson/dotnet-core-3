using GolLabs.Application.Core;
using GolLabs.Domain.Contracts;
using System.Threading.Tasks;

namespace GolLabs.Application.Queries
{
    public class TripQuery
    {
        private readonly ITripRepository _tripRepository;
        private readonly Response _response;
        public TripQuery(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
            _response = new Response();
        }

        public async Task<Response> GetAll()
        {
            _response.AddValue(await _tripRepository.GetAll());
            return _response;
        }
    }
}
