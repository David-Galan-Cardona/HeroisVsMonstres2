namespace MethodLibraryHvM2
{
    public class HeroisVsMonstreLibrary
    {
        public static bool Validate(int min, int max, double value)
        {
            if (value < min || value > max)
            {
                return false;
            }
            else return true;
        }
        public static bool CheckForCommas(string names)
        {
            int commas = 0;
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == ',')
                {
                    commas++;
                }
            }
            if (commas == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string CheckForCommas(string names, int num) //Això separa els noms dels herois segons les comes
        {
            int commas = 0;
            string name = "";
            for (int i = 0; i < names.Length; i++)
            {
                if (num == commas + 1 && names[i] != ' ' && names[i] != ',')
                {
                    name += names[i];
                }
                if (names[i] == ',')
                {
                    commas++;
                    if (commas == num)
                    {
                        return name;
                    }
                }
            }
            return name;
        }
        public static int[] EmptyOrder(int[] orderTurns)
        {
            for (int i = 0; i < 4; i++)
            {
                orderTurns[i] = 0;
            }
            return orderTurns;
        }
        public static int[] OrderTurns(int[] orderTurns)
        {
            Random random = new Random();
            int order;
            bool found;
            for (int i = 0; i < 4; i++)
            {
                order = random.Next(1, 5);
                found = false;
                for (int j = 0; j < 4; j++) //Això ens dona una array sense nombres repetits
                {
                    if (orderTurns[j] == order)
                    {
                        found = true;
                        i--;
                        j = 4;
                    }
                }
                if (found == false)
                {
                    orderTurns[i] = order;
                }
            }
            return orderTurns;
        }
        public static double FightMenu(int choice, double atkAtacker, string nameAtacker, double hpMonstre, double defMonstre, string monstre)
        {
            const string DMG = "{0} fa {1} punts de dany a {2}", HP = " qui resta amb {0} punts de vida", DEF = "{0} es posa en guardia",
                MISS = "{0} ha fallat el seu atac!", CRIT = "ATAC CRÍTIC!", DEAD = "El monstre ha mort";
            Random crit = new Random();
            Random miss = new Random();

            if (choice == 1)
            {
                if (miss.Next(1, 21) == 1)
                {
                    Console.WriteLine(MISS, nameAtacker);
                    return hpMonstre;
                }
                else
                {
                    if (crit.Next(1, 11) == 1)
                    {
                        Console.WriteLine(CRIT);
                        Console.Write(DMG, nameAtacker, 2 * (atkAtacker - (atkAtacker * defMonstre / 100)), monstre);
                        if (hpMonstre - 2 * (atkAtacker - (atkAtacker * defMonstre / 100)) > 0)
                        {
                            Console.WriteLine(HP, hpMonstre - 2 * (atkAtacker - (atkAtacker * defMonstre / 100)));
                            return hpMonstre - 2 * (atkAtacker - (atkAtacker * defMonstre / 100));
                        }
                        else
                        {
                            Console.WriteLine(DEAD);
                            return 0;
                        }
                    }
                    else
                    {
                        Console.Write(DMG, nameAtacker, atkAtacker - (atkAtacker * defMonstre / 100), monstre);
                        if (hpMonstre - (atkAtacker - (atkAtacker * defMonstre / 100)) > 0)
                        {
                            Console.WriteLine(HP, hpMonstre - (atkAtacker - (atkAtacker * defMonstre / 100)));
                            return hpMonstre - (atkAtacker - (atkAtacker * defMonstre / 100));
                        }
                        else
                        {
                            Console.WriteLine(DEAD);
                            return 0;
                        }
                    }
                }
            }
            else if (choice == 2)
            {
                Console.WriteLine(DEF, nameAtacker);
                return -1; //Això és perquè el programa sàpiga que s'ha defensat
            }
            else
            {
                return hpMonstre;
            }
        }
        public static double FightMenu(double atkAtacker, string nameAtacker, double hpMonstre, double defMonstre, string monstre, int character)
        {
            const string DMG = "{0} fa {1} punts de dany a {2}", HP = " qui resta amb {0} punts de vida", DEAD = "El monstre ha mort";
            double exceedCheck = hpMonstre - 3 * (atkAtacker - (atkAtacker * defMonstre / 100));
            if (character == 3)
            {
                Console.Write(DMG, nameAtacker, 3 * (atkAtacker - (atkAtacker * defMonstre / 100)), monstre);
                if (exceedCheck > 0)
                {
                    Console.WriteLine(HP, hpMonstre - 2 * (atkAtacker - (atkAtacker * defMonstre / 100)));
                    return exceedCheck;
                }
                else
                {
                    Console.WriteLine(DEAD);
                    return 0;
                }
            }
            else return 3;
        }
        public static double AttackMonster(double atkMonster, double hpReciever, double defReciever, string nameReciever, string MONSTER, bool def)
        {
            const string DMG = "{0} fa {2} punts de dany a {1}", DEAD = "{0} ha caigut en batalla";
            double exceedCheck;
            if (hpReciever > 0)
            {
                if (def == false)
                {
                    exceedCheck = hpReciever - (atkMonster - (atkMonster * (defReciever / 100)));
                    if (exceedCheck > 0)
                    {
                        Console.WriteLine(DMG, MONSTER, nameReciever, atkMonster - (atkMonster * (defReciever / 100)));
                        return exceedCheck;
                    }
                    else
                    {
                        Console.WriteLine(DMG, MONSTER, nameReciever, atkMonster - (atkMonster * (defReciever / 100)));
                        Console.WriteLine(DEAD, nameReciever);
                        return 0;
                    }
                }
                else
                {
                    exceedCheck = hpReciever - (atkMonster - (atkMonster * (2 * defReciever / 100)));
                    if (exceedCheck > 0)
                    {
                        Console.WriteLine(DMG, MONSTER, nameReciever, atkMonster - (atkMonster * (2 * defReciever / 100)));
                        return exceedCheck;
                    }
                    else
                    {
                        Console.WriteLine(DMG, MONSTER, nameReciever, atkMonster - (atkMonster * (2 * defReciever / 100)));
                        Console.WriteLine(DEAD, nameReciever);
                        return 0;
                    }
                }
            }
            else return 0;

        }
        public static double Heal(double hpHeal, double storedHeal, string nameHeal, int heal)
        {
            const string Restore = "{0} recupera {1} punts de vida";
            double exceedCheck = storedHeal - (hpHeal + 500);

            if (exceedCheck < 0)
            {
                Console.WriteLine(Restore, nameHeal, storedHeal - hpHeal);
                return storedHeal;
            }
            else
            {
                Console.WriteLine(Restore, nameHeal, heal);
                return hpHeal + heal;
            }
        }
        public static double[] SortArray(double[] NumArray)
        {
            int length = NumArray.Length;
            for (int i = 0; i < length - 1; i++)
                for (int j = 0; j < length - i - 1; j++)
                    if (NumArray[j] > NumArray[j + 1])
                    {
                        double aux = NumArray[j];
                        NumArray[j] = NumArray[j + 1];
                        NumArray[j + 1] = aux;
                    }
            return NumArray;
        }
    }
}