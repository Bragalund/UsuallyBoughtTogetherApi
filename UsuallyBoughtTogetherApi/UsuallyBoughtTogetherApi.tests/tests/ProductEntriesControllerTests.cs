using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using UsuallyBoughtTogetherApi.Entities;
using UsuallyBoughtTogetherApi.tests.TestUtils;
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
        public async void testAddingProducts_whenAddingList_ThereShouldBeProducedProductEntryEntitiesInDatabase()
        { 
            // ARRANGE
            var productIds = ObjectCreator.CreateListOfInts();
            var serializedProductIds = JsonConvert.SerializeObject(productIds);
            var stringContent = new StringContent(serializedProductIds, Encoding.UTF8, "application/json");
            
            // ACT
            var result = await _httpClient.PostAsync("/api/productentries", stringContent);

            // ASSERT
            Assert.Equal(201, (int)result.StatusCode);
            var contentAsString = await result.Content.ReadAsStringAsync();
            var deserializedResult = JsonConvert.DeserializeObject<List<ProductEntryEntity>>(contentAsString);
            Assert.NotEmpty(deserializedResult);
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