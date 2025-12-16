namespace Pejvak_Product.Domain.T_Products
{
    public class T_Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ExclusiveCode { get; set; } = string.Empty;
        public string ProductType { get; set; } = string.Empty;
        public int AssociateId { get; set; }
        public int ProductGroupId { get; set; }
        public short IsActive { get; set; }
        public short IsDeleted { get; set; }
        public long Price { get; set; }
        public short IsCenter { get; set; }
        public string? Prefix { get; set; }
        public double ClientDiscountPercantage { get; set; }
        public int? ProductClassId { get; set; }
        public int ProductTypeId { get; set; }
        public string? Pic1 { get; set; }
        public string? Pic2 { get; set; }
        public string? Pic3 { get; set; }
        public string? ExclusiveSetting { get; set; }
        public long? ActivationPrice { get; set; }
        public short? IsUpdateNecessery { get; set; }
        public string? PicLogo { get; set; }
        public string? ProductDescriptionLink { get; set; }
        public string? ProductLink { get; set; }
        public string? Description { get; set; }
    }
}
