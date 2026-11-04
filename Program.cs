using System;

namespace TaskManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Task Management System!");
            Console.Write("Enter the title of the task: ");
            string title = Console.ReadLine();
            Console.Write("Enter the description of the task: ");
            string description = Console.ReadLine();
            Console.Write("Enter the due date of the task (MM/dd/yyyy): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Is the task completed? (yes/no): ");
            bool isCompleted = Console.ReadLine().ToLower() == "yes";

            TaskItem task = new TaskItem(title, description, dueDate, isCompleted);

            TaskManager taskManager = new TaskManager();
            taskManager.AddTask(task);
            Console.WriteLine("Task added successfully!");

            
            taskManager.SaveTasks("tasks.json");
            taskManager.LoadTasks("tasks.json");
            taskManager.DisplayTasks();
        }
    }
}
