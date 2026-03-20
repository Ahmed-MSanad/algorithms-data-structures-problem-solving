namespace Algorithms_ProblemSolving.Algorithms
{
    public class OptimizedMergeSort
        /* 
         * 1. Using one auxiliary array instead of creating arrays every merge.
         * 2. Hybrid with Insertion Sort For small subarrays (< 10 elements).
         */
    {
        private const int INSERTION_SORT_THRESHOLD = 10;
        public static void Sort(int[] numbers, Func<int, int, bool> compare)
        {
            if (numbers == null || numbers.Length < 2) return;
            
            int[] aux = new int[numbers.Length];

            Merge_Sort(numbers, aux, 0, numbers.Length - 1, compare);
        }
        private static void Merge_Sort(int[] numbers, int[] aux, int l, int r, Func<int, int, bool> compare) // Time Complexity: O(nlog n) , Space Complexity: O(n)
        {
            if(r - l + 1 <= INSERTION_SORT_THRESHOLD)
            {
                InsertionSort.Sort(numbers, compare);
                return;
            }

            int mid = (r - l) / 2 + l;
            Merge_Sort(numbers, aux, l, mid, compare);
            Merge_Sort(numbers, aux, mid + 1, r, compare);
            Merge(numbers, aux, l, mid, r, compare);
        }
        private static void Merge(int[] numbers, int[] aux, int l, int mid, int r, Func<int, int, bool> compare) // Time Complexity: O(n) , Space Complexity: O(n)
        {
            for (int z = l; z <= r; z++) { aux[z] = numbers[z]; }

            int current = l, i = l, j = mid + 1;
            while (i <= mid && j <= r)
            {
                if (compare(aux[i], aux[j]) || aux[i] == aux[j]) numbers[current++] = aux[i++];
                else numbers[current++] = aux[j++];
            }

            while (i <= mid) numbers[current++] = aux[i++]; // Copy remaining left half -> right half already in place
        }
        public static void Run()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(new string('=', 100));
            Console.WriteLine("Optimized Merge Sort");

            int[] numbers = { 9, 2, 1, 10, 3, 2 };
            Sort(numbers, (a, b) => a < b);
            Console.WriteLine(string.Join(',', numbers));
            Sort(numbers, (a, b) => a > b);
            Console.WriteLine(string.Join(',', numbers));

            Console.WriteLine(new string('=', 100));
            Console.ResetColor();
        }
    }
}
