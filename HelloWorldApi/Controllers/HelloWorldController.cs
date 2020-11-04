using Microsoft.AspNetCore.Mvc;

namespace HelloWorldApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class HelloWorldController : ControllerBase
	{
		[HttpGet]
		public string Get()
		{
			return "Hello World";
		}
	}
}
