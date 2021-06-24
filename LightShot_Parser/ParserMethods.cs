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
    static partial class ParserMethods
    {
        public static int imgAmount = 0; // Количество загружаемых скриншотов
        public static int faultvalue = 0; // Количество ошибок при работе программы
        public static int ExeptionCount = 0; // Количество фатальных ошибок

        // Все возможные символы в ссылке на скриншот
        public static char[] allowedChars = "abcdefghijklmnopqrstuvwxyz123456789".ToCharArray();

        public static void AlgoritmParse(WebClient client, Regex reHref, string localFileName)
        {
            Console.Write("Введите количество скриншотов, которые необходимо загрузить [не более 99.999]: ");
            imgAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Введите первую цифру ссылки [она влияет на год создания скриншота 1-9]: ");
            string src_upd = Console.ReadLine();
            Console.WriteLine();

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
                        Message.WarningExpect("Не удалось загрузить данный скриншот");

                        client.Headers["User-Agent"] = "Mozilla/5.0";
                        faultvalue++;
                        continue;
                    }

                    catch (System.Net.WebException) // Обработчик исключений, если указан не верный абсолютный путь
                    {
                        ExeptionCount++;
                        Console.Clear();
                        Message.FaultExpect("Папка не найдена, пожалуйста, введите правильный путь следуя примеру");
                        break;
                    }

                }

                if (ExeptionCount == 0) Message.FinishingMessage();

            }
        }

        public static void RandomParse(WebClient client, Regex reHref, string localFileName)
        {
            Console.Write("Введите количество скриншотов, которые необходимо загрузить [не более 99.999]: ");
            imgAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Random random = new Random();

            for (int i = 0; i < imgAmount; i++)
            {
                // Генерация рандомной ссылки
                string src_upd = random.Next(1, 9).ToString();
                for (int j = 0; j < 5; j++)
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
                    Message.WarningExpect("Не удалось загрузить данный скриншот");

                    client.Headers["User-Agent"] = "Mozilla/5.0";
                    faultvalue++;
                    continue;
                }

                catch (System.Net.WebException) // Обработчик исключений, если указан не верный абсолютный путь
                {
                    ExeptionCount++;
                    Console.Clear();
                    Message.FaultExpect("Папка не найдена, пожалуйста, введите правильный путь следуя примеру");
                    break;
                }

            }

            if (ExeptionCount == 0) Message.FinishingMessage();

        }

        public static void NumberParse(WebClient client, Regex reHref, string localFileName)
        {
            Console.Write("Введите количество скриншотов, которые необходимо загрузить [не более 99.999]: ");
            imgAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Введите первую цифру ссылки [она влияет на год создания скриншота 1-9]: ");
            int src_upd = Convert.ToInt32(Console.ReadLine()) * 100000;
            Console.WriteLine();

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
                    Message.WarningExpect("Не удалось загрузить данный скриншот");

                    client.Headers["User-Agent"] = "Mozilla/5.0";
                    faultvalue++;
                    continue;
                }

                catch (System.Net.WebException) // Обработчик исключений, если указан не верный путь 
                {
                    ExeptionCount++;
                    Console.Clear();
                    Message.FaultExpect("Папка не найдена, пожалуйста, введите правильный путь следуя примеру");
                    break;
                }


            }

            if (ExeptionCount == 0) Message.FinishingMessage();

        }
    }
}
