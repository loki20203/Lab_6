using System;
using System.Collections.Generic;

public class TaskScheduler<TTask, TPriority> where TPriority : IComparable<TPriority>
{
    // Делегат для виконання завдання
    public delegate void TaskExecution(TTask task);

    // Клас для зберігання завдань з пріоритетом
    private class PriorityTask : IComparable<PriorityTask>
    {
        public TTask Task { get; }
        public TPriority Priority { get; }

        public PriorityTask(TTask task, TPriority priority)
        {
            Task = task;
            Priority = priority;
        }

        public int CompareTo(PriorityTask other)
        {
            // Більший пріоритет виконується раніше
            return other.Priority.CompareTo(Priority);
        }
    }

    // Черга з пріоритетами для зберігання завдань
    private readonly SortedSet<PriorityTask> taskQueue = new SortedSet<PriorityTask>();

    // Метод для додавання завдання з пріоритетом
    public void AddTask(TTask task, TPriority priority)
    {
        taskQueue.Add(new PriorityTask(task, priority));
    }

    // Метод для виконання завдання з найвищим пріоритетом
    public void ExecuteNext(TaskExecution execute)
    {
        if (taskQueue.Count > 0)
        {
            var nextTask = taskQueue.Min;
            taskQueue.Remove(nextTask);
            execute(nextTask.Task);
        }
        else
        {
            Console.WriteLine("No tasks to execute.");
        }
    }

    // Метод для отримання завдання з черги
    public TTask GetNextTask()
    {
        if (taskQueue.Count > 0)
        {
            var nextTask = taskQueue.Min;
            taskQueue.Remove(nextTask);
            return nextTask.Task;
        }
        return default;
    }
}