using Algorithms_ProblemSolving.Algorithms;

namespace Algorithms_ProblemSolving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 2, 3, 6, 7, 1 };
            
            InsertionSort.Run(numbers, (a, b) => a < b);
            Console.WriteLine(string.Join(',', numbers));

            InsertionSort.Run(numbers, (a, b) => a > b);
            Console.WriteLine(string.Join(',', numbers));
        }
    }
}
