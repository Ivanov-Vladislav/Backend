using System;
using System.Linq;


namespace PasswordStrength
{
    public struct Arguments
    {
        public string inputPassword;

    }
    public static class PasswordStrengthProgramm
    {
        public static int CalculateByLenght(string password)
        {
            return 4 * password.Length;
        }
        public static int CalculateByNumbers(string password)
        {
            var count = password.Where((n) => n >= '0' && n <= '9').Count();
            return count *= 4;
        }

        public static int CalculateByUpperCase(string password)
        {
            var count = password.Where((n) => n >= 'A' && n <= 'Z').Count();
            if (count != 0)
            {
                return (password.Length - count) * 2;
            }
            return 0;
        }

        public static int CalculateByLowerCase(string password)
        {
            var count = password.Where((n) => n >= 'a' && n <= 'z').Count();
            if (count != 0)
            {
                return (password.Length - count) * 2;
            }
            return 0;
        }
        public static int CalculateByNumbers(string password)
        {
            var count = password.Where((n) => n >= '0' && n <= '9').Count();
            if (count == password.Length)
            {
                return -count;
            }
            return 0;
        }
        public static int CalculateByLetters(string password)
        {
            var count = password.Count(char.IsLetter);
            if (count == password.Length)
            {
                return -count;
            }
            return 0;
        }
        public static int CalculateByReapetedSymbols(string password)
        {
            var count = 0;
            var res = 0;
            char prevCh = '\0';
            foreach (var letter in password.Distinct().ToArray())
            {
                count = password.Count(chr => chr == letter);
                if (count != 1)
                {
                    res += count;
                }
            }
            return -res;
        }
        public static int PasswordStrength(string password)
        {
            int passwordStrenght = 0;
            passwordStrenght += CalculateByLenght(password);
            passwordStrenght += CalculateByNumbers(password);
            passwordStrenght += CalculateByUpperCase(password);
            passwordStrenght += CalculateByLowerCase(password);
            passwordStrenght += CalculateByLetters(password);
            passwordStrenght += CalculateByNumbers(password);
            passwordStrenght += CalculateByReapetedSymbols(password);
            return passwordStrenght;
        }
    }

    class Program
    {
        public static Arguments? ParseArg(string[] args)
        {
            Arguments arguments = new Arguments();
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of arguments");
                Console.WriteLine("Usage: PasswordStrength.exe <input password>");
                return null;
            }
            arguments.inputPassword = args[0];
            return arguments;
        }
        static int Main(string[] args)
        {
            Arguments? arguments = new Arguments();
            arguments = ParseArg(args);
            if (arguments == null)
            {
                return 1;
            }
            int passwordStrenght = PasswordStrengthProgramm.PasswordStrength(arguments.Value.inputPassword);
            return 1;
        }
    }
}