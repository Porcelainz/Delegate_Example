public class TaskEventArgs : EventArgs
{
    public TaskBase Task { get; }
    public string NextTaskName;
    static public int CompletedTaskCount;
    public TaskEventArgs(TaskBase task, string nextTaskName = "No next Task")
    {
        Task = task;
        NextTaskName = nextTaskName;
        ++CompletedTaskCount;
    }
}