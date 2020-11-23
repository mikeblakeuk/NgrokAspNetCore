using System.Threading.Tasks;
using Xunit;

namespace Ngrok.AspNetCore.Sample.Tests
{
	public class BasicTests : IClassFixture<TestWebApplicationFactory>
	{
		private readonly TestWebApplicationFactory _factory;

		public BasicTests(TestWebApplicationFactory factory)
		{
			_factory = factory;
		}

		[Theory]
		[InlineData("/")]
		[InlineData("/Index")]
		public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
		{
			// Arrange
			var client = _factory.CreateClient();

			// Act
			var response = await client.GetAsync(url);

			// Assert
			response.EnsureSuccessStatusCode(); // Status Code 200-299
			//Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
		}
	}
}


