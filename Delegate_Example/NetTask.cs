public class NetTask : TaskBase
{
    private string NetTypeName;

    public NetTask(string Name, string NetTypeName, Action<string> Callback) : base(Name, Callback) {
        this.NetTypeName = NetTypeName;
    }

    public override void Execute()
    {
        Callback?.Invoke($"網路任務{Name} 網路類型: {NetTypeName}");
    }
}