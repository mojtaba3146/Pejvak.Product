namespace Pejvak_Product.Domain.T_ProductHolders
{
    public class T_ProductHolder
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ProductInstanceId { get; set; }
        public int? AssignmentType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public short? IsDeleted { get; set; }
        public int? CustomerEdited { get; set; }
    }
}
