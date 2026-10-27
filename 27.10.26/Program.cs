using System;
using System.Linq;

namespace _27._10._26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ЗАДАНИЕ 1
            Console.WriteLine("===== ЗАДАНИЕ 1 =====");

            string[] candidates =
                { "Анна", "Борис", "Олег", "Ирина" };

            var deferredQuery = candidates
                .Where(name => name.Length == 4)
                .OrderBy(name => name);

            candidates[2] = "Игорь";

            Console.WriteLine("Отложенный запрос:");

            foreach (string name in deferredQuery)
            {
                Console.WriteLine(name);
            }

            var savedList = candidates
                .Where(name => name.Length == 4)
                .OrderBy(name => name)
                .ToList();

            candidates[0] = "Алена";

            Console.WriteLine("\nСохраненный список:");

            foreach (string name in savedList)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\nПовторный отложенный запрос:");

            foreach (string name in deferredQuery)
            {
                Console.WriteLine(name);
            }


            // ЗАДАНИЕ 2
            Console.WriteLine("\n===== ЗАДАНИЕ 2 =====");

            string[] products =
                { "laptop", "Phone", "TABLET", "Smartwatch" };

            bool allLongerThanThree =
                products.All(p => p.Length > 3);

            Console.WriteLine(
                "Все названия длиннее 3 символов: "
                + allLongerThanThree);

            bool anyStartsWithS = products.Any(
                p => p.StartsWith("S") || p.StartsWith("s"));

            Console.WriteLine(
                "Есть название на S или s: "
                + anyStartsWithS);

            bool standardContains = products.Contains("phone");

            Console.WriteLine(
                "Обычный Contains: " + standardContains);

            bool ignoreCaseContains = products.Contains(
                "phone", new IgnoreCaseComparer());

            Console.WriteLine(
                "Contains без учета регистра: "
                + ignoreCaseContains);


            // ЗАДАНИЕ 3
            Console.WriteLine("\n===== ЗАДАНИЕ 3 =====");

            User[] users =
            {
                new User("Tom", 20),
                new User("Bob", 25),
                new User("Sam", 30),
                new User("Alice", 22)
            };

            User firstOlderThan21 =
                users.First(u => u.Age > 21);

            Console.WriteLine(
                "Первый пользователь старше 21 года: "
                + firstOlderThan21.Name + ", "
                + firstOlderThan21.Age);

            User userOlderThan50 =
                users.FirstOrDefault(u => u.Age > 50);

            if (userOlderThan50 == null)
            {
                Console.WriteLine(
                    "Пользователь старше 50 лет не найден.");
            }
            else
            {
                Console.WriteLine(
                    "Найден пользователь: "
                    + userOlderThan50.Name);
            }

            User defaultUser = users.FirstOrDefault(
    u => u.Age > 50);

            if (defaultUser == null)
            {
                defaultUser = new User("Guest", 0);
            }

            Console.WriteLine(
                "Пользователь по умолчанию: "
                + defaultUser.Name + ", "
                + defaultUser.Age);


            User lastThreeLetterName =
                users.Last(u => u.Name.Length == 3);

            Console.WriteLine(
                "Последний пользователь с именем из 3 букв: "
                + lastThreeLetterName.Name + ", "
                + lastThreeLetterName.Age);

            Console.WriteLine("\nВсе задания выполнены.");
            Console.ReadKey();
        }
    }
}
