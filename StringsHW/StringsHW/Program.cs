using System.Globalization;

namespace StringsHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Comparison
            Console.Write("Enter first strign: ");
            string firstString = Console.ReadLine();
            Console.Write("Enter second strign: ");
            string secondString = Console.ReadLine();

            bool comparisonResult = Compare(firstString, secondString);

            Console.WriteLine($"{firstString} and {secondString} are Equal: {comparisonResult}");

            // Analyzing
            string stringToAnalyze = "123 fds ,.+~";
            Analyze(stringToAnalyze, out int digNum, out int letterNum, out int symbolsNum);
            Console.WriteLine($"\nString \"{stringToAnalyze}\" has:\n" +
                $"{digNum} digits\n" +
                $"{letterNum} letters\n" +
                $"{symbolsNum} special symbols");

            // Sorting
            string s1 = Sort("Hello");
            Console.WriteLine("\n" + s1);

            // Duplicates
            string suspiciousString = "Hello land hi";
            char[] duplicates = Duplicate(suspiciousString);
            Console.WriteLine($"\n{suspiciousString} has following duplicated chars:");

            Console.WriteLine(String.Join(", ", duplicates));
        }
        public static bool Compare(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                    return false;
            }
            return true;
        }

        public static void Analyze(string s, out int numOfDigits, out int numOfAlphabetChars, out int numOfSpecialSigns)
        {
            numOfDigits = 0;
            numOfAlphabetChars = 0;
            numOfSpecialSigns = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int charAscii = (byte)s[i];
                if (charAscii >= 48 && charAscii <= 57)
                    numOfDigits++;
                else if ((charAscii >= 65 && charAscii <= 90) || (charAscii >= 97 && charAscii <= 122))
                    numOfAlphabetChars++;
                else if (charAscii >= 33 && charAscii <= 127)
                    numOfSpecialSigns++;
            }
        }

        public static string Sort(string s)
        {
            s = s.ToLower();
            char[] arr = new char[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                arr[i] = s[i];
            }

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if ((sbyte)(arr[j]) > (sbyte)(arr[j + 1]))
                    {
                        char temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            return new string(arr);
        }

        public static char[] Duplicate(string s)
        {
            s = s.ToLower();
            char[] verifiedUniqueChar = new char[0];
            char[] duplicatesArr = new char[0];
            int duplicateIndexer = 0, verifiedElemIndex = 0;

            for (int i = 0; i < s.Length; i++)
            {
                // check if char already added in duples
                bool isAdded = false;
                for (int k = 0; k < duplicatesArr.Length; k++)
                {
                    if (s[i] == duplicatesArr[k])
                    {
                        isAdded = true;
                        break;
                    }
                }
                if (isAdded)
                    continue;

                for (int j = 0; j < verifiedUniqueChar.Length; j++)
                {
                    if (Char.IsWhiteSpace(s[i]))
                        continue;

                    if (verifiedUniqueChar[j] == s[i])
                    {
                        // adding duples
                        Array.Resize(ref duplicatesArr, duplicatesArr.Length + 1);
                        duplicatesArr[duplicateIndexer++] = s[i];
                    }
                }
                // adding tested chars
                Array.Resize(ref verifiedUniqueChar, verifiedUniqueChar.Length + 1);
                verifiedUniqueChar[verifiedElemIndex++] = s[i];
            }
            return duplicatesArr;
        }
    }
}