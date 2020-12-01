using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Практикум
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("1. Удалите из сообщения только те русские слова, которые начинаются на гласную букву.");
            var str = "текст, в котором нужно удалить слова, которые начинаются на гласную букву.";
            var result = Regex.Replace(str, @"\b[аиоуеюяы][а-я]+", "");
            Console.WriteLine(result);
            Console.WriteLine();

            Console.WriteLine("2.В сообщении может содержаться дата в формате дд.мм.гггг. " +
                "В заданном формате дд - целое число из диапазона " +
                "\nот 1 до 31, мм - целое число из диапазона от 1 до 12, а гггг - целое число из диапазона " +
                "\nот 1900 до 2010(если какая - то часть формата нарушена, то данная подстрока в качестве " +
                "\nдаты не рассматривается).Замените каждую дату сообщения на дату следующего дня.");
            Console.WriteLine();

            Console.WriteLine("введите дату в формате дата.месяц.год(например 25.11.2020)");
            string text = (Console.ReadLine());

            string pattern = "[0-3][0-9].[0-1][0-9].[1,2][9,0][0-9][0-9]";

            MatchCollection matches;
            Regex reg = new Regex(pattern);
            matches = reg.Matches(text);

            {
                for (int i = 0; i < matches.Count; i++)
                {
                    string updDate = DateTime.Parse(matches[i].Value).AddDays(-1).ToShortDateString();
                    text = text.Replace(matches[i].Value, updDate);
                }
                Console.WriteLine("дата предыдущенго дня {0}", text);
            }
            Console.WriteLine("\n3.В сообщении могут" +
                " содержаться IP - адреса компьютеров в формате d.d.d.d, где d - целое число из диапазона от 0 до 255. " +
                "\nУдалить из сообщения IP - адреса, в которых последнее число d " +
                "начинается с заданной цифры\n(данная цифра вводится с клавиатуры");
            Regex r = new Regex(@"((1\d\d|2([0-4]\d|5[0-5])|\D\d\d?)\.?){4}$");
            string text1 = "ip = 128.0.0.1";
            string text2 = "ip = 256.0.0.1";
            string text3 = "ip = 0.0.0.0";
            string text4 = "ip = 255.255.255.255";
            string text5 = "ip = 255:228:0:0";

            Console.WriteLine(r.IsMatch(text1) ? text1 + " - Правильный IP" : text1 + " - Неправильный IP");
            Console.WriteLine(r.IsMatch(text2) ? text2 + " - Правильный IP" : text2 + " - Неправильный IP");
            Console.WriteLine(r.IsMatch(text3) ? text3 + " - Правильный IP" : text3 + " - Неправильный IP");
            Console.WriteLine(r.IsMatch(text4) ? text4 + " - Правильный IP" : text4 + " - Неправильный IP");
            Console.WriteLine(r.IsMatch(text5) ? text5 + " - Правильный IP" : text5 + " - Неправильный IP");
            Console.WriteLine("Для завершения нажмите на любую клавишу...");
            Console.ReadKey();
        }
    }
}
