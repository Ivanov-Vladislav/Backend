using System;

namespace print_args
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {

                Console.WriteLine("No parameters  were   specified!");
                Environment.Exit(1);

            }

            Console.WriteLine("Number of arguments: {0}", args.Length);
            Console.WriteLine("Arguments: {0}", string.Join(" ", args));

        }
    }
}