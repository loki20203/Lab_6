using System;
using System.Collections.Generic;

public class Repository<T>
{
    private List<T> items = new List<T>();

    // Делегат Criteria<T> для перевірки умови
    public delegate bool Criteria(T item);

    // Метод для додавання елемента до репозиторію
    public void Add(T item)
    {
        items.Add(item);
    }

    // Метод для знаходження елементів за критерієм
    public List<T> Find(Criteria criteria)
    {
        List<T> result = new List<T>();
        foreach (var item in items)
        {
            if (criteria(item))
            {
                result.Add(item);
            }
        }
        return result;
    }
}
