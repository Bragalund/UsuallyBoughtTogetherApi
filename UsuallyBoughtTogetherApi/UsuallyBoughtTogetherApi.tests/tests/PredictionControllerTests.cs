using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
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
        public async void test_WhenSeedingEntitiesDirectlyToDatabase_shouldCreateModelAtStartupOfApplication()
        {
            
        }

        [Fact]
        public void TestGettingPrediction_WhenDatabaseContainsProductEntryEntities_ControllerShouldReturnPredictions()
        {
            // ARRANGE
            
            
            // ACT
            
            
            // ASSERT
            
            
        }

        [Fact]
        public async void Test_WhenAddingEntitiesThroughController_ItShouldBePossibleToGetPrediction()
        {
            // ARRANGE
            var productIds = ObjectCreator.CreateListOfInts();
            var serializedProductIds = JsonConvert.SerializeObject(productIds);
            var stringContent = new StringContent(serializedProductIds, Encoding.UTF8, "application/json");
            var postResult = await _httpClient.PostAsync("/api/productentries", stringContent);
            Assert.Equal(201, (int)result.StatusCode);
            
            // ACT
            var result = await _httpClient.GetAsync("api/predictions/")
            
            // ASSERT
            
            
        }
    }
}