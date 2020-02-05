using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using UsuallyBoughtTogetherApi.tests.TestUtils;
using Xunit;

namespace UsuallyBoughtTogetherApi.tests.tests
{
    public class PredictionControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public PredictionControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _httpClient = factory.CreateClient(new WebApplicationFactoryClientOptions()
            {
                AllowAutoRedirect = true
            });
        }

        [Fact]
        public void TestGettingPrediction_WhenDatabaseContainsProductEntryEntities_ControllerShouldReturnPredictions()
        {
            // ARRANGE
            
            
            // ACT
            
            
            // ASSERT
            
            
        }
    }
}