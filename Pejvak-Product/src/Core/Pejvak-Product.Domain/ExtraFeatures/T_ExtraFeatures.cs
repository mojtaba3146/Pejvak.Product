namespace Pejvak_Product.Domain.ExtraFeatures
{
    public class T_ExtraFeatures
    {
        public int Id { get; set; }
        public int? ProductInstanceId { get; set; }
        public string? ExtraFeatures { get; set; }
        public short? IsDeleted { get; set; }
        public short? Confirmed { get; set; }
        public int? Count { get; set; }
    }
}
