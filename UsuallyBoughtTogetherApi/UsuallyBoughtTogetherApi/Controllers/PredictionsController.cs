using Microsoft.AspNetCore.Mvc;
using UsuallyBoughtTogetherApi.Services;

namespace UsuallyBoughtTogetherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictionsController : ControllerBase
    {
        private readonly IPredictionService _predictionService;
        public PredictionsController(IPredictionService predictionService)
        {
            _predictionService = predictionService;
        }

        [HttpGet("{id}/{countOfResults}")]
        public IActionResult GetBestPredictionForProduct(int id, int countOfResults)
        {
            var result = _predictionService.GetAssociatedVareIdsWithBestPrediction(id, countOfResults);
            return Ok(result);
        }
        
    }
}