using System;

namespace CheckIdentifier
{
    public class CheckIdentifierLib
    {
        
        public static bool IsLetter(char ch)
        {
            if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'))
            {
                return true;
            }
            return false;
        }

        public static bool IsCorrectIdentifier(string identifier)
        {
            if (identifier.Length == 0 || !char.IsLetter(identifier, 0))
            {
                Console.WriteLine("No");
                Console.WriteLine("Invalid identifier: identifier must begin with a letter");
                return false;
            }
            foreach (char ch in identifier)
            {
                if (!IsLetter(ch) && !char.IsDigit(ch))
                {
                    Console.WriteLine("No");
                    Console.WriteLine("Incorrect character: '" + ch + "'");
                    return false;
                }
            }
            Console.WriteLine("Yes");
            return true;
        }
    }
    public class Program
    {
        public static bool ParseArgs(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Invalid number of arguments\n" +
                                  "Usage CheckIdentifier.exe <identifier>");
                return false;
            }
            return true;
        }
        static int Main(string[] args)
        {            
            if (!ParseArgs(args))
            {
                return 1;
            }
            string identifier = args[0];
            if (!CheckIdentifierLib.IsCorrectIdentifier(identifier))
            {
                return 1;
            }
            return 0;
        }
    }
}
