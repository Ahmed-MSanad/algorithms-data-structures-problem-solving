namespace Algorithms_ProblemSolving.Algorithms
{
    public static class BubbleSort
    {
        public static void Sort(int[] numbers, Func<int, int, bool> compare)
        {
            for(int j = 0; j < numbers.Length - 1; j++)
            {
                bool swapped = false;
                for (int i = 0; i < numbers.Length - 1 - j; i++)
                {
                    if (compare(numbers[i + 1], numbers[i]))
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped) break;
            }
        }

        public static void Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('=', 100));
            Console.WriteLine("Bubble Sort");

            int[] numbers = { 5, 2, 3, 6, 7, 1 };
            Sort(numbers, (a, b) => a < b);
            Console.WriteLine(string.Join(',', numbers));
            Sort(numbers, (a, b) => a > b);
            Console.WriteLine(string.Join(',', numbers));

            Console.WriteLine(new string('=', 100));
            Console.ResetColor();
        }
    }
}
