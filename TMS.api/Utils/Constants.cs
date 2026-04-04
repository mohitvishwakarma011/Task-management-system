namespace TMS.api.Utils
{
    public enum TaskStatus
    {
        ToDo = 1,
        InProgress,
        Completed
    }

    public struct TaskPriority
    {
        public const string Low = "Low";
        public const string Medium = "Medium";
        public const string High = "High";
    }

}
