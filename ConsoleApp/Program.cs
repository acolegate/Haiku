using System;

namespace Haiku
{
    internal class Program
    {
        private static readonly string CrLf = Environment.NewLine;

        private static void Main(string[] args)
        {
            Random random = new Random();

            if (args.Length == 1)
            {
                int seed;
                if (int.TryParse(args[0], out seed))
                {
                    random = new Random(seed);
                }
            }

            HaikuGenerator haikuGenerator = new HaikuGenerator(random);

            Console.Clear();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(CrLf + haikuGenerator.Generate(2));
            }
        }
    }
}