namespace UsuallyBoughtTogetherApi.Dtos
{
    public class ProductEntryDto
    {
        public ProductEntryDto(int productId, int coPurchaseProductId)
        {
            ProductId = productId;
            CoPurchaseProductId = coPurchaseProductId;
        }

        public int ProductId { get; set; }
        public int CoPurchaseProductId { get; set; }
    }
}