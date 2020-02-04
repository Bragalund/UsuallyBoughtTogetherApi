using System.Collections.Generic;
using UsuallyBoughtTogetherApi.Dtos;

namespace UsuallyBoughtTogetherApi.Services
{
    public interface IDataService
    {
        ProductEntryDto SaveProductEntryDto(ProductEntryDto productEntryDto);
        List<ProductEntryDto> CreateAllCombinationsOfProductsAndSave(List<int> producIds);
    }
}