namespace Pejvak_Product.Services.ProductHolders.Contracts.Dtos
{
    public class GetUserAvailableFeaturesDto
    {
        public int ProductInstanceId { get; set; }
        public int ProductHolderId { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? AgentId { get; set; }
        public string? LockSerial { get; set; }
        public DateTime? ProductDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
