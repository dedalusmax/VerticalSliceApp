using Microsoft.AspNetCore.Mvc;

namespace VerticalSliceApp.Application.Common;

[Route("api/[controller]")]
[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
}
