namespace Pejvak_Product.Domain.ProductProperties
{
    public class T_ProductProperties
    {
        public int Id { get; set; }
        public string? PropertyTitle { get; set; }
        public string? UniqueCode { get; set; }
        public short? IsActive { get; set; }
        public short? IsDeleted { get; set; }
        public bool IsTimeSensitive { get; set; }
        public string? TimeSensitiveTitle { get; set; }
        public short? DayCount { get; set; }
        public string? SortKey { get; set; }
        public int? PropertyClassId { get; set; }
    }
}
