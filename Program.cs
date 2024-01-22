using System;
using System.Threading;
using MethodLibraryHvM2;
namespace M03UF2PR1
{
    public class HeroisVsMonstre2
    {


        public static void Main()
        {
            const string Play = "Què vols fer? \n1. Iniciar una nova batalla\n0. Sortir";

            int play, errors = 0;


            Console.WriteLine(Play);
            play = Convert.ToInt32(Console.ReadLine());
            while ((play != 0 && play != 1) || errors == 3)
            {
                errors++;
                Console.WriteLine(Play);
                play = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
