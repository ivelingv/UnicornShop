namespace UnicornShop.Application.Services.DTO
{
    public sealed class CreateProductDTO
    {
        public string Name { get; }
        public string Description { get; }
        public int Quanitity { get; }
        public long? CategoryId { get; }
        public decimal PriceAmount { get; }
        public string PriceCurrency { get; }
    }

    public sealed class UpdateProductDTO
    {
        public string Name { get; }
        public string Description { get; }
        public int Quanitity { get; }
    }
}
