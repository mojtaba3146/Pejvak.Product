namespace Pejvak_Product.Domain.GroupPrices
{
    public class T_GroupPrice
    {
        public int Id { get; set; }
        public int? PropertyId { get; set; }
        public long? Price { get; set; }
        public int? CoefficientPriceClient { get; set; }
        public int? ProductGroupId { get; set; }
        public string? PixName { get; set; }
        public string? Description { get; set; }
        public short IsDeleted { get; set; }
        public short IsActive { get; set; }
        public byte CompatibilityTypeServserAndClientLookupId { get; set; }
        public string? VideoName { get; set; }
        public string? ThumbNames { get; set; }
        public string? FeaturesDescription { get; set; }
        public string? UsageDescription { get; set; }
        public string? DescriptionSummery { get; set; }
    }
}
