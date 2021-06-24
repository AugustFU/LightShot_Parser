using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

namespace LightShot_Parser
{
    static partial class Program
    {
        public static string localFileName = null; // Локальный путь для сохранения скриншотов

        public static Regex fileNameRegex = new Regex(@"(\w?:)"); // Регулярное выражение для проверки абсолютного пути

        // Регулярные выражения для парсинга ссылок
        public static Regex reHrefHard = new Regex(@"(https://i.imgur.com/\w*.png|https://i.imgur.com/\w*.jpg|https://image.prntscr.com/image/\w*.png)");
        public static Regex reHref = new Regex(@"(https://i.imgur.com/\w*.png|https://i.imgur.com/\w*.jpg)");



        static void Main(string[] args)
        {
            WebClient client = new WebClient { Encoding = Encoding.UTF8 };
            client.Headers["User-Agent"] = "Mozilla/5.0";

            while (true)
            {
                Console.Clear();

                Message.Tips(@"В конце пути до папки необходимо поставить \ иначе скриншоты будут сохранены на диск!");
                Console.Write(@"Укажите путь для сохранения картинок [Пример: D:\Screenshots\]: ");

                localFileName = Console.ReadLine();
                Console.WriteLine();

                if (fileNameRegex.IsMatch(localFileName))
                {
                    Console.WriteLine("Выберите способ поиска скриншотов:");
                    Console.WriteLine("1) Полный перебор всех возможных скриншотов");
                    Console.WriteLine("2) Рандомные скриншоты");
                    Console.WriteLine("3) Перебор скриншотов, имеющих только числовой адрес");

                    int number = int.Parse(Console.ReadKey().KeyChar.ToString());
                    Console.Clear();

                    Console.WriteLine("Выберите способ загрузки скриншотов:");
                    Console.WriteLine("1) Пропускать труднодоступные скриншоты [Повышает скорость работы программы]");
                    Console.WriteLine("2) Скачивать все скриншоты, даже труднодоступные [Не рекомендуется]");

                    int level = int.Parse(Console.ReadKey().KeyChar.ToString());
                    Console.Clear();

                    // Конструкция для выбора способа парсинга
                    switch (number)
                    {
                        case 1:
                            ParserMethods.AlgoritmParse(client, level == 1 ? reHref : reHrefHard, localFileName);
                            break;

                        case 2:
                            ParserMethods.RandomParse(client, level == 1 ? reHref : reHrefHard, localFileName);
                            break;

                        case 3:
                            ParserMethods.NumberParse(client, level == 1 ? reHref : reHrefHard, localFileName);
                            break;

                        default:
                            Message.FaultExpect("Вы выбрали неправильное значение!");
                            break;
                    }

                    Console.WriteLine("Настройки успешно приняты");
                    Console.WriteLine("Запуск парсера ...");

                }
                else
                {
                    Message.FaultExpect("Путь к файлу указан не верно, пожалуйста, следуйте примеру");
                    continue;
                }
            }

        }
    }
}
