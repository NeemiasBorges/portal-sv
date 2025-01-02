using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace backend_portal_sv.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ThrowController : ControllerBase
    {
        [Route("/error")]
        public IActionResult HandleError() => Problem();

        [Route("/error-dev")]
        public IActionResult HandleErrorDevelopment(
            [FromServices] IHostEnvironment hostEnviroment)
        {
            if (!hostEnviroment.IsDevelopment())
            {
                return NotFound();
            }
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            return Problem(
                detail: exceptionHandlerPathFeature.Error.StackTrace,
                title: exceptionHandlerPathFeature.Error.Message
            );
        }
    }
}
