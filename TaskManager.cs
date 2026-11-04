namespace TaskManagementSystem
{
    public class TaskManager
    {
        List<TaskItem> tasks = new();

        public void AddTask(TaskItem task)
        {
            tasks.Add(task);
        }

        public void CompleteTask(TaskItem task)
        {
            task.MarkAsCompleted();
        }

        public void SaveTasks(string filePath)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(tasks);
            System.IO.File.WriteAllText(filePath, json);
        }

        public void LoadTasks(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                var json = System.IO.File.ReadAllText(filePath);
                tasks = System.Text.Json.JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            }
        }

        public void DisplayTasks()
        {
            Console.WriteLine("========== Tasks: ==========");
            foreach (var task in tasks)
            {
                Console.WriteLine($"Title: {task.Title}");
                Console.WriteLine($"Description: {task.Description}");
                Console.WriteLine($"Due Date: {task.DueDate}");
                Console.WriteLine($"Completed: {task.IsCompleted}");
            }
            Console.WriteLine("============================");
        }
    }
}
