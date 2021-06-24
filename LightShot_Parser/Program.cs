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
    class Program
    {
        private static void Tips(string tip)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("[Подсказка] ");
            Console.ResetColor();
            Console.Write(tip);
            Console.WriteLine();
        } // Метод для вывода подсказки
        private static void WarningExpect(string warning)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[Предупреждение] ");
            Console.ResetColor();
            Console.Write(warning);
            Console.WriteLine();
        } // Метод для вывода предупреждения

        private static void FaultExpect(string fault)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[Ошибка] ");
            Console.ResetColor();
            Console.Write(fault);
            Console.WriteLine();
            Console.WriteLine("Нажмите любую кнопку для продолжения...");
            Console.ReadKey();
        } // Метод для вывода ошибки

        private static void AlgoritmParse(WebClient client, Regex reHref, string localFileName)
        {
            // Счетчик ошибок для дальнейшего анализа
            int faultvalue = 0;

            Console.Write("Введите количество скриншотов, которые необходимо загрузить [не более 99.999]: ");
            int imgAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Введите первую цифру ссылки [она влияет на год создания скриншота 1-9]: ");
            string src_upd = Console.ReadLine();
            Console.WriteLine();

            char[] allowedChars = "abcdefghijklmnopqrstuvwxyz123456789".ToCharArray();

            int ExeptionCount = 0;
            for (int i = 0; i < imgAmount; i++)
            {
                for (int j = 0; j < imgAmount; j++)
                {
                    int ii = j;
                    string src_updTemp = src_upd;
                    for (int o = 0; o < 5; o++)
                    {
                        src_updTemp += allowedChars[ii % 5];
                        
                    }

                    string lightShot_src = "https://prnt.sc/" + src_updTemp;

                    // Парсинг HTML-кода страницы
                    Uri uri = new Uri(lightShot_src);
                    string html = client.DownloadString(uri);

                    try
                    {
                        Console.WriteLine();
                        Console.WriteLine("Количество скаченных скриншотов: " + (i + 1));
                        Console.WriteLine("Ссылка на скриншот: " + lightShot_src);
                        Console.WriteLine("Текущий скриншот для скачивания: " + reHref.Match(html));

                        // Непосредственно парсинг картинки и добавление ее в соответсвующую директорию
                        client.DownloadFile((reHref.Match(html)).ToString(), (localFileName + (i + 1) + ".png"));
                        client.Headers["User-Agent"] = "Mozilla/5.0";
                        Thread.Sleep(100);
                    }
                    catch (System.ArgumentException) // Обработчик исключений, если не удалось получить доступ к картинке
                    {
                        WarningExpect("Не удалось загрузить данный скриншот");

                        client.Headers["User-Agent"] = "Mozilla/5.0";
                        faultvalue++;
                        continue;
                    }

                    catch (System.Net.WebException) // Обработчик исключений, если указан не верный абсолютный путь
                    {
                        ExeptionCount++;
                        Console.Clear();
                        FaultExpect("Папка не найдена, пожалуйста, введите правильный путь следуя примеру");
                        break;
                    }

                }

                if (ExeptionCount == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Количество загруженных скриншотов: " + (imgAmount - faultvalue));
                    Console.WriteLine("Количество ошибок: " + faultvalue);
                    Console.WriteLine("Задача успешно выполнена! Для выхода нажмите любую клавишу...");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            
            

            }
        }

        private static void RandomParse(WebClient client, Regex reHref, string localFileName)
        {
            // Счетчик ошибок для дальнейшего анализа
            int faultvalue = 0;

            Console.Write("Введите количество скриншотов, которые необходимо загрузить [не более 99.999]: ");
            int imgAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            char[] allowedChars = "abcdefghijklmnopqrstuvwxyz123456789".ToCharArray();
            Random random = new Random();

            int ExeptionCount = 0;
            for(int i = 0; i < imgAmount; i++)
            {
                // Генерация рандомной ссылки
                string src_upd = random.Next(1, 9).ToString();
                for(int j = 0; j < 5; j++)
                {
                    src_upd += allowedChars[random.Next(0, 34)];
                }

                string lightShot_src = "https://prnt.sc/" + src_upd;

                // Парсинг HTML-кода страницы
                Uri uri = new Uri(lightShot_src);
                string html = client.DownloadString(uri);

                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Количество скаченных скриншотов: " + (i + 1));
                    Console.WriteLine("Ссылка на скриншот: " + lightShot_src);
                    Console.WriteLine("Текущий скриншот для скачивания: " + reHref.Match(html));

                    // Непосредственно парсинг картинки и добавление ее в соответсвующую директорию
                    client.DownloadFile((reHref.Match(html)).ToString(), (localFileName + (i + 1) + ".png"));
                    client.Headers["User-Agent"] = "Mozilla/5.0";
                    Thread.Sleep(100);
                }
                catch (System.ArgumentException) // Обработчик исключений, если не удалось получить доступ к картинке
                {
                    WarningExpect("Не удалось загрузить данный скриншот");

                    client.Headers["User-Agent"] = "Mozilla/5.0";
                    faultvalue++;
                    continue;
                }

                catch (System.Net.WebException) // Обработчик исключений, если указан не верный абсолютный путь
                {
                    ExeptionCount++;
                    Console.Clear();
                    FaultExpect("Папка не найдена, пожалуйста, введите правильный путь следуя примеру");
                    break;
                }

            }

            if (ExeptionCount == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Количество загруженных скриншотов: " + (imgAmount - faultvalue));
                Console.WriteLine("Количество ошибок: " + faultvalue);
                Console.WriteLine("Задача успешно выполнена! Для выхода нажмите любую клавишу...");
                Console.ReadKey();
                Environment.Exit(0);
            }

        }

        private static void NumberParse(WebClient client, Regex reHref, string localFileName)
        {
            // Счетчик количества ошибок
            int faultvalue = 0;

            Console.Write("Введите количество скриншотов, которые необходимо загрузить [не более 99.999]: ");
            int imgAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Введите первую цифру ссылки [она влияет на год создания скриншота 1-9]: ");
            int src_upd = Convert.ToInt32(Console.ReadLine()) * 100000;
            Console.WriteLine();

            int ExeptionCount = 0;
            for (int i = 0; i < imgAmount; i++)
            {
                // Создание ссылки для парсинга
                string lightShot_src = "https://prnt.sc/" + src_upd++;
                Uri uri = new Uri(lightShot_src);
                // Парсинг HTML-кода сайта
                string html = client.DownloadString(uri);

                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Количество скаченных скриншотов: " + (i + 1));
                    Console.WriteLine("Ссылка на скриншот: " + lightShot_src);
                    Console.WriteLine("Текущий скриншот для скачивания: " + reHref.Match(html));

                    // Непосредственно парсинг изображения и установка в соответсвущую директорию
                    client.DownloadFile((reHref.Match(html)).ToString(), (localFileName + (i + 1) + ".png"));
                    client.Headers["User-Agent"] = "Mozilla/5.0";
                    Thread.Sleep(100);
                }
                catch (System.ArgumentException) // Обработчик исключений, если не удалось получить доступ к картинке
                {
                    WarningExpect("Не удалось загрузить данный скриншот");

                    client.Headers["User-Agent"] = "Mozilla/5.0";
                    faultvalue++;
                    continue;
                }

                catch (System.Net.WebException) // Обработчик исключений, если указан не верный путь 
                {
                    ExeptionCount++;
                    Console.Clear();
                    FaultExpect("Папка не найдена, пожалуйста, введите правильный путь следуя примеру");
                    break;
                }

                
            }
            
            if (ExeptionCount == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Количество загруженных скриншотов: " + (imgAmount - faultvalue));
                Console.WriteLine("Количество ошибок: " + faultvalue);
                Console.WriteLine("Задача успешно выполнена! Для выхода нажмите любую клавишу...");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }


        private static string localFileName = null;
        static void Main(string[] args)
        {
            WebClient client = new WebClient { Encoding = Encoding.UTF8 };
            client.Headers["User-Agent"] = "Mozilla/5.0";

            // Регулярные выражения для парсинга ссылок на картинки
            Regex reHrefHard = new Regex(@"(https://i.imgur.com/\w*.png|https://i.imgur.com/\w*.jpg|https://image.prntscr.com/image/\w*.png)");
            Regex reHref = new Regex(@"(https://i.imgur.com/\w*.png|https://i.imgur.com/\w*.jpg)");

            while (true)
            {
                Console.Clear();

                Tips(@"В конце пути до папки необходимо поставить \ иначе скриншоты будут сохранены на диск!");
                Console.Write(@"Укажите путь для сохранения картинок [Пример: D:\Screenshots\]: ");

                localFileName = Console.ReadLine();
                Console.WriteLine();

                // Регулярное выражение для проверки правильности абсолютного пути
                Regex fileNameRegex = new Regex(@"(\w?:)");

                if (fileNameRegex.IsMatch(localFileName))
                {
                    Console.WriteLine("Выберите способ поиска скриншотов:");
                    Console.Write("1) Полный перебор всех возможных скриншотов");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" [На данный момент не доступно] ");
                    Console.ResetColor();
                    Console.WriteLine();

                    Console.WriteLine("2) Рандомные скриншоты");
                    Console.WriteLine("3) Перебор скриншотов, имеющих только числовой адрес");

                    int number = int.Parse(Console.ReadKey().KeyChar.ToString());
                    Console.WriteLine();

                    Console.WriteLine("Выберите способ загрузки скриншотов:");
                    Console.WriteLine("1) Пропускать труднодоступные скриншоты [Повышает скорость работы программы]");
                    Console.WriteLine("2) Скачивать все скриншоты, даже труднодоступные [Не рекомендуется]");

                    int level = int.Parse(Console.ReadKey().KeyChar.ToString());
                    Console.WriteLine();

                    // Конструкция для выбора способа парсинга
                    switch (number)
                    {
                        // На данный момент не доступно
                        // case 1:
                            // AlgoritmParse(client, level == 1 ? reHref : reHrefHard, localFileName);
                            // break;

                        case 2:
                            RandomParse(client, level == 1 ? reHref : reHrefHard, localFileName);
                            break;

                        case 3:
                            NumberParse(client, level == 1 ? reHref : reHrefHard, localFileName);
                            break;

                        default:
                            FaultExpect("Вы выбрали неправильное значение!");
                            break;
                    }

                    Console.WriteLine("Настройки успешно приняты");
                    Console.WriteLine("Запуск парсера ...");

                }
                else
                {
                    FaultExpect("Путь к файлу указан не верно, пожалуйста, следуйте примеру");
                    continue;
                }
            }

        }
    }
}
