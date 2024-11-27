using System;
using System.Collections.Generic;

public class FunctionCache<TKey, TResult>
{
    private readonly Dictionary<TKey, CacheItem> cache = new Dictionary<TKey, CacheItem>();
    private readonly TimeSpan defaultExpiration;

    // Конструктор з можливістю встановлення стандартного терміну дії кешу
    public FunctionCache(TimeSpan? expiration = null)
    {
        defaultExpiration = expiration ?? TimeSpan.FromMinutes(10); // Стандартний термін дії кешу - 10 хвилин
    }

    // Делегат для користувацьких функцій
    public delegate TResult Func(TKey key);

    // Клас для зберігання кешованих значень разом з часом їхнього створення
    private class CacheItem
    {
        public TResult Value { get; }
        public DateTime Expiration { get; }

        public CacheItem(TResult value, TimeSpan expiration)
        {
            Value = value;
            Expiration = DateTime.Now.Add(expiration);
        }

        public bool IsExpired => DateTime.Now >= Expiration;
    }

    // Метод для отримання результату з кешу або виконання функції
    public TResult GetOrAdd(TKey key, Func func, TimeSpan? expiration = null)
    {
        if (cache.ContainsKey(key))
        {
            var cacheItem = cache[key];
            if (!cacheItem.IsExpired)
            {
                return cacheItem.Value;
            }
            else
            {
                // Видаляємо прострочене значення
                cache.Remove(key);
            }
        }

        // Виконуємо функцію, якщо результат не знайдено або він прострочений
        TResult result = func(key);
        cache[key] = new CacheItem(result, expiration ?? defaultExpiration);
        return result;
    }

    // Метод для очищення кешу
    public void Clear()
    {
        cache.Clear();
    }

    // Метод для видалення певного елемента з кешу
    public bool Remove(TKey key)
    {
        return cache.Remove(key);
    }
}
