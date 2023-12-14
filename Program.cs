namespace AdventOfCode
{
    using AdventOfCode._2022;
    using AdventOfCode._2023;

    internal class Program
    {
        static void Main(string[] args)
        {
            var year = 2023;
            var day = 11;

            IQuizRunner runner;
            switch (year)
            {
                case 2023:
                    runner = new QuizRunner2023();
                    runner.Run(day);
                    break;

                case 2022:
                    runner = new QuizRunner2022();
                    runner.Run(day);
                    break;
            }

            Console.ReadLine();
        }
    }
}
