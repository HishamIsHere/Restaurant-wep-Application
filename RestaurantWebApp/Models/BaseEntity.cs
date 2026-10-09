namespace WebAppTemplate.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        //Audit Columns
        public string? CreatedBy { get; set; }
        public string? CreateDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? UpdateDate { get; set; }
    }
}
