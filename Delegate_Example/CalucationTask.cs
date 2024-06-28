public class CalculationTask : TaskBase
{
    private int input;

    public CalculationTask(string name, int input, Action<string> callback)
        : base(name, callback)
    {
        this.input = input;
    }

    public override void Execute()
    {
        // 模擬計算
        int result = input * 2;
        Callback?.Invoke($"計算任務 {Name} 的結果是: {result}");
    }
}