namespace Pejvak_Product.Services.ProductInstanceProperties.Contracts.Dtos
{
    public class GetProductInstancePropertyDto
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string? Version { get; set; }
        public string? Properties { get; set; }
    }
}
