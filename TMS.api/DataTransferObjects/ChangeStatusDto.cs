namespace TMS.api.DataTransferObjects
{
    public class ChangeStatusDto
    {
        public TMS.api.Utils.TaskStatus Status { get; set; } = TMS.api.Utils.TaskStatus.InProgress;
        public Guid TaskID { get; set; }
    }
}
