using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UsuallyBoughtTogetherApi.Dtos;
using UsuallyBoughtTogetherApi.Services;

namespace UsuallyBoughtTogetherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductEntriesController : ControllerBase
    {
        private readonly IDataService _dataService;

        public ProductEntriesController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpPost]
        public IActionResult AddProductEntriesForListOfIds(List<int> productIds)
        {
            var savedProductEntries = _dataService.CreateAllCombinationsOfProductsAndSave(productIds);
            return Ok(savedProductEntries);
        }
    }
}