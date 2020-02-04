using System;
using System.Collections.Generic;
using Microsoft.ML;
using UsuallyBoughtTogetherApi.Dtos;

namespace UsuallyBoughtTogetherApi.Services
{
    public interface IPredictionService
    {
        PredictionEngine<ProductEntryDto, CoPurchasePredictionDto> TrainModel(string label, double alpha, double lambda, double c, DateTime fromTime);
        List<CoPurchasePredictionResultDto> GetAssociatedVareIdsWithBestPrediction(int id, int countOfResults, PredictionEngine<ProductEntryDto, CoPurchasePredictionDto> predictionEngine);
    }
}