public class Program
{
    public static void Main()
    {
        var scheduler = new TaskScheduler<string, int>();

        // Метод для виконання завдань
        void ExecuteTask(string task)
        {
            Console.WriteLine($"Executing task: {task}");
        }

        // Додавання завдань з консолі
        while (true)
        {
            Console.WriteLine("Enter a task (or 'exit' to quit):");
            string input = Console.ReadLine();
            if (input.ToLower() == "exit")
                break;

            Console.WriteLine("Enter the task priority (integer):");
            int priority;
            while (!int.TryParse(Console.ReadLine(), out priority))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for priority:");
            }

            scheduler.AddTask(input, priority);

            Console.WriteLine("Enter 'execute' to run the next task or 'continue' to add more tasks:");
            string command = Console.ReadLine();
            if (command.ToLower() == "execute")
            {
                scheduler.ExecuteNext(ExecuteTask);
            }
        }
    }
}