using System;
using System.Collections.Generic;

class Program
{
    static void Print(string x) => Console.WriteLine("→→→→ " + x + " ←←←←");
    //static void PrintStartInfo(object sender, EventArgs e) => Console.WriteLine($"~ {((TaskManager)sender).name} ~"); 
    static void PrintStartInfo(string name) => Console.WriteLine($"~ {name} ~");
    static void PrintInfor(object sender, TaskEventArgs e)
    {
        Console.WriteLine($"任務完成事件:  {e.Task.Name}");
        Console.WriteLine($"完成任務數量: {TaskEventArgs.CompletedTaskCount}");
        Console.WriteLine($"下一個任務: {e.NextTaskName}");
        Console.WriteLine("---------------------------\n");
    }
    
    static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager("第一個任務管理器");
        taskManager.OntaskStart += PrintStartInfo;
        taskManager.TaskCompleted += PrintInfor;
        // 添加計算任務
        taskManager.AddTask(new CalculationTask("計算任務1", 5, Print));
        taskManager.RemoveTask("計算任務1");
        // 添加IO任務
        taskManager.AddTask(new IoTask("IO任務1", "/path/to/file.txt", Print));
        // 添加網路任務
        taskManager.AddTask(new NetTask("網路任務1", "Wifi", Print));
        // 執行所有任務
        taskManager.ExecuteAllTasks();
    }
}
