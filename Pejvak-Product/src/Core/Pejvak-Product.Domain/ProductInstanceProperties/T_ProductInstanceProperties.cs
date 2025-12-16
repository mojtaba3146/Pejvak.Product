namespace Pejvak_Product.Domain.ProductInstanceProperties
{
    public class T_ProductInstanceProperties
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string? Version { get; set; }
        public string? Properties { get; set; }
        public int? FatherId { get; set; }
        public int? IsActive { get; set; }
        public int? IsDeleted { get; set; }
    }
}
