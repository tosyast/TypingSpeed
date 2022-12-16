using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace TypingSpeed
{
    internal class Program
    {
        static string text = "Кэ Цин, отдавая почти все свои силы Ли Юэ, в свободную минутку предаётся неожиданному досугу - покупкам. " +
                "В выходной день она надевает простую одежду, встречается с парочкой близких друзей и прогуливается по торговой площади" +
                " Фэйюнь и горе Тигра, заглядывая в разные магазины. После ухода Властелина Камня Кэ Цин, несмотря на свой ещё более " +
                "плотный график, продолжает снимать стресс этим способом, но за одним небольшим изменением. Однажды она шла по улице," +
                " и глаз её зацепился за неприметную лавчонку, где продавались глиняные фигурки Гео Архонта. Уговорив друзей отправиться " +
                "в магазин шёлка напротив, Кэ Цин подошла к лавочке и принялась рассматривать одну из фигурок. Зная, что время поджимает," +
                " она осторожно осмотрелась, а когда убедилась, что никто не видит, одним быстрым движением заплатила за фигурку и завернула" +
                " её. Но стоило ей положить фигурку в сумку и с облегчением вздохнуть, как один из друзей со свёртками шёлка в руках похлопал её по плечу." +
                " Скоро все узнали о её поступке и были очень удивлены. Зачем такой противнице Гео Архонта было покупать его статуэтку?";


        static Table table = new Table();
        static int i = 0;
        static Record name = new Record();
        static bool isOn = true;
        static ConsoleKeyInfo key = Console.ReadKey();
        static void Main()
        {
            do
            {
                Console.WriteLine("Введите ваше имя: ");
                name.Name = Console.ReadLine();
                WriteText();
                Console.SetCursorPosition(0, 0);
                key = Console.ReadKey();


            } while (key.Key != ConsoleKey.F1);



        }
        static void EndTime()
        {

            ConsoleKey key = Console.ReadKey().Key;
            while (key != ConsoleKey.Escape)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.WriteLine("Имя: " + name.Name);
                        Console.WriteLine("Скорость в минуту: " + name.SymbolPerMinute);
                        Console.WriteLine("Скорость в секунду: " + name.SymbolPerSecond);

                        Console.WriteLine("-----------------");

                        table.WriteReccord();

                        table.AddItem(name.Name, name.SymbolPerMinute, name.SymbolPerSecond);
                        Console.ForegroundColor = ConsoleColor.White;
          
                        
                        Console.WriteLine("Чтобы вернуться обратно в меню, вернитесь через Escape");
                        Console.WriteLine("Чтобы закончить программу, нажмите F1");
                        break;
                    case ConsoleKey.Escape:
                        Main();
                        break;
                    case ConsoleKey.F1:
                        Environment.Exit(0);
                        break;
                }
            }


        }
        static void Speed()
        {
            name.SymbolPerMinute = i;
            name.SymbolPerSecond = i / 60;
        }
        private static void Time()
        {
            Thread t = new Thread(_ =>
            {
                var dateTime = DateTime.Now;
                DateTime dt = dateTime.AddMinutes(-1);

                while (dateTime >= dt && isOn)
                {
                    Console.SetCursorPosition(0, 10);
                    if (i == text.Length)
                    {
                        isOn = false;
                    }
                    Console.SetCursorPosition(0, 10);
                    var ticks = (dateTime - dt).Ticks;
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine(new DateTime(ticks).ToString("mm:HH:ss"));
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(0, 10);
                    dt = dt.AddSeconds(1);
                    Console.SetCursorPosition(0, 10);
                }
                Console.Clear();

                Console.WriteLine("Стоп!");
                Speed();
                EndTime();

            });

            t.Start();

        }



        static void WriteYellowText(int dlina)
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < dlina; i++)
            {
                Console.Write(text[i]);
            }
            Console.SetCursorPosition(0, 0);
        }
        static void WriteText()
        {

            Console.Clear();

            Console.WriteLine("Нажмите Enter чтобы начать");
            ConsoleKeyInfo key = Console.ReadKey();
            Time();


            while (isOn == true)
            {
                if (key.Key == ConsoleKey.Enter)
                {

                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine(text);
                    Console.SetCursorPosition(0, 0);

                    while (i < text.Length)
                    {

                        char c = Console.ReadKey(true).KeyChar;
                        if (c == text[i])
                        {
                            i++;
                            WriteYellowText(i);

                        }
                    }


                }
                key = Console.ReadKey();
            }

        }

    }
}