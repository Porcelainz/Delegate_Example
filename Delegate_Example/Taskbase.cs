public abstract class TaskBase
{
    public string Name { get; set; }
    public Action<string> Callback { get; set; }

    public TaskBase(string name, Action<string> callback)
    {
        Name = name;
        Callback = callback;
    }

    public abstract void Execute();
}
