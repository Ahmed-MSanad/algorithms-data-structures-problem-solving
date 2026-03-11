namespace Algorithms_ProblemSolving.Algorithms
{
    public static class QuickSort
    {
        public static void Sort(int[] arr, Func<int, int, bool> compare)
        {
            Sort(arr, 0, arr.Length - 1, compare);
        }
        private static void Sort(int[] numbers, int low, int high, Func<int, int, bool> compare)
        {
            if (low >= high) return;
            int pivotIndex = Lomuto_Partition(numbers, low, high, compare);
            Sort(numbers, low, pivotIndex - 1, compare);
            Sort(numbers, pivotIndex + 1, high, compare);

            // OR:

            //int pivotIndex = Hoare_Partition(numbers, low, high, compare);
            //Sort(numbers, low, pivotIndex, compare);
            //Sort(numbers, pivotIndex + 1, high, compare);
        }
        static Random rand = new Random();
        private static int Lomuto_Partition(int[] numbers, int low, int high, Func<int, int, bool> compare)
        {
            Swap(numbers, rand.Next(low, high + 1), high);

            int pivot = numbers[high], i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (compare(numbers[j], pivot))
                {
                    i++;
                    Swap(numbers, i, j);
                }
            }
            i++;
            Swap(numbers, i, high);
            return i;
        }
        private static int Hoare_Partition(int[] numbers, int low, int high, Func<int, int, bool> compare)
        {
            Swap(numbers, rand.Next(low, high + 1), low);

            int pivot = numbers[low], i = low - 1, j = high + 1;
            while (true)
            {
                do { i++; } while(compare(numbers[i], pivot));
                do { j--; } while(compare(pivot, numbers[j]));

                if (i >= j) return j;

                Swap(numbers, i, j);
            }
        }
        private static void Swap(int[] numbers, int i, int j)
        {
            int temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }

        public static void Run()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(new string('=', 100));
            Console.WriteLine("Insertion Sort");

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
