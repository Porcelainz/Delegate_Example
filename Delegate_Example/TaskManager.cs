public class TaskManager
{
    private int count;
    private List<TaskBase> tasks = new List<TaskBase>();
    
    // 事件，用於在任務完成後通知訂閱者
    public event EventHandler<TaskEventArgs>? TaskCompleted;
    public delegate void TaskStart(string name);
    public event TaskStart OntaskStart;
    //public event EventHandler OntaskStart;
    public string name;

    public TaskManager(string name)
    {
        this.name = name;
    }

    // 添加任務方法
    public void AddTask(TaskBase task)
    {
        tasks.Add(task);
    }

    public void RemoveTask(string taskName)
    {
        tasks.Remove(GetTaskByName(taskName));
    }

    public TaskBase GetTaskByName(string taskName)
    {
        return tasks.Find(task => task.Name == taskName);
    }

    // 執行所有任務的方法
    public void ExecuteAllTasks()
    {
        foreach (var task in tasks)
        {   
            OntaskStart(name);
            //OntaskStart.Invoke(this, EventArgs.Empty);
            task.Execute();
            OnTaskCompleted(task);
        }
    }

    // 任務完成後觸發事件的方法
    protected virtual void OnTaskCompleted(TaskBase task)
    {
        if (count < tasks.Count - 1)
        {
            TaskCompleted?.Invoke(this, new TaskEventArgs(task, tasks[++count].Name));
        }
        else
        {
            TaskCompleted?.Invoke(this, new TaskEventArgs(task));
        }
    }
}