using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество людей в списке:");
            int n;
            for (;;)
            {
                if (Int32.TryParse(Console.ReadLine(), out n))
                {
                    if (n > 0)
                        break;
                }
                Console.WriteLine("Нужно ввести целое положительное число!");
                Console.WriteLine("Введите количество людей в списке:");
            }

            var a = new List<Person>
            {
                new Person("Иван", 31, Sex.Male, 400),
                new Person("Женя", 24, Sex.Male, 2100),
                new Person("Даша", 22, Sex.Female, 570),
                new Person("Леша", 25, Sex.Male, 14758),
                new Person("Соня", 27, Sex.Female, 4792),
                new Person("Ефросинья", 31, Sex.Female, 14758)
            };

            var lst = new List<Person>();

            var rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < n; i++)
            {
                if (i < a.Count)
                    lst.Add(a[i]);
                else
                    lst.Add(new Person(a[i % a.Count].Name + " " + i / a.Count, rnd.Next(15) + 18, rnd.Next(2) == 0 ? Sex.Female : Sex.Male, rnd.Next(20000)));
            }

            var t1 = DateTime.Now;
            var maxAge = lst.Max(x => x.Age);
            var oldest = lst.FirstOrDefault(x => x.Age == maxAge);
            var t2 = DateTime.Now;
            Console.WriteLine("Самый старший: " + oldest);
            Console.WriteLine((t2 - t1).TotalMilliseconds);
            var t3 = DateTime.Now;
            var oldest2 = lst.OrderByDescending(x => x.Age).FirstOrDefault();
            var t4 = DateTime.Now;
            Console.WriteLine("Самый старший: " + oldest2);
            Console.WriteLine((t4 - t3).TotalMilliseconds);

            var richest = lst.OrderByDescending(x => x.Balance).FirstOrDefault();
            Console.WriteLine("Самый богатый: " + richest);

            var oldestAndRichest = lst.OrderByDescending(x => x.Age).ThenByDescending(x => x.Balance).FirstOrDefault();
            Console.WriteLine("Самый старший и богатый: " + oldestAndRichest);

            var countOfNotPoor = lst.Count(x => x.Balance > 4000);
            Console.WriteLine("людей имеют баланс выше 4000 рублей: " + countOfNotPoor);

            if (lst.Count < 10)
            {
                var sortAge = lst.OrderBy(x => x.Age);
                Console.WriteLine("");
                Console.WriteLine("Отсортировны по возрасту:");
                foreach (var x in sortAge)
                    Console.WriteLine(x);
                var sortSex = lst.OrderBy(x => x.Sex);
                Console.WriteLine("");
                Console.WriteLine("Отсортировны по полу:");
                foreach (var x in sortSex)
                    Console.WriteLine(x);
                var sortBalance = lst.OrderBy(x => x.Balance);
                Console.WriteLine("");
                Console.WriteLine("Отсортировны по балансу:");
                foreach (var x in sortBalance)
                    Console.WriteLine(x);
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Было принято решение не выводить на печать такой большой список");
            }
        }
    }
}
