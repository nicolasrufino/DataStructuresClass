/* ------------------ Find and Fix the Big O Problem #1 ------------------ */

// using System;
// using System.Collections.Generic;
// using System.Linq;

// class Program
// {
//     static void Main()
//     {
//         List<int> numbers = new List<int> { 5, 3, 8, 1, 9, 2, 7, 4, 6 };

//         Console.WriteLine("Sum of numbers: " + Sum(numbers));
//         Console.WriteLine("Maximum value: " + FindMax(numbers));
//         Console.WriteLine("Find prime numbers: " + string.Join(", ", FindPrimes(numbers)));
//         Console.WriteLine("Find duplicates: " + string.Join(", ", FindDuplicates(numbers)));

//         Console.WriteLine("Sorting numbers...");
//         List<int> sortedNumbers = SortNumbers(numbers);
//         Console.WriteLine("Sorted numbers: " + string.Join(", ", sortedNumbers));
//     }

//     static int Sum(List<int> numbers)
//     {
//         int sum = 0;
//         foreach (var number in numbers)
//         {
//             sum += number;
//         }
//         return sum;
//     }

//     static int FindMax(List<int> numbers)
//     {
//         int max = int.MinValue;
//         foreach (var number in numbers)
//         {
//             if (number > max)
//             {
//                 max = number;
//             }
//         }
//         return max;
//     }

//     static List<int> FindPrimes(List<int> numbers)
//     {
//         List<int> primes = new List<int>();
//         foreach (var number in numbers)
//         {
//             if (IsPrime(number))
//             {
//                 primes.Add(number);
//             }
//         }
//         return primes;
//     }

//     static bool IsPrime(int number)
//     {
//         if (number <= 1) return false;
//         if (number == 2) return true;
//         if (number % 2 == 0) return false;

//         var boundary = (int)Math.Floor(Math.Sqrt(number));

//         for (int i = 3; i <= boundary; i += 2)
//         {
//             if (number % i == 0) return false;
//         }

//         return true;
//     }

//     static List<int> FindDuplicates(List<int> numbers)
//     {
//         HashSet<int> seen = new HashSet<int>();
//         List<int> duplicates = new List<int>();

//         foreach (var number in numbers)
//         {
//             if (!seen.Add(number))
//             {
//                 duplicates.Add(number);
//             }
//         }

//         return duplicates;
//     }

//     static List<int> SortNumbers(List<int> numbers)
//     {
//         List<int> sorted = new List<int>(numbers);
//         sorted.Sort();
//         return sorted;
//     }
// }
/*------------------ Find and Fix the Big O Problem #2 ------------------*/

using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        Console.WriteLine("Sum of numbers: " + Sum(numbers));
        Console.WriteLine("Largest number: " + FindLargest(numbers));
        Console.WriteLine("Generated string: " + GenerateNumberString(numbers));
        Console.WriteLine("Numbers concatenated together: " + ConcatenateNumbers(numbers));
    }

    static int Sum(List<int> numbers)
    {
        int sum = 0;
        foreach (var number in numbers)
        {
            sum += number;
        }
        return sum;
    }

    static int FindLargest(List<int> numbers)
    {
        int largest = int.MinValue;
        foreach (var number in numbers)
        {
            if (number > largest)
            {
                largest = number;
            }
        }
        return largest;
    }

    static string GenerateNumberString(List<int> numbers)
    {
        StringBuilder result = new StringBuilder();
        foreach (var number in numbers)
        {
            result.Append(number.ToString());
            result.Append(", ");
        }
        return result.ToString().TrimEnd(',', ' ');
    }

    static string ConcatenateNumbers(List<int> numbers)
    {
        StringBuilder result = new StringBuilder();
        foreach (var number in numbers)
        {
            result.Append(number.ToString());
        }
        return result.ToString();
    }
}