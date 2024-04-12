using Microsoft.AspNetCore.Mvc;

namespace VerticalSliceApp.Api.Common;

[Route("api/[controller]")]
[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
}
