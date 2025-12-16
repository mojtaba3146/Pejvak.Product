namespace Pejvak_Product.Services.ExtraFeatures.Contracts.Dtos
{
    public class GetExtraFeatureDto
    {
        public int Id { get; set; }
        public int? ProductInstanceId { get; set; }
        public string? ExtraFeatures { get; set; }
    }
}
