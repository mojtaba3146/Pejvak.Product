namespace Pejvak_Product.Services.ProductHolders.Contracts.Dtos
{
    public class GetUserAvailableFeaturesDto
    {
        public int ProductInstanceId { get; set; }
        public int ProductHolderId { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public List<GetUserbuyedProductPropertiesDto> UserbuyedProductProperties { get; set; } = new();
        public List<GetProductPropertiesDto> ProductProperties { get; set; } = new();
        public List<GetDefaultProductPropertiesDto> DefaultProductProperties { get; set; } = new();
        public int? AgentId { get; set; }
        public string? LockSerial { get; set; }
        public DateTime? ProductDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}

public class GetProductPropertiesDto
{
    public int PropertyId { get; set; }
    public string? PropertyTitle { get; set; }
    public string? PropertyUnicode { get; set; }
    public long Price { get; set; }
    public string? PriceDescription { get; set; }
}

public class GetDefaultProductPropertiesDto 
{
    public int PropertyId { get; set; }
    public string? PropertyTitle { get; set; }
    public string? PropertyUnicode { get; set; }
    public long Price { get; set; }
    public string? PriceDescription { get; set; }
}


public class GetUserbuyedProductPropertiesDto
{
    public int PropertyId { get; set; }
    public string? PropertyTitle { get; set; }
}