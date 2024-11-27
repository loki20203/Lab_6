public class Program
{
    public static void Main()
    {
        // Використання для типу int
        Calculator<int>.Operation intAdd = (a, b) => a + b;
        Calculator<int>.Operation intSubtract = (a, b) => a - b;
        Calculator<int>.Operation intMultiply = (a, b) => a * b;
        Calculator<int>.Operation intDivide = (a, b) => a / b;

        Console.WriteLine("Int Operations:");
        Console.WriteLine($"Add: {Calculator<int>.Add(5, 3, intAdd)}");
        Console.WriteLine($"Subtract: {Calculator<int>.Subtract(5, 3, intSubtract)}");
        Console.WriteLine($"Multiply: {Calculator<int>.Multiply(5, 3, intMultiply)}");
        Console.WriteLine($"Divide: {Calculator<int>.Divide(5, 3, intDivide)}");

        // Використання для типу double
        Calculator<double>.Operation doubleAdd = (a, b) => a + b;
        Calculator<double>.Operation doubleSubtract = (a, b) => a - b;
        Calculator<double>.Operation doubleMultiply = (a, b) => a * b;
        Calculator<double>.Operation doubleDivide = (a, b) => a / b;

        Console.WriteLine("\nDouble Operations:");
        Console.WriteLine($"Add: {Calculator<double>.Add(5.5, 3.3, doubleAdd)}");
        Console.WriteLine($"Subtract: {Calculator<double>.Subtract(5.5, 3.3, doubleSubtract)}");
        Console.WriteLine($"Multiply: {Calculator<double>.Multiply(5.5, 3.3, doubleMultiply)}");
        Console.WriteLine($"Divide: {Calculator<double>.Divide(5.5, 3.3, doubleDivide)}");
    }
}