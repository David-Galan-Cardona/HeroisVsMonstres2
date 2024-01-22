using System;
using System.Threading;
using MethodLibraryHvM2;
namespace M03UF2PR1
{
    public class HeroisVsMonstre2
    {


        public static void Main()
        {
            const string Play = "Què vols fer? \n1. Iniciar una nova batalla\n0. Sortir", Despedida = "Fins aviat", Difficulty = "Selecciona una dificultat \n1. Fàcil\n2. Difícil\n3. Personalitzat\n4. Aleatori",
               MONSTER = "el monstre", IntroNames = "Introdueix 4 noms separats per comes:\nArquera, Bàrbar, Maga, Druida", INTROHP = "Introdueix la vida de {0} en un valor de {1}-{2}",
               INTROATK = "Introdueix l'atac de {0} en un valor de {1}-{2}", INTRODEF = "Introdueix la defensa de {0} en un valor de {1}-{2}%",
               INTROHPMONSTER = "Introdueix la vida del monstre en un valor de 7000-10000", INTROATKMONSTER = "Introdueix l'atac del monstre en un valor de 300-400",
               INTRODEFMONSTER = "Introdueix la defensa del monstre en un valor de 20-30%", INPUTBATTLE = "Què vol {0} fer? \n1. Atacar\n2. Defensar-se\n3. Habilitat especial",
               LOOSETURN = "{0} ha perdut el torn", SPECIALABILITY = "{0} utilitza la seva habilitat especial", CD = "La habilitat de {0} es podrà utilitzar en {1} torns",
               DEADPARTYMEMBER = "{0} jau al terra", BARBINMUNE = "El bàrbar no rep cap mal", MONSTERSTUNNED = "El monstre està atordit per la fletxa",  ATKMONSTER = "El monstre exhala una flamarada";

            const int HEALDRUID = 500, MINHPARCHER = 1500, MAXHPARCHER = 2000, MINATKARCHER = 200, MAXATKARCHER = 300, MINDEFARCHER = 25, MAXDEFARCHER = 35, MINHPBARBARIAN = 3000,
               MAXHPBARBARIAN = 3750, MINATKBARBARIAN = 150, MAXATKBARBARIAN = 250,
               MINDEFBARBARIAN = 35, MAXDEFBARBARIAN = 45, MINHPSORCERESS = 1100, MAXHPSORCERESS = 1500, MINATKSORCERESS = 300, MAXATKSORCERESS = 400, MINDEFSORCERESS = 20,
               MAXDEFSORCERESS = 35, MINHPDRUID = 2000, MAXHPDRUID = 2500, MINATKDRUID = 70, MAXATKDRUID = 120, MINDEFDRUID = 25,
               MAXDEFDRUID = 40, MINHPMONSTER = 7000, MAXHPMONSTER = 10000, MINATKMONSTER = 300, MAXATKMONSTER = 400, MINDEFMONSTER = 20, MAXDEFMONSTER = 30;
            double hpArcher = 0, storedArcher = 0, atkArcher = 0, defArcher = 0, hpBarbarian = 0, storedBarbarian = 0, atkBarbarian = 0, defBarbarian = 0,
            hpSorceress = 0, storedSorceress = 0, atkSorceress = 0, defSorceress = 0, hpDruid = 0, storedDruid = 0, atkDruid = 0, defDruid = 0,
            hpMonster = 0, atkMonster = 0, defMonster = 0, battleResult;
            int play, difficulty, cdArcher = 0, cdBarbarian = 0, cdSorceress = 0, cdDruid = 0, errors = 0, fightChoice = 0;
            string names, nameArcher, nameBarbarian, nameSorceress, nameDruid;
            bool archerDef = false, barbarianDef = false, sorceressDef = false, druidDef = false;
            Random rand = new Random();
            int[] orderTurns = new int[4];
            double[] hpHeroes = new double[4] { 0, 0, 0, 0 };


            Console.WriteLine(Play);
            play = Convert.ToInt32(Console.ReadLine());
            while ((play != 0 && play != 1) || errors == 3)
            {
                errors++;
                Console.WriteLine(Play);
                play = Convert.ToInt32(Console.ReadLine());
            }
            if (play == 1 && errors < 3)
            {
                errors = 0;
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
                storedArcher = hpArcher;
                storedBarbarian = hpBarbarian;
                storedDruid = hpDruid;
                storedSorceress = hpSorceress;
                while (hpMonster > 0 && (hpSorceress > 0 || hpDruid > 0 || hpBarbarian > 0 || hpArcher > 0))
                {
                    orderTurns = HeroisVsMonstreLibrary.EmptyOrder(orderTurns);
                    orderTurns = HeroisVsMonstreLibrary.OrderTurns(orderTurns);
                    for (int i = 0; i < orderTurns.Length; i++)
                    {
                        Console.WriteLine();
                        if (orderTurns[i] == 1)
                        {
                            if (hpMonster != 0)
                            {
                                if (hpArcher <= 0)
                                {
                                    Console.WriteLine(DEADPARTYMEMBER, nameArcher);
                                }
                                else
                                {
                                    if (cdArcher != 0)
                                    {
                                        cdArcher--;
                                    }
                                    archerDef = false;
                                    do
                                    {
                                        Console.WriteLine(INPUTBATTLE, nameArcher);
                                        fightChoice = Convert.ToInt32(Console.ReadLine());
                                        while (fightChoice < 0 || fightChoice > 3 && errors < 2)
                                        {

                                            Console.WriteLine(INPUTBATTLE, nameArcher);
                                            fightChoice = Convert.ToInt32(Console.ReadLine());
                                            if (fightChoice < 0 || fightChoice > 3 && errors < 2)
                                            {
                                                errors++;
                                            }

                                        }
                                        if (errors == 2)
                                        {
                                            Console.WriteLine(LOOSETURN, nameArcher);
                                        }
                                        else if (fightChoice == 3)
                                        {
                                            if (cdArcher != 0)
                                            {
                                                Console.WriteLine(CD, nameArcher, cdArcher);
                                            }
                                            else
                                            {
                                                Console.WriteLine(SPECIALABILITY, nameArcher);
                                                cdArcher = 5;
                                            }
                                        }
                                        else
                                        {
                                            battleResult = HeroisVsMonstreLibrary.FightMenu(fightChoice, atkArcher, nameArcher, hpMonster, defMonster, MONSTER);
                                            if (battleResult == -1)
                                            {
                                                archerDef = true;
                                            }
                                            else
                                            {
                                                hpMonster = battleResult;
                                            }

                                        }
                                    } while (fightChoice == 3 && cdArcher < 5 && cdArcher != 0);
                                    errors = 0;
                                }

                            }
                        }
                        if (orderTurns[i] == 2)
                        {
                            if (hpMonster != 0)
                            {
                                if (hpBarbarian <= 0)
                                {
                                    Console.WriteLine(DEADPARTYMEMBER, nameBarbarian);
                                }
                                else
                                {
                                    if (cdBarbarian != 0)
                                    {
                                        cdBarbarian--;
                                    }
                                    barbarianDef = false;
                                    do
                                    {
                                        Console.WriteLine(INPUTBATTLE, nameBarbarian);
                                        fightChoice = Convert.ToInt32(Console.ReadLine());
                                        while (fightChoice < 0 || fightChoice > 3 && errors < 2)
                                        {

                                            Console.WriteLine(INPUTBATTLE, nameBarbarian);
                                            fightChoice = Convert.ToInt32(Console.ReadLine());
                                            if (fightChoice < 0 || fightChoice > 3 && errors < 2)
                                            {
                                                errors++;
                                            }

                                        }
                                        if (errors == 2)
                                        {
                                            Console.WriteLine(LOOSETURN, nameBarbarian);
                                        }
                                        else if (fightChoice == 3)
                                        {
                                            if (cdBarbarian != 0)
                                            {
                                                Console.WriteLine(CD, nameBarbarian, cdBarbarian);
                                            }
                                            else
                                            {
                                                Console.WriteLine(SPECIALABILITY, nameBarbarian);
                                                cdBarbarian = 5;
                                            }
                                        }
                                        else
                                        {
                                            battleResult = HeroisVsMonstreLibrary.FightMenu(fightChoice, atkBarbarian, nameBarbarian, hpMonster, defMonster, MONSTER);
                                            if (battleResult == -1)
                                            {
                                                barbarianDef = true;
                                            }
                                            else
                                            {
                                                hpMonster = battleResult;
                                            }

                                        }
                                    } while (fightChoice == 3 && cdBarbarian < 5 && cdBarbarian != 0);
                                    errors = 0;
                                }
                            }
                        }
                        if (orderTurns[i] == 3)
                        {
                            if (hpMonster != 0)
                            {
                                if (hpSorceress <= 0)
                                {
                                    Console.WriteLine(DEADPARTYMEMBER, nameSorceress);
                                }
                                else
                                {
                                    if (cdSorceress != 0)
                                    {
                                        cdSorceress--;
                                    }
                                    sorceressDef = false;
                                    do
                                    {
                                        Console.WriteLine(INPUTBATTLE, nameSorceress);
                                        fightChoice = Convert.ToInt32(Console.ReadLine());
                                        while (fightChoice < 0 || fightChoice > 3 && errors < 2)
                                        {

                                            Console.WriteLine(INPUTBATTLE, nameSorceress);
                                            fightChoice = Convert.ToInt32(Console.ReadLine());
                                            if (fightChoice < 0 || fightChoice > 3 && errors < 2)
                                            {
                                                errors++;
                                            }

                                        }
                                        if (errors == 2)
                                        {
                                            Console.WriteLine(LOOSETURN, nameSorceress);
                                        }
                                        else if (fightChoice == 3)
                                        {
                                            if (cdSorceress != 0)
                                            {
                                                Console.WriteLine(CD, nameSorceress, cdSorceress);
                                            }
                                            else
                                            {
                                                Console.WriteLine(SPECIALABILITY, nameSorceress);
                                                HeroisVsMonstreLibrary.FightMenu(atkSorceress, nameSorceress, hpMonster, defMonster, MONSTER, orderTurns[i]);
                                                cdSorceress = 5;
                                            }
                                        }
                                        else
                                        {
                                            battleResult = HeroisVsMonstreLibrary.FightMenu(fightChoice, atkSorceress, nameSorceress, hpMonster, defMonster, MONSTER);
                                            if (battleResult == -1)
                                            {
                                                sorceressDef = true;
                                            }
                                            else
                                            {
                                                hpMonster = battleResult;
                                            }

                                        }
                                    } while (fightChoice == 3 && cdSorceress < 5 && cdSorceress != 0);
                                    errors = 0;
                                }

                            }
                        }
                        if (orderTurns[i] == 4)
                        {
                            if (hpMonster != 0)
                            {
                                if (hpDruid <= 0)
                                {
                                    Console.WriteLine(DEADPARTYMEMBER, nameDruid);
                                }
                                else
                                {
                                    if (cdDruid != 0)
                                    {
                                        cdDruid--;
                                    }
                                    druidDef = false;
                                    do
                                    {
                                        Console.WriteLine(INPUTBATTLE, nameDruid);
                                        fightChoice = Convert.ToInt32(Console.ReadLine());
                                        while (fightChoice < 0 || fightChoice > 3 && errors < 2)
                                        {
                                            Console.WriteLine(INPUTBATTLE, nameDruid);
                                            fightChoice = Convert.ToInt32(Console.ReadLine());
                                            if (fightChoice < 0 || fightChoice > 3 && errors < 2)
                                            {
                                                errors++;
                                            }

                                        }
                                        if (errors == 2)
                                        {
                                            Console.WriteLine(LOOSETURN, nameDruid);
                                        }
                                        else if (fightChoice == 3)
                                        {
                                            if (cdDruid != 0)
                                            {
                                                Console.WriteLine(CD, nameDruid, cdDruid);
                                            }
                                            else
                                            {
                                                Console.WriteLine(SPECIALABILITY, nameDruid);
                                                HeroisVsMonstreLibrary.Heal(hpArcher, storedArcher, nameArcher, HEALDRUID);
                                                HeroisVsMonstreLibrary.Heal(hpBarbarian, storedBarbarian, nameBarbarian, HEALDRUID);
                                                HeroisVsMonstreLibrary.Heal(hpSorceress, storedSorceress, nameSorceress, HEALDRUID);
                                                HeroisVsMonstreLibrary.Heal(hpDruid, storedDruid, nameDruid, HEALDRUID);
                                                cdDruid = 5;
                                            }
                                        }
                                        else
                                        {
                                            battleResult = HeroisVsMonstreLibrary.FightMenu(fightChoice, atkDruid, nameDruid, hpMonster, defMonster, MONSTER);
                                            if (battleResult == -1)
                                            {
                                                druidDef = true;
                                            }
                                            else
                                            {
                                                hpMonster = battleResult;
                                            }

                                        }
                                    } while (fightChoice == 3 && cdDruid < 5 && cdDruid != 0);
                                    errors = 0;
                                }

                            }
                        }
                    }
                    if (cdArcher < 4)
                    {
                        Console.WriteLine(ATKMONSTER);
                        hpArcher = HeroisVsMonstreLibrary.AttackMonster(atkMonster, hpArcher, defArcher, nameArcher, MONSTER, archerDef);
                        if (cdBarbarian < 4)
                        {
                            hpBarbarian = HeroisVsMonstreLibrary.AttackMonster(atkMonster, hpBarbarian, defBarbarian, nameBarbarian, MONSTER, barbarianDef);
                        }
                        else
                        {
                            Console.WriteLine(BARBINMUNE);
                        }
                        hpSorceress = HeroisVsMonstreLibrary.AttackMonster(atkMonster, hpSorceress, defSorceress, nameSorceress, MONSTER, sorceressDef);
                        hpDruid = HeroisVsMonstreLibrary.AttackMonster(atkMonster, hpDruid, defDruid, nameDruid, MONSTER, druidDef);
                    }
                    else
                    {
                        Console.WriteLine(MONSTERSTUNNED);
                    }
                    
                }
            }
            else
            {
                Console.WriteLine(Despedida);
            }
        }
    }
}
