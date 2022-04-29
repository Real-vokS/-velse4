using System;
using System.Threading;

namespace Øvelse4
{
    class Program
    {
        static char key = '*';

        static Thread t1 = new Thread(Print);
        static Thread t2 = new Thread(ReadInput);

        static void Main(string[] args)
        {
            t1.Start();
            t2.Start();
        }


        static void Print()
        {

            while (t2.IsAlive)
            {
                Console.Write(key);
                Thread.CurrentThread.Join(10);
            }

        }


        //hvis man indtaster et char og trykker enter midt i en linje, replacer den hele linjen med det indtastet char. istedet for at forsætte
        //fra der hvor enter blev inputet
        static void ReadInput()
        {
            bool escHit = false;
            ConsoleKeyInfo input;
            char savedKey = '*';

            while (escHit == false)
            {
                input = Console.ReadKey();

                if (input.Key != ConsoleKey.Enter && input.Key != ConsoleKey.Escape)
                {
                    savedKey = input.KeyChar;
                }
                else
                {
                    key = savedKey;
                }

                if(input.Key == ConsoleKey.Escape)
                {
                    escHit = false;
                }
                
            }

        }
    }
}
