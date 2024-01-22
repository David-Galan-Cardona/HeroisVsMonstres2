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
        public static string CheckForCommas(string names, int num)
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
    }
}