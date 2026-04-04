namespace TMS.api.Entities
{
    public class Audit
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CreateById { get; set; }
        public int UpdateById { get; set; }
    }
}
