using System;
using System.Collections.Generic;
using UsuallyBoughtTogetherApi.Entities;

namespace UsuallyBoughtTogetherApi.Repositories
{
    public interface IProductEntryDataRepo
    {
        List<ProductEntryEntity> GetAllProductEntryEntities();
        List<ProductEntryEntity> GetAllProductEntryEntitiesFromCountOfDaysBackInTime(int days);
        List<ProductEntryEntity> SaveProductEntryEntities(List<ProductEntryEntity> productEntryEntities);
        List<ProductEntryEntity> DeleteProductEntryEntitiesOlderThanDate(DateTime dateTime);
    }
}