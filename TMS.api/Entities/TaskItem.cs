using TMS.api.Utils;

namespace TMS.api.Entities
{
    public class TaskItem:Audit
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Utils.TaskStatus Status { get; set; }
        public string Priority { get; set; } = null!;
        public DateTime DueDate { get; set; }
        public Guid AssignedToUserId { get; set; }
        public bool IsDeleted { get; set; }
        public int CtgryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
