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
/*
        [HttpGet("{id}")]
        public IActionResult GetBestPredictionForProduct(int id)
        {
            var result = _predictionService.GetAssociatedVareIdsWithBestPrediction(id, 5);
        }
        */
    }
}