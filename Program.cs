using System;
using System.Threading;
using MethodLibraryHvM2;
namespace M03UF2PR1
{
    public class HeroisVsMonstre2
    {


        public static void Main()
        {
            const string Play = "Què vols fer? \n1. Iniciar una nova batalla\n0. Sortir", Difficulty = "Selecciona una dificultat \n1. Fàcil\n2. Difícil\n3. Personalitzat\n4. Aleatori", IntroNames = "Introdueix 4 noms separats per comes:\nArquera, Bàrbar, Maga, Druida", INTROHP = "Introdueix la vida de {0} en un valor de {1}-{2}",
                INTROATK = "Introdueix l'atac de {0} en un valor de {1}-{2}", INTRODEF = "Introdueix la defensa de {0} en un valor de {1}-{2}%",
                INTROHPMONSTER = "Introdueix la vida del monstre en un valor de 7000-10000", INTROATKMONSTER = "Introdueix l'atac del monstre en un valor de 300-400",
                INTRODEFMONSTER = "Introdueix la defensa del monstre en un valor de 20-30%";

            const int MINHPARCHER = 1500, MAXHPARCHER = 2000, MINATKARCHER = 200, MAXATKARCHER = 300, MINDEFARCHER = 25, MAXDEFARCHER = 35, MINHPBARBARIAN = 3000,
               MAXHPBARBARIAN = 3750, MINATKBARBARIAN = 150, MAXATKBARBARIAN = 250,
               MINDEFBARBARIAN = 35, MAXDEFBARBARIAN = 45, MINHPSORCERESS = 1100, MAXHPSORCERESS = 1500, MINATKSORCERESS = 300, MAXATKSORCERESS = 400, MINDEFSORCERESS = 20,
               MAXDEFSORCERESS = 35, MINHPDRUID = 2000, MAXHPDRUID = 2500, MINATKDRUID = 70, MAXATKDRUID = 120, MINDEFDRUID = 25,
               MAXDEFDRUID = 40, MINHPMONSTER = 7000, MAXHPMONSTER = 10000, MINATKMONSTER = 300, MAXATKMONSTER = 400, MINDEFMONSTER = 20, MAXDEFMONSTER = 30;
            double hpArcher = 0, atkArcher = 0, defArcher = 0, hpBarbarian = 0, atkBarbarian = 0, defBarbarian = 0, hpSorceress = 0, atkSorceress = 0, defSorceress = 0, hpDruid = 0,
                atkDruid = 0, defDruid = 0, hpMonster = 0, atkMonster = 0, defMonster = 0;
            int play, difficulty, errors = 0;
            string names, nameArcher, nameBarbarian, nameSorceress, nameDruid;
            Random rand = new Random();


            Console.WriteLine(Play);
            play = Convert.ToInt32(Console.ReadLine());
            while ((play != 0 && play != 1) || errors == 3)
            {
                errors++;
                Console.WriteLine(Play);
                play = Convert.ToInt32(Console.ReadLine());
            }
            if (play == 1)
            {
                do
                {
                    Console.WriteLine(IntroNames);
                    names = Console.ReadLine();
                } while (!HeroisVsMonstreLibrary.CheckForCommas(names));
                nameArcher = HeroisVsMonstreLibrary.CheckForCommas(names, 1);
                nameBarbarian = HeroisVsMonstreLibrary.CheckForCommas(names, 2);
                nameSorceress = HeroisVsMonstreLibrary.CheckForCommas(names, 3);
                nameDruid = HeroisVsMonstreLibrary.CheckForCommas(names, 4);
                do
                {
                    Console.WriteLine(Difficulty);
                    difficulty = Convert.ToInt32(Console.ReadLine());
                } while (difficulty != 1 && difficulty != 2 && difficulty != 3 && difficulty != 4);
                if (difficulty == 1)
                {
                    hpArcher = MAXHPARCHER;
                    hpBarbarian = MAXHPBARBARIAN;
                    hpDruid = MAXHPDRUID;
                    hpMonster = MINHPMONSTER;
                    hpSorceress = MAXHPSORCERESS;

                    atkArcher = MAXATKARCHER;
                    atkBarbarian = MAXATKBARBARIAN;
                    atkDruid = MAXATKDRUID;
                    atkMonster = MINATKMONSTER;
                    atkSorceress = MAXATKSORCERESS;

                    defArcher = MAXDEFARCHER;
                    defBarbarian = MAXDEFBARBARIAN;
                    defDruid = MAXDEFDRUID;
                    defMonster = MINDEFMONSTER;
                    defSorceress = MAXDEFSORCERESS;
                }
                else if (difficulty == 2)
                {
                    hpArcher = MINHPARCHER;
                    hpBarbarian = MINHPBARBARIAN;
                    hpDruid = MINHPDRUID;
                    hpMonster = MAXHPMONSTER;
                    hpSorceress = MINHPSORCERESS;

                    atkArcher = MINATKARCHER;
                    atkBarbarian = MINATKBARBARIAN;
                    atkDruid = MINATKDRUID;
                    atkMonster = MAXATKMONSTER;
                    atkSorceress = MINATKSORCERESS;

                    defArcher = MINDEFARCHER;
                    defBarbarian = MINDEFBARBARIAN;
                    defDruid = MINDEFDRUID;
                    defMonster = MAXDEFMONSTER;
                    defSorceress = MINDEFSORCERESS;
                }
                else if (difficulty == 3)
                {
                    while (!HeroisVsMonstreLibrary.Validate(MINHPARCHER, MAXHPARCHER, hpArcher))
                    {
                        if (errors == 3)
                        {
                            hpArcher = MINHPARCHER;
                        }
                        else
                        {
                            Console.WriteLine(INTROHP, nameArcher, MINHPARCHER, MAXHPARCHER);
                            hpArcher = Convert.ToInt32(Console.ReadLine());
                        }
                        errors++;
                    }
                    errors = 0;
                    while (!HeroisVsMonstreLibrary.Validate(MINATKARCHER, MAXATKARCHER, atkArcher))
                    {
                        if (errors == 3)
                        {
                            atkArcher = MINATKARCHER;
                        }
                        else
                        {
                            Console.WriteLine(INTROATK, nameArcher, MINATKARCHER, MAXATKARCHER);
                            atkArcher = Convert.ToInt32(Console.ReadLine());
                        }
                        errors++;
                    }
                    errors = 0;
                    while (!HeroisVsMonstreLibrary.Validate(MINDEFARCHER, MAXDEFARCHER, defArcher))
                    {
                        if (errors == 3)
                        {
                            defArcher = MINDEFARCHER;
                        }
                        else
                        {
                            Console.WriteLine(INTRODEF, nameArcher, MINDEFARCHER, MAXDEFARCHER);
                            defArcher = Convert.ToInt32(Console.ReadLine());
                        }
                        errors++;
                    }
                    errors = 0;

                    while (!HeroisVsMonstreLibrary.Validate(MINHPBARBARIAN, MAXHPBARBARIAN, hpBarbarian))
                    {
                        if (errors == 3)
                        {
                            hpBarbarian = MINHPBARBARIAN;
                        }
                        else
                        {
                            Console.WriteLine(INTROHP, nameBarbarian, MINHPBARBARIAN, MAXHPBARBARIAN);
                            hpBarbarian = Convert.ToInt32(Console.ReadLine());
                        }
                        errors++;
                    }
                    errors = 0;
                    while (!HeroisVsMonstreLibrary.Validate(MINATKBARBARIAN, MAXATKBARBARIAN, atkBarbarian))
                    {
                        if (errors == 3)
                        {
                            atkBarbarian = MINATKBARBARIAN;
                        }
                        else
                        {
                            Console.WriteLine(INTROATK, nameBarbarian, MINATKBARBARIAN, MAXATKBARBARIAN);
                            atkBarbarian = Convert.ToInt32(Console.ReadLine());
                        }
                        errors++;
                    }
                    errors = 0;
                    while (!HeroisVsMonstreLibrary.Validate(MINDEFBARBARIAN, MINDEFBARBARIAN, defBarbarian))
                    {
                        if (errors == 3)
                        {
                            defBarbarian = MINDEFBARBARIAN;
                        }
                        else
                        {
                            Console.WriteLine(INTRODEF, nameBarbarian, MINDEFBARBARIAN, MINDEFBARBARIAN);
                            defBarbarian = Convert.ToInt32(Console.ReadLine());
                        }
                        errors++;
                    }
                    errors = 0;
                    while (!HeroisVsMonstreLibrary.Validate(MINHPSORCERESS, MAXHPSORCERESS, hpSorceress))
                    {
                        if (errors == 3)
                        {
                            hpSorceress = MINHPSORCERESS;
                        }
                        else
                        {
                            Console.WriteLine(INTROHP, nameSorceress, MINHPSORCERESS, MAXHPSORCERESS);
                            hpSorceress = Convert.ToInt32(Console.ReadLine());
                        }
                        errors++;
                    }
                    errors = 0;
                    while (!HeroisVsMonstreLibrary.Validate(MINATKSORCERESS, MAXATKSORCERESS, atkSorceress))
                    {
                        if (errors == 3)
                        {
                            atkSorceress = MINATKSORCERESS;
                        }
                        else
                        {
                            Console.WriteLine(INTROATK, nameSorceress, MINATKSORCERESS, MAXATKSORCERESS);
                            atkSorceress = Convert.ToInt32(Console.ReadLine());
                        }
                        errors++;
                    }
                    errors = 0;
                    while (!HeroisVsMonstreLibrary.Validate(MINDEFSORCERESS, MAXDEFSORCERESS, defSorceress))
                    {
                        if (errors == 3)
                        {
                            defSorceress = MINDEFSORCERESS;
                        }
                        else
                        {
                            Console.WriteLine(INTRODEF, nameSorceress, MINDEFSORCERESS, MAXDEFSORCERESS);
                            defSorceress = Convert.ToInt32(Console.ReadLine());
                        }
                        errors++;
                    }
                    errors = 0;
                    while (!HeroisVsMonstreLibrary.Validate(MINHPDRUID, MAXHPDRUID, hpDruid))
                    {
                        if (errors == 3)
                        {
                            hpDruid = MINHPDRUID;
                        }
                        else
                        {
                            Console.WriteLine(INTROHP, nameDruid, MINHPDRUID, MAXHPDRUID);
                            hpDruid = Convert.ToInt32(Console.ReadLine());
                        }
                        errors++;
                    }
                    errors = 0;
                    while (!HeroisVsMonstreLibrary.Validate(MINATKDRUID, MAXATKDRUID, atkDruid))
                    {
                        if (errors == 3)
                        {
                            atkDruid = MINATKDRUID;
                        }
                        else
                        {
                            Console.WriteLine(INTROATK, nameDruid, MINATKDRUID, MAXATKDRUID);
                            atkDruid = Convert.ToInt32(Console.ReadLine());
                        }
                        errors++;
                    }
                    errors = 0;
                    while (!HeroisVsMonstreLibrary.Validate(MINDEFDRUID, MAXDEFDRUID, defDruid))
                    {
                        if (errors == 3)
                        {
                            defDruid = MINDEFDRUID;
                        }
                        else
                        {
                            Console.WriteLine(INTRODEF, nameDruid, MINDEFDRUID, MAXDEFDRUID);
                            defDruid = Convert.ToInt32(Console.ReadLine());
                        }
                        errors++;
                    }
                    errors = 0;
                    while (!HeroisVsMonstreLibrary.Validate(MINHPMONSTER, MAXHPMONSTER, hpMonster))
                    {
                        if (errors == 3)
                        {
                            hpMonster = MAXHPMONSTER; //Si falla, es més perjudicial que tingui estadística màxim en comptes de mínim
                        }
                        else
                        {
                            Console.WriteLine(INTROHPMONSTER);
                            hpMonster = Convert.ToInt32(Console.ReadLine());
                        }
                        errors++;
                    }
                    errors = 0;
                    while (!HeroisVsMonstreLibrary.Validate(MINATKMONSTER, MAXATKMONSTER, atkMonster))
                    {
                        if (errors == 3)
                        {
                            atkMonster = MAXATKMONSTER;
                        }
                        else
                        {
                            Console.WriteLine(INTROATKMONSTER);
                            atkMonster = Convert.ToInt32(Console.ReadLine());
                        }
                        errors++;
                    }
                    errors = 0;
                    while (!HeroisVsMonstreLibrary.Validate(MINDEFMONSTER, MAXDEFMONSTER, defMonster))
                    {
                        if (errors == 3)
                        {
                            defMonster = MAXDEFMONSTER;
                        }
                        else
                        {
                            Console.WriteLine(INTRODEFMONSTER);
                            defMonster = Convert.ToInt32(Console.ReadLine());
                        }
                        errors++;
                    }
                    errors = 0;
                }
                else if (difficulty == 4)
                {
                    hpArcher = rand.Next(MINHPARCHER, MAXHPARCHER - 1);
                    hpBarbarian = rand.Next(MINHPBARBARIAN, MAXHPBARBARIAN - 1);
                    hpDruid = rand.Next(MINHPDRUID, MAXHPDRUID - 1);
                    hpMonster = rand.Next(MINHPMONSTER, MAXHPMONSTER - 1);
                    hpSorceress = rand.Next(MINHPSORCERESS, MAXHPSORCERESS - 1);

                    atkArcher = rand.Next(MINATKARCHER, MAXATKARCHER - 1);
                    atkBarbarian = rand.Next(MINATKBARBARIAN, MAXATKBARBARIAN - 1);
                    atkDruid = rand.Next(MINATKDRUID, MAXATKDRUID - 1);
                    atkMonster = rand.Next(MINATKMONSTER, MAXATKMONSTER - 1);
                    atkSorceress = rand.Next(MINATKSORCERESS, MAXATKSORCERESS - 1);

                    defArcher = rand.Next(MINDEFARCHER, MAXDEFARCHER - 1);
                    defBarbarian = rand.Next(MINDEFBARBARIAN, MAXDEFBARBARIAN - 1);
                    defDruid = rand.Next(MINDEFDRUID, MAXDEFDRUID - 1);
                    defMonster = rand.Next(MINDEFMONSTER, MAXDEFMONSTER - 1);
                    defSorceress = rand.Next(MINDEFSORCERESS, MAXDEFSORCERESS - 1);
                }
            }
        }
    }
}
