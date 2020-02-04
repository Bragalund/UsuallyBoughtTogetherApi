using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace UsuallyBoughtTogetherApi.tests.tests
{
    public class
        ProductEntriesControllerTests : IClassFixture<CustomWebApplicationFactory<UsuallyBoughtTogetherApi.Startup>>
    {
        private readonly HttpClient _httpClient;
        private readonly CustomWebApplicationFactory<UsuallyBoughtTogetherApi.Startup> _factory;

        public ProductEntriesControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _httpClient = factory.CreateClient(new WebApplicationFactoryClientOptions()
            {
                AllowAutoRedirect = true
            });
        }

        [Fact]
        public void testAddingProduct()
        {
        }

        [Fact]
        public async void test_whenApiIsRunning_ValuesControllerShouldReturn200Ok()
        {
            
            // Arrange
            var defaultPage = await _httpClient.GetAsync("/api/values");

            // Assert
            Assert.Equal(HttpStatusCode.OK, defaultPage.StatusCode);
            
        }
    }
}