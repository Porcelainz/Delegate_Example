public class IoTask : TaskBase
{
    private string filePath;

    public IoTask(string name, string filePath, Action<string> callback)
        : base(name, callback)
    {
        this.filePath = filePath;
    }

    public override void Execute()
    {
        // 模擬IO操作
        Callback?.Invoke($"IO任務 {Name} 已處理文件: {filePath}");
    }
}