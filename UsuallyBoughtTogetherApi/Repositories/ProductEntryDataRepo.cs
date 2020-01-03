using System;
using System.Collections.Generic;
using UsuallyBoughtTogetherApi.Entities;

namespace UsuallyBoughtTogetherApi.Repositories
{
    public class ProductEntryDataRepo : IProductEntryDataRepo
    {
        public List<ProductEntryEntity> GetAllProductEntryEntities()
        {
            throw new NotImplementedException();
        }

        public List<ProductEntryEntity> GetAllProductEntryEntitiesFromCountOfDaysBackInTime(int days)
        {
            throw new NotImplementedException();
        }

        public List<ProductEntryEntity> SaveProductEntryEntities(List<ProductEntryEntity> productEntryEntities)
        {
            throw new NotImplementedException();
        }

        public List<ProductEntryEntity> DeleteProductEntryEntitiesOlderThanDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}