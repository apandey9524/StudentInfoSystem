using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            #region format screen
            Console.BackgroundColor =System.ConsoleColor.DarkGray;
            Console.Clear();
#endregion
            Input input = new Input();
            input.menu();
            Console.ReadKey();
        }
    }
}
