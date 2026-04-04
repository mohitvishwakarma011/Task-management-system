namespace TMS.api.Entities
{
    public class Category : Audit
    {
        public int Id { get;set; }
        public string CategoryName { get; set; } = string.Empty;
        public string CategoryDescription { get; set; } = string.Empty;

    }
}
