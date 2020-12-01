using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Регулярки
{
    class Program
    {
        public static void Print(string str) => Console.WriteLine(str);
        public static void RegexPart1()
        {
            Print($"Задания. Запишите регулярное выражение, соответствующее:" +
                "\n 1.дате в формате дд.мм.гг или дд.мм.гггг" +
                "\n 2.времени в формате чч.мм или чч: мм" + "" +
                " \n 3.целому числу(со знаком и без)" + " \n 4.вещественному числу(со знаком и без, с дробной частью и без, " +
                " с целой частью и без)");
            Console.WriteLine();
            Print("Первое задание:");
            Regex dateformat = new Regex(@"\d{2}\.\d{2}\.\d{4}");
            string date1 = "24.11.2020";
            string date2 = "24 ноября 2020 года";
            string date3 = "Срок сдачи задания: 25.11.2020";

            Console.WriteLine($"Первая дата: {date1}:{dateformat.IsMatch(date1)}");
            Console.WriteLine($"Вторая дата: {date2}:{dateformat.IsMatch(date2)}");
            Console.WriteLine($"Третья дата: {date3}:{dateformat.IsMatch(date3)}");
            Console.WriteLine();

            Print("Второе задание:");
            Regex timeformat = new Regex(@"\d{2}\:\d{2}");
            string time1 = "21:24";
            string time2 = "25 минут десятого";
            string time3 = "Сейчас 21:24";
            Console.WriteLine($"Первое время: {time1}:{timeformat.IsMatch(time1)}");
            Console.WriteLine($"Второе время: {time2}:{timeformat.IsMatch(time2)}");
            Console.WriteLine($"Третье время: {time3}:{timeformat.IsMatch(time3)}");
            Console.WriteLine();

            Print("Третье задание:");
            Regex intnumber = new Regex(@"^[+-]?\d+$");
            string intnumber1 = "4.43";
            string intnumber2 = "-58";
            string intnumber3 = "4528";
            Console.WriteLine($"Первое число: {intnumber1}:{intnumber.IsMatch(intnumber1)}");
            Console.WriteLine($"Второе число: {intnumber2}:{intnumber.IsMatch(intnumber2)}");
            Console.WriteLine($"Третье число: {intnumber3}:{intnumber.IsMatch(intnumber3)}");
            Console.WriteLine();

            Print("Четвертое задание:");
            Regex decimalnumber = new Regex(@"^[+-]?\d+(\.\d+)?$");
            string decimalnumber1 = "4.43";
            string decimalnumber2 = "-129.925";
            string decimalnumber3 = "сорок пять целых и 15 десятых";
            Console.WriteLine($"Первое число: {decimalnumber1}:{decimalnumber.IsMatch(decimalnumber1)}");
            Console.WriteLine($"Второе число: {decimalnumber2}:{decimalnumber.IsMatch(decimalnumber2)}");
            Console.WriteLine($"Третье число: {decimalnumber3}:{decimalnumber.IsMatch(decimalnumber3)}");
            Console.WriteLine();

        }
        public static void RegexPart2()
        {
            Print("Вторая часть:");
            Print("Задание. Измените программу так, чтобы на экран дополнительно " +
                "выводилось количество найденных чисел.");
            Regex r = new Regex(@"[-+]?\d+");
            string text = @"5*10=50 -80/40=-2";
            Match teg = r.Match(text);
            int sum = 0;
            int count = 0;// нужно добавить счетчик
            while (teg.Success)
            {
                Console.WriteLine(teg);
                sum += int.Parse(teg.ToString());
                teg = teg.NextMatch();
                count++;// и каждую итерацию его увеличивать на 1
            }
            Console.WriteLine("sum=" + sum);
            Console.WriteLine($"Количество найденных чисел: {count}");
            Console.WriteLine();
        }
        public static void RegexPart3()
        {
            Print("Третья часть:");
            Print("Задание. Измените программу так, чтобы шестизначные номера заменялись " +
                "на семизначные добавлением 0 \nпосле первых двух цифр. Например," +
                "номер 12 - 34 - 56 заменился бы на 120 - 34 - 56.");
            string text = @"Контакты в Москве tel:123-45-67, 123-34-56; fax:123-56-45." +
                  "Контакты в Саратове tel:12-34-56; fax:11-56-45";
            Console.WriteLine("Старые данные\n" + text);
            string newText = Regex.Replace(text, @"\D\d{2}(-\d\d){2}", ":120-34-56");

            Console.WriteLine("Новые данные\n" + newText);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            RegexPart1();
            RegexPart2();
            RegexPart3();
            Console.WriteLine("Для завершения нажмите на любую клавишу...");
            Console.ReadKey();
        }
    }
}
