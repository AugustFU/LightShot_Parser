using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightShot_Parser
{
    class Message
    {
        public static void Tips(string tip)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("[Подсказка] ");
            Console.ResetColor();
            Console.Write(tip);
            Console.WriteLine();
        } // Вывод подсказок

        public static void WarningExpect(string warning)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[Предупреждение] ");
            Console.ResetColor();
            Console.Write(warning);
            Console.WriteLine();
        } // Вывод предупреждений при работе программы

        public static void FaultExpect(string fault)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[Ошибка] ");
            Console.ResetColor();
            Console.Write(fault);
            Console.WriteLine();
            Console.WriteLine("Нажмите любую кнопку для продолжения...");
            Console.ReadKey();
        } // Вывода фатальных ошибок

        public static void FinishingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Количество загруженных скриншотов: " + (ParserMethods.imgAmount - ParserMethods.faultvalue));
            Console.WriteLine("Количество ошибок: " + ParserMethods.faultvalue);
            Console.WriteLine("Задача успешно выполнена! Для выхода нажмите любую клавишу...");
            Console.ReadKey();
            Environment.Exit(0);
        } // Финальный вывод статистики

    }
}
