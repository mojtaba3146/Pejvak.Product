namespace Pejvak_Product.Domain.ProductProductGroups
{
    public class T_ProductProductGroup
    {
        public int Id { get; set; }
        public string ProductIds { get; set; } = string.Empty;
        public int PropertyId { get; set; }
        public int IsDeleted { get; set; }
        public int IsActive { get; set; }
    }
}

