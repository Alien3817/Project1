namespace ConsoleApp1
{
    class Program
    {
        public static class Codes
        {

            private static float Sum(ref double[] doubles, int L, int R)
            {
                float Sum = 0;
                for (int i = L; i < R; ++i)
                {
                    Sum += (float)doubles[i];
                }
                return Sum;
            }

            private static int Index(ref double[] doubles, int L, int R)
            {
                int Mid = (L + R) / 2;

                float L_Sum = 0f, R_Sum = 0f;

                L_Sum = Sum(ref doubles, L, Mid);
                R_Sum = Sum(ref doubles, Mid, R);

                float L_SC = L_Sum, R_SC = R_Sum;
                for (int i = 1; ; ++i)
                {
                    if (Math.Abs(L_SC - R_SC) < Math.Abs(L_Sum - R_Sum)) { return Mid - i + 2; }
                    else if (R_Sum >= L_Sum || Mid - i - L < 1) { return Mid - i + 1; }
                    else
                    {
                        L_SC = L_Sum; R_SC = R_Sum;
                        L_Sum -= (float)doubles[Mid - i];
                        R_Sum += (float)doubles[Mid - i];
                    }
                }
            }
            private static void StrCreate(ref string[] str, ref double[] doubles, int sPos, int ePos)
            {
                if (ePos - sPos < 2) { return; }

                int index = Index(ref doubles, sPos, ePos);

                for (int i = sPos; i < index; ++i)
                {
                    str[i] += '0';
                }
                for (int i = index; i < ePos; ++i)
                {
                    str[i] += '1';
                }

                StrCreate(ref str, ref doubles, sPos, index);
                StrCreate(ref str, ref doubles, index, ePos);
            }

            public static string[] BinaryCodes(ref double[] doubles)
            {
                int length = doubles.Length;
                string[] str = new string[length];

                if (length == 1) { str[0] += '0'; }
                else { StrCreate(ref str, ref doubles, 0, length); }

                return str;
            }

            public static void change(ref double[] chances, ref Dictionary<char, double> dict, ref string str, ref Dictionary<char, int> letters_count)
            {
                int i = 0;
                foreach (char key in letters_count.Keys)
                {
                    double count = letters_count[key];
                    chances[i] = count / str.Length;
                    dict[key] = chances[i];
                    i++;
                }
                dict = dict.OrderBy(pair => pair.Value).Reverse().ToDictionary(pair => pair.Key, pair => pair.Value);
                chances = chances.OrderBy(x => x).Reverse().ToArray();
            }

            public static Dictionary<char, int> get_dict_of_counts(ref string str)
            {
                Dictionary<char, int> letters_count = new Dictionary<char, int>();
                foreach (char ch in str)
                {
                    if (!letters_count.ContainsKey(ch))
                        letters_count[ch] = 1;
                    else
                        letters_count[ch]++;
                }
                return letters_count;
            }

            public static Dictionary<char, string> CreateEncodingDictionary(Dictionary<char, double> dict, string[] SlavaList)
            {

                Dictionary<char, string> encodingDictionary = new Dictionary<char, string>();

                for (int i = 0; i < dict.Count; i++)
                {
                    char character = dict.Keys.ElementAt(i);
                    string Code = SlavaList[i];
                    encodingDictionary[character] = Code;
                }

                return encodingDictionary;
            }
        }
        static void Main()
        {

            Console.WriteLine("Введите строку:");
            string str = Console.ReadLine();                    //Ввод строки
            if (str != "")                          //Проверка на пустую строку
            {
                Dictionary<char, int> letters_count = Codes.get_dict_of_counts(ref str);            //Создание словаря количества символов
                double[] chances = new double[letters_count.Count];                             //Выделение памяти под массив вероятностей
                Dictionary<char, double> dict = new Dictionary<char, double>();                 //Создание пустого словаря (Символ - вероятность)
                Codes.change(ref chances, ref dict, ref str, ref letters_count);                //Формирование массива вероятностей и словаря с вероятностями
                string[] codes = Codes.BinaryCodes(ref chances);                    //Создание массива двоичных кодов
                Dictionary<char, string> result = Codes.CreateEncodingDictionary(dict, codes);          //Создание словаря символов с кодами
                foreach (char key in result.Keys)
                {
                    Console.WriteLine(key + " - " + result[key]);
                }
            }
            else
                Console.WriteLine("Пустая строка!");
        }
    }
}