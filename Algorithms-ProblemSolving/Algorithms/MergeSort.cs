namespace Algorithms_ProblemSolving.Algorithms
{
    public class MergeSort
    {
        public static void Sort(int[] numbers, Func<int, int, bool> compare)
        {
            if (numbers == null || numbers.Length < 2) return;
            Merge_Sort(numbers, 0, numbers.Length - 1, compare);
        }
        private static void Merge_Sort(int[] numbers, int l, int r, Func<int, int, bool> compare) // Time Complexity: O(nlog n) , Space Complexity: O(n)
        {
            if (l >= r) return;

            int mid = (r - l) / 2 + l;
            Merge_Sort(numbers, l, mid, compare);
            Merge_Sort(numbers, mid + 1, r, compare);
            Merge(numbers, l, mid, r, compare);
        }
        private static void Merge(int[] numbers, int l, int mid, int r, Func<int, int, bool> compare) // Time Complexity: O(n) , Space Complexity: O(n)
        {
            int n1 = mid - l + 1, n2 = r - mid;

            int k = l, i = 0, j = 0;

            int[] leftArr = new int[n1], rightArr = new int[n2];

            for (i = 0; i < n1; i++) { leftArr[i] = numbers[l + i]; }
            for (i = 0; i < n2; i++) { rightArr[i] = numbers[mid + 1 + i]; }

            i = 0;j = 0;
            while(i < n1 && j < n2)
            {
                if (compare(leftArr[i], rightArr[j]) || leftArr[i] == rightArr[j]) numbers[k++] = leftArr[i++];
                else numbers[k++] = rightArr[j++];
            }

            while (i < n1) numbers[k++] = leftArr[i++];
            while (j < n2) numbers[k++] = rightArr[j++];
        }
        public static void Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('=', 100));
            Console.WriteLine("Merge Sort");

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
