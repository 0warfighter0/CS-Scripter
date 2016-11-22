using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OriginalWar;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Translating File...");

            Translator translator = new Translator();
            if(translator.Translate())
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Failed");
                Console.Read();
            }
            //Console.Read();
        }
    }
}
