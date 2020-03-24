using GolLabs.API.Contracts;
using GolLabs.Application.Commands;
using GolLabs.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolLabs.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    public class TripController : ApiController
    {
        private readonly TripCommand _command;
        private readonly TripQuery _query;

        public TripController(TripCommand command, TripQuery query)
        {
            _command = command;
            _query = query;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PostPutTripRequest request)
        {
            var response = await _command.Create(request.Name, request.Date, request.Time, request.Origin, request.Destination);
            return Response(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]PostPutTripRequest request)
        {
            var response = await _command.Update(request.Id, request.Name, request.Date, request.Time, request.Origin, request.Destination);
            return Response(response);
        }

        [HttpDelete("{tripId}")]
        public async Task<IActionResult> Delete(string tripId)
        {
            var response = await _command.Delete(tripId);
            return Response(response);
        }

        public async Task<IActionResult> Get()
        {
            var response = await _query.GetAll();
            return Response(response);
        }
    }
}
