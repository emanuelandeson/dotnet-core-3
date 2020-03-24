
using GolLabs.API.Contracts;
using GolLabs.Application.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GolLabs.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [AllowAnonymous]
    public class AuthController: ApiController
    {
        private readonly UserCommand _command;

        public AuthController(UserCommand command)
        {
            _command = command;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PostAuthenticationRequest request)
        {
            var response = await _command.Authenticate(request.Username, request.Password);
            return Response(response);
        }
    }
}
