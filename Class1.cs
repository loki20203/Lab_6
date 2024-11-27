using System;

public class Calculator<T> where T : struct
{
    // Делегати для арифметичних операцій
    public delegate T Operation(T a, T b);

    // Методи для арифметичних операцій
    public static T Add(T a, T b, Operation operation)
    {
        return operation(a, b);
    }

    public static T Subtract(T a, T b, Operation operation)
    {
        return operation(a, b);
    }

    public static T Multiply(T a, T b, Operation operation)
    {
        return operation(a, b);
    }

    public static T Divide(T a, T b, Operation operation)
    {
        return operation(a, b);
    }
}
