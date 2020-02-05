using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.ML;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using Microsoft.ML.Trainers.Recommender;
using UsuallyBoughtTogetherApi.Constants;
using UsuallyBoughtTogetherApi.Dtos;
using UsuallyBoughtTogetherApi.Entities;
using UsuallyBoughtTogetherApi.Repositories;

namespace UsuallyBoughtTogetherApi.Services
{
    public class PredictionService : IPredictionService
    {
        private MLContext mlContext = new MLContext();
        private IProductEntryDataRepo _productEntryDataRepo;
        private readonly PredictionEnginePool<ProductEntryDto, CoPurchasePredictionDto> _predictionEnginePool;

        public PredictionService(IProductEntryDataRepo productEntryDataRepo,
            PredictionEnginePool<ProductEntryDto, CoPurchasePredictionDto> predictionEnginePool)
        {
            _productEntryDataRepo = productEntryDataRepo;
            _predictionEnginePool = predictionEnginePool;
        }

        private IDataView LoadTrainingDataIntoMlContext(DateTime fromDateTime)
        {
            var productEntryEntities = _productEntryDataRepo.GetAllProductEntryEntitiesFromDaysBackInTime(fromDateTime);
            return mlContext.Data.LoadFromEnumerable(productEntryEntities);
        }

        public MatrixFactorizationPredictionTransformer TrainModel(string label, double alpha, double lambda, double c, DateTime fromTime)
        {
            var options = CreateOptionsForModel(label, alpha, lambda, c);
            var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);
            var trainingData = LoadTrainingDataIntoMlContext(fromTime);
            var model = est.Fit(trainingData);
            mlContext.Model.Save(model, trainingData.Schema, FilePathConstants.RecommenderModelPath);
            return model;
        }

        public List<CoPurchasePredictionResultDto> GetAssociatedVareIdsWithBestPrediction(int id, int countOfResults)
        {
            // Get all rows from db with this id(eiter copurchase or main id)
            var coPurchasePredictionResultDtos = new List<CoPurchasePredictionResultDto>();

            // add to list,which is sorted by predictionscore
            foreach (var productEntryEntity in _productEntryDataRepo.GetAssociatedVareIds(id))
            {
                var prediction = _predictionEnginePool.Predict(new ProductEntryDto(id, productEntryEntity.CoPurchaseProductId));
                coPurchasePredictionResultDtos.Add(new CoPurchasePredictionResultDto(prediction.Score, productEntryEntity.CoPurchaseProductId));
            }
            
            // sort the list
            coPurchasePredictionResultDtos.Sort((x, y) => x.CompareTo(y));

            // pick those on top 
            return coPurchasePredictionResultDtos.GetRange(0, countOfResults);
        }

        private MatrixFactorizationTrainer.Options CreateOptionsForModel(string label, double alpha, double lambda,
            double c)
        {
            MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
            options.MatrixColumnIndexColumnName = nameof(ProductEntryDto.ProductId);
            options.MatrixRowIndexColumnName = nameof(ProductEntryDto.CoPurchaseProductId);
            options.LabelColumnName = label;
            options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
            options.Alpha = alpha; //0.01;
            options.Lambda = lambda; //0.025;
            // options.K = 100;
            options.C = c; //0.00001;
            return options;
        }
    }
}