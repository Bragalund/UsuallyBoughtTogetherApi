using System;
using System.Collections.Generic;
using UsuallyBoughtTogetherApi.Dtos;
using UsuallyBoughtTogetherApi.Entities;
using UsuallyBoughtTogetherApi.Repositories;

namespace UsuallyBoughtTogetherApi.Services
{
    public class DataService : IDataService
    {
        private readonly IProductEntryDataRepo _productEntryDataRepo;

        public DataService(IProductEntryDataRepo productEntryDataRepo)
        {
            _productEntryDataRepo = productEntryDataRepo;
        }

        public List<ProductEntryEntity> CreateAllCombinationsOfProductsAndSave(List<int> productIds)
        {
            List<ProductEntryEntity> productEntryEntities = new List<ProductEntryEntity>();
            for (int i = 0; i < productIds.Count; i++)
            {
                for (int j = 0; j < productIds.Count; j++)
                {
                    if (i == j)
                    {
                        // dont add combination of same product id
                    }
                    else
                    {
                        var productEntryDto =
                            new ProductEntryEntity(new Guid(), productIds[i], productIds[j], DateTime.UtcNow);
                        productEntryEntities.Add(productEntryDto);
                    }
                }
            }

            return _productEntryDataRepo.SaveProductEntryEntities(productEntryEntities);
        }
    }
}