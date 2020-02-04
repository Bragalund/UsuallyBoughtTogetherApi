using System;
using System.Collections.Generic;
using System.Linq;
using UsuallyBoughtTogetherApi.Entities;

namespace UsuallyBoughtTogetherApi.Repositories
{
    public class ProductEntryDataRepo : IProductEntryDataRepo
    {
        
        public List<ProductEntryEntity> GetAllProductEntryEntities()
        {
            using (var context = new PredictionContext())
            {
                return context.ProductEntryEntities.ToList();
            }
        }

        public List<ProductEntryEntity> GetAllProductEntryEntitiesFromDaysBackInTime(DateTime dateTime)
        {
            using (var context = new PredictionContext())
            {
                return context.ProductEntryEntities.Where(productEntryEntity => productEntryEntity.Created < dateTime)
                    .ToList();
            }
        }

        public List<ProductEntryEntity> SaveProductEntryEntities(List<ProductEntryEntity> productEntryEntities)
        {
            throw new NotImplementedException();
        }

        public List<ProductEntryEntity> DeleteProductEntryEntitiesOlderThanDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public List<ProductEntryEntity> GetAssociatedVareIds(int vareId)
        {
            using (var context = new PredictionContext())
            {
                return context.ProductEntryEntities.Where(productEntity => productEntity.ProductId == vareId).ToList();
            }
            
        }
    }
}