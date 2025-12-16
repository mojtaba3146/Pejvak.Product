namespace Pejvak_Product.Services.ProductProductGroups.Contracts.Dtos
{
    public class GetProductProductGroupDto
    {
        public int Id { get; set; }
        public string ProductIds { get; set; } = string.Empty;
        public List<int> ProductIntIds { get; set; } = new List<int>();
    }
}
