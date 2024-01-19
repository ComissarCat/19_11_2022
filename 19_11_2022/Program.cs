using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_11_2022
{
    struct Article
    {
        static int last_id = 0;
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public Article(string name, double price)
        {
            Id = ++last_id;
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            return $"Код товара: {Id}\nНаименование: {Name}\nСтоимость: {Price}";
        }
    }
    struct Client
    {
        static int last_id = 0;
        public int Id { get; private set; }
        public string FIO { get; private set; }
        public string Address { get; private set; }
        public long Phone_number { get; private set; }
        public int Number_of_orders { get; private set; }
        public int Sum_of_all_orders { get; private set; }
        public Client(string fIO, string address, long phone_number, int number_of_orders, int sum_of_all_orders)
        {
            Id = ++last_id;
            FIO = fIO;
            Address = address;
            Phone_number = phone_number;
            Number_of_orders = number_of_orders;
            Sum_of_all_orders = sum_of_all_orders;
        }
        public override string ToString()
        {
            return $"Код клиента: {Id}\nФИО: {FIO}\nАдрес: {Address}\nНомер телефона: {Phone_number}\nКоличество заказов: {Number_of_orders}\n" +
                $"Общая сумма заказов: {Sum_of_all_orders}";
        }
    }
    struct Student
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Patronymic { get; private set; }
        public string Group { get; private set; }
        public int Age { get; private set; }
        List<List<int>> marks;
        public Student(string name, string surname, string patronymic, string group, int age)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Group = group;
            Age = age;
            marks = new List<List<int>>
            {
                new List<int>(),
                new List<int>(),
                new List<int>()
            };
        }
        public void Add_mark()
        {
            int subject;
            do
            {
                Console.WriteLine("Выберите предмет для добавления оценок:\n\t1 - Программирование\n\t2 - Администрирование\n" +
                    "\t3 - Дизайн\n\t0 - Отмена");
                subject = Convert.ToInt32(Console.ReadLine());
            } while (subject < 0 || subject > 3);
            Console.WriteLine("Вводите оценки от 1 до 12, 0 для выхода");
            int mark;
            while(true)
            {
                mark = Convert.ToInt32(Console.ReadLine());
                if (mark == 0) break;
                if (mark > 0 && mark < 13) marks[subject - 1].Add(mark);
                else continue;
            }
        }
        public void Get_average_mark_by_subject()
        {
            int subject;
            do
            {
                Console.WriteLine("Выберите предмет для расчёта среднего балла:\n\t1 - Программирование\n\t2 - Администрирование\n" +
                    "\t3 - Дизайн\n\t0 - Отмена");
                subject = Convert.ToInt32(Console.ReadLine());
            } while (subject < 0 || subject > 3);
            if (subject > 0)
            {
                double average = 0;
                int counter = 0;
                for (; counter < marks[subject - 1].Count; counter++) average += marks[subject - 1][counter];
                average /= counter;
                Console.WriteLine($"Средний балл равен {average}");
            }
        }
        public override string ToString()
        {
            string info = "";
            info += $"ФИО: {Surname} {Name} {Patronymic}\n";
            info += $"Группа: {Group}\n";
            info += $"Возраст: {Age}\n";
            info += "Оценки:\n";
            info += "Программирование:\t";
            for (int i = 0; i < marks[0].Count; i++) info += $"{marks[0][i]}\t";
            info += "\nАдминистрирование:\t";
            for (int i = 0; i < marks[1].Count; i++) info += $"{marks[1][i]}\t";
            info += "\nДизайн:\t\t\t";
            for (int i = 0; i < marks[2].Count; i++) info += $"{marks[2][i]}\t";
            return info;
        }
    }
        internal class Program
    {
        static void Main()
        {
            List<Article> articles = new List<Article>
            {
                new Article("Молоток", 500),
                new Article("Отвёртка шлицевая", 300),
                new Article("Отвёртка крестовая", 350)
            };
            foreach (Article article in articles) { Console.WriteLine(article); }
            Console.WriteLine(new string('-', 50));
            Client client = new Client("Иванов Иван Иванович", "ул. Пушкина, д. Колотушкина", 88005553535, 1, 1150);
            Console.WriteLine(client);
            Console.WriteLine(new string('-', 50));
            Student student = new Student("Иван", "Иванов", "Иванович", "101", 20);
            student.Add_mark();
            student.Add_mark();
            student.Add_mark();
            student.Get_average_mark_by_subject();
            student.Get_average_mark_by_subject();
            student.Get_average_mark_by_subject();
            Console.WriteLine(student);
        }
    }
}
