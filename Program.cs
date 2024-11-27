using System;

public class Program
{
    public static void Main()
    {
        // Створюємо кеш з терміном дії за замовчуванням - 5 хвилин
        var cache = new FunctionCache<int, string>(TimeSpan.FromMinutes(5));

        // Функція для отримання значень
        string GetValue(int key)
        {
            Console.WriteLine($"Computing value for key {key}");
            return $"Value for key {key}";
        }

        // Використовуємо кеш для отримання значень
        string value1 = cache.GetOrAdd(1, GetValue);
        Console.WriteLine(value1);

        // Повторне отримання того ж значення з кешу
        string value2 = cache.GetOrAdd(1, GetValue);
        Console.WriteLine(value2);

        // Отримання нового значення з іншим ключем
        string value3 = cache.GetOrAdd(2, GetValue);
        Console.WriteLine(value3);

        // Чекаємо 6 хвилин, щоб перевірити термін дії кешу (для демонстрації)
        System.Threading.Thread.Sleep(TimeSpan.FromMinutes(6));

        // Отримання значення після закінчення терміну дії кешу
        string value4 = cache.GetOrAdd(1, GetValue);
        Console.WriteLine(value4);
    }
}
