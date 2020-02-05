using System;

namespace UsuallyBoughtTogetherApi.Entities
{
    public class ProductEntryEntity
    {
        public ProductEntryEntity(Guid productEntryId, int productId, int coPurchaseProductId, DateTime created)
        {
            ProductEntryId = productEntryId;
            ProductId = productId;
            CoPurchaseProductId = coPurchaseProductId;
            Created = created;
        }

        public Guid ProductEntryId { get; }
        public int ProductId { get; set; }
        public int CoPurchaseProductId { get; set; }
        public DateTime Created { get; set; }
    }
}