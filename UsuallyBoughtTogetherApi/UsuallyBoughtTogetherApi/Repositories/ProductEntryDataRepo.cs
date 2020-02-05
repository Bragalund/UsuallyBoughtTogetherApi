using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UsuallyBoughtTogetherApi.Entities;

namespace UsuallyBoughtTogetherApi.Repositories
{
    public class ProductEntryDataRepo : IProductEntryDataRepo
    {
        private readonly PredictionContext _dbContext;
        public ProductEntryDataRepo(PredictionContext predictionContext)
        {
            _dbContext = predictionContext;
        }

        public List<ProductEntryEntity> GetAllProductEntryEntities()
        {
            return _dbContext.ProductEntryEntities.ToList();
        }

        public List<ProductEntryEntity> GetAllProductEntryEntitiesFromDaysBackInTime(DateTime dateTime)
        {
            return _dbContext.ProductEntryEntities.Where(productEntryEntity => productEntryEntity.Created < dateTime)
                    .ToList();
        }

        public List<ProductEntryEntity> SaveProductEntryEntities(List<ProductEntryEntity> productEntryEntities)
        {
            _dbContext.ProductEntryEntities.AddRange(productEntryEntities);
            return productEntryEntities;
        }

        public List<ProductEntryEntity> DeleteProductEntryEntitiesOlderThanDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public List<ProductEntryEntity> GetAssociatedVareIds(int vareId)
        {
            return _dbContext.ProductEntryEntities.Where(productEntity => productEntity.ProductId == vareId).ToList();
        }
    }
}