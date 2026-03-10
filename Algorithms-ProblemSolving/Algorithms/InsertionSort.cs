namespace Algorithms_ProblemSolving.Algorithms
{
    public class InsertionSort
    {
        public static void Run(int[] numbers, Func<int, int, bool> compare)
        {
            for(int j = 1; j < numbers.Length; j++)
            {
                int key = numbers[j], i = j - 1;
                while(i >= 0 && compare(key, numbers[i]))
                {
                    numbers[i + 1] = numbers[i];
                    i--;
                }
                numbers[i + 1] = key;
            }
        }
    }
}
