namespace TMS.api.Utils
{
    public enum TaskStatus
    {
        InProgress = 1,
        Hold,
        Completed
    }

    public struct TaskPriority
    {
        public const string Low = "Low";
        public const string Medium = "Medium";
        public const string High = "High";
    }

}
