using System;

namespace UsuallyBoughtTogetherApi.Entities
{
    public class ProductEntryEntity
    {
        public int ProductId { get; set; }
        public int CoPurchaseProductId { get; set; }
        public DateTime Created { get; set; }
    }
}