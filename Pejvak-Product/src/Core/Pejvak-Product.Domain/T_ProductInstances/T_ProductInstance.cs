namespace Pejvak_Product.Domain.T_ProductInstances
{
    public class T_ProductInstance
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? AgentId { get; set; }
        public string? LockSerial { get; set; }
        public DateTime? ProductDate { get; set; }
        public short? IsDeleted { get; set; }
        public short? IsActive { get; set; }
        public string? GoogleRegistrationCode { get; set; }
        public bool? IsClient { get; set; }
        public string? Vip { get; set; }
        public short? NextProductId { get; set; }
        public short? IsPayed { get; set; }
        public int? SellerId { get; set; }
        public short? IsUpdateNecessary { get; set; }
        public string? PriviousLockData { get; set; }
        public string? OldLockData { get; set; }
        public int? AmaniUserId { get; set; }
        public int? UseExpiredSoftware { get; set; }
        public string? CurrentVersion { get; set; }
        public bool IsItPrince { get; set; }
        public byte StatusLock { get; set; }
        public byte ActivationStatus { get; set; }
        public DateTime? LastUpdateAt { get; set; }
        public string? NickName { get; set; }
        public int? JobId { get; set; }
        public int? JobCategoryId { get; set; }
    }
}
