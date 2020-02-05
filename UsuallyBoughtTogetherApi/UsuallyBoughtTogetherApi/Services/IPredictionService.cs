using System;
using System.Collections.Generic;
using Microsoft.ML;
using Microsoft.ML.Trainers.Recommender;
using UsuallyBoughtTogetherApi.Dtos;

namespace UsuallyBoughtTogetherApi.Services
{
    public interface IPredictionService
    {
        MatrixFactorizationPredictionTransformer TrainModel(string label, double alpha, double lambda, double c, DateTime fromTime);
        List<CoPurchasePredictionResultDto> GetAssociatedVareIdsWithBestPrediction(int id, int countOfResults);
    }
}