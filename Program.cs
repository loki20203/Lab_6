public class Program
{
    public static void Main()
    {
        Repository<Person> personRepository = new Repository<Person>();

        // Додаємо осіб до репозиторію
        personRepository.Add(new Person("Alice", 30));
        personRepository.Add(new Person("Bob", 20));
        personRepository.Add(new Person("Charlie", 25));
        personRepository.Add(new Person("David", 30));

        // Знаходимо осіб старше 25 років
        List<Person> olderThan25 = personRepository.Find(p => p.Age > 25);
        Console.WriteLine("Persons older than 25:");
        foreach (var person in olderThan25)
        {
            Console.WriteLine(person);
        }

        // Знаходимо осіб з ім'ям, що починається на 'A'
        List<Person> nameStartsWithA = personRepository.Find(p => p.Name.StartsWith("A"));
        Console.WriteLine("\nPersons with name starting with 'A':");
        foreach (var person in nameStartsWithA)
        {
            Console.WriteLine(person);
        }
    }
}