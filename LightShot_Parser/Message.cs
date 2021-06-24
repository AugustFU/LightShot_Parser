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

        public static void StartLogo()
        {
            Console.WriteLine(@" :%..%; ;% :%:.tt t% :%: %; tt.:%::X; ;%");
            Console.WriteLine(@";;:;;::;;.;;:;;::;::;;:;;::t::;;:;%8:;::     __    _       __    __  _____ __           __                        ");
            Console.WriteLine(@".:t::t;.;t.:t:.t;.;t.:t:.t;.;t.;8StX::;t    / /   (_)___ _/ /_  / /_/ ___// /_   ____  / /_                       ");
            Console.WriteLine(@"%; tt..%: %;.;%.:%: t;.;%.:%: XSX@8@.%:    / /   / / __ `/ __ \/ __/\__ \/ __ \ / __ \/ __/                       ");
            Console.WriteLine(@"::t::;;:;;.:;::;;:;;::t::;;:X8%8@88@:::t  / /___/ / /_/ / / / / /_ ___/ / / / // /_/ / /_                         ");
            Console.WriteLine(@"t;.;t.:t:.t;.;t.:t:.t;.;;S@S%8888@..:%:. /_____/_/\__, /_/ /_/\__//____/_/ /_/ \____/\__/                         ");
            Console.WriteLine(@" .%..t; ;t :%:.t; ;% .tS8@X88888 X8;; ;t         /____/                                                           ");
            Console.WriteLine(@";;:;;::t::;;:;;::t::%@88X8@888S% 88::t::                                                                          ");
            Console.WriteLine(@".:t::t;.;t.:t:.t;;@888X8XX8@S 8888:t;.;t     ____                                                                 ");
            Console.WriteLine(@"%; ;t.:%. %; tt:@88@X8 88@X  88888%.:%:     / __ \____  _____________  _____                                      ");
            Console.WriteLine(@"::t::;;:;;::t:S88@X8 888XS 888888%:;;.;;   / /_/ / __ `/ ___/ ___/ _ \/ ___/                                      ");
            Console.WriteLine(@"t;.;t.:t:.ttSS8@XXS88SXS 88 8888%;t.:t:.  / ____/ /_/ / /  (__  )  __/ /                                          ");
            Console.WriteLine(@" :%: %; ;tt888@S888%SS 88888888%%:.t; ;% /_/    \__,_/_/  /____/\___/_/                                           ");
            Console.WriteLine(@";;:;;::t;X888@8X8t@X S88888888t;:;;::;::                                                                          ");
            Console.WriteLine(@".:t:.t;:88@S8X88@@  88888888%t::t:.t;.;t                                                                          ");
            Console.WriteLine(@"%; t%..8@X@t;@8@S 88888888%%: %; ;%.:%:.     __                                                                   ");
            Console.WriteLine(@"::t::;SXS8 88@S  88 88888t;:;;::t::;;::;    / /_  __  __          ___                          __     ________  __");
            Console.WriteLine(@"t;.;t.X8X88SS .8888888S%t.:t:.t;.;t.:%:.   / __ \/ / / /         /   | __  ______ ___  _______/ /_   / ____/ / / /");
            Console.WriteLine(@" :%: SXX88%X:8888@SS88%:.t; t%.:%:.%t.t%  / /_/ / /_/ /         / /| |/ / / / __ `/ / / / ___/ __/  / /_  / / / / ");
            Console.WriteLine(@"t;:;:8888S.8@XX%tttt$;;:;:;:;;:;;.:::;;: /_.___/\__, /         / ___ / /_/ / /_/ / /_/ (__  ) /_   / __/ / /_/ /  ");
            Console.WriteLine(@".:t:.%.8 88@XX%8@X%;::;;::;;::::@t:%;.;t       /____/         /_/  |_\__,_/\__, /\__,_/____/\__/  /_/    \____/   ");
            Console.WriteLine(@"%;.t;S88888t:.;:t:;;;::;;;::;;;::;;;:;.                                   /____/                                  ");
            Console.WriteLine(@"::;S@8S%%;;t;;::;;t::;;;::;;;;::t::;;:;;                                                                          ");
            Console.WriteLine(@"t%888;::;:::;;;:::;;;;:%t::t:.t;.;t.:t:.                                                                          ");
            Console.WriteLine();
        }

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
