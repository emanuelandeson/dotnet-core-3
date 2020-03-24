using GolLabs.Application.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GolLabs.API.Controllers
{
    [Authorize]
    public class ApiController : ControllerBase
    {
        protected new IActionResult Response(Response result = null)
        {
            if (result != null && !result.HasMessages)
            {
                return Ok(new
                {
                    success = true,
                    data = result?.Value
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = result.Messages
            });
        }
    }
}
