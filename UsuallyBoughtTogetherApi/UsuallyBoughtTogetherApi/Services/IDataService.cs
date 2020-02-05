using System.Collections.Generic;
using UsuallyBoughtTogetherApi.Dtos;
using UsuallyBoughtTogetherApi.Entities;

namespace UsuallyBoughtTogetherApi.Services
{
    public interface IDataService
    {
        List<ProductEntryEntity> CreateAllCombinationsOfProductsAndSave(List<int> productIds);
    }
}