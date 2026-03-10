namespace Algorithms_ProblemSolving.Algorithms
{
    public class SelectionSort
    {
        public static void Sort(int[] numbers, Func<int, int, bool> compare)
        {
            for(int j = 0; j < numbers.Length - 1; j++)
            {
                int i = j + 1, keyIndex = j;
                while(i < numbers.Length)
                {
                    keyIndex = compare(numbers[i], numbers[keyIndex]) ? i : keyIndex;
                    i++;
                }
                if (keyIndex != j)
                {
                    int temp = numbers[j];
                    numbers[j] = numbers[keyIndex];
                    numbers[keyIndex] = temp;
                }
            }
        }

        public static void Run()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(new string('=', 100));
            Console.WriteLine("Selection Sort");

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
