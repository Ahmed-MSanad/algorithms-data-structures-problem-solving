namespace Algorithms_ProblemSolving.Algorithms
{
    public class HeapSort
    {
        public static void Sort(int[] numbers, Func<int, int, bool> compare)
        {
            // Build heap (Bottom-Up): start from the last internal node and heapify each node till the root node
            for (int i = numbers.Length / 2 - 1; i >= 0; i--)
                Heapify(numbers, numbers.Length, i, compare);

            for (int i = numbers.Length - 1; i > 0; i--)
            {
                Swap(ref numbers[0], ref numbers[i]); // move root to end
                Heapify(numbers, i, 0, compare); // fix heap from root
            }
        }
        private static void Heapify(int[] numbers, int heapSize, int index, Func<int, int, bool> compare) // convert either to max-heap or min-heap based on the compare function
        {
            int left = index * 2 + 1,
                right = index * 2 + 2,
                selected = index;

            if (left < heapSize && compare(numbers[selected], numbers[left])) selected = left;
            if (right < heapSize && compare(numbers[selected], numbers[right])) selected = right;

            if(selected != index)
            {
                Swap(ref numbers[selected], ref numbers[index]);
                Heapify(numbers, heapSize, selected, compare);
            }
        }
        private static void Swap(ref int a1, ref int a2)
        {
            int temp = a1;
            a1 = a2;
            a2 = temp;
        }
        public static void Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('=', 100));
            Console.WriteLine("Heap Sort");

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
