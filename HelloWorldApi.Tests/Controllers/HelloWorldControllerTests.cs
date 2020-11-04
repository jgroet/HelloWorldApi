using HelloWorldApi.Controllers;
using Xunit;

namespace HelloWorldApi.Tests.Controllers
{
	public class HelloWorldControllerTests
	{
		[Fact]
		public void GetReturnsHelloWorld()
		{
			Assert.Equal("Hello World", new HelloWorldController().Get());
		}
	}
}
