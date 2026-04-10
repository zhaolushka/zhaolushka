using System;
using System.Collections.Generic;

namespace ArraysLoopsPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 01 Sum of all elements
            int[] numbers = { 3, 7, 2, 9, 5, 1 };
            int sum = 0;
            foreach (int num in numbers)
                sum += num;
            Console.WriteLine($"01 Sum = {sum}");

            // 02 Find min and max
            int[] temps = { 12, -3, 45, 0, 28, -10, 33 };
            int min = temps[0], max = temps[0];
            for (int i = 1; i < temps.Length; i++)
            {
                if (temps[i] > max) max = temps[i];
                if (temps[i] < min) min = temps[i];
            }
            Console.WriteLine($"02 Min = {min}, Max = {max}");

            // 03 Reverse an array
            string[] words = { "apple", "banana", "cherry", "date" };
            for (int i = 0; i < words.Length / 2; i++)
            {
                string temp = words[i];
                words[i] = words[words.Length - 1 - i];
                words[words.Length - 1 - i] = temp;
            }
            Console.Write("03 Reversed: ");
            for (int i = 0; i < words.Length; i++)
                Console.Write(words[i] + " ");
            Console.WriteLine();

            // 04 Count even and odd numbers
            int[] data = { 4, 7, 2, 11, 6, 9, 14, 3, 8 };
            int evenCount = 0, oddCount = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] % 2 == 0) evenCount++;
                else oddCount++;
            }
            Console.WriteLine($"04 Even = {evenCount}, Odd = {oddCount}");

            // 05 Remove duplicates
            int[] raw = { 1, 3, 2, 3, 5, 1, 4, 2, 5 };
            List<int> unique = new List<int>();
            for (int i = 0; i < raw.Length; i++)
            {
                if (!unique.Contains(raw[i]))
                    unique.Add(raw[i]);
            }
            Console.Write("05 Unique: ");
            foreach (int num in unique) Console.Write(num + " ");
            Console.WriteLine();

            // 06 Rotate array left by K steps
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            int k = 3;
            int[] rotated = RotateLeft(arr, k);
            Console.Write("06 Rotated: ");
            foreach (int num in rotated) Console.Write(num + " ");
            Console.WriteLine();

            // 07 IsPalindrome
            string[] testWords = { "madam", "hello", "racecar" };
            Console.WriteLine("07 Palindrome check:");
            foreach (string w in testWords)
                Console.WriteLine($"{w} -> {IsPalindrome(w)}");

            // 08 Factorial
            int m = 5;
            Console.WriteLine($"08 Factorial({m}) = {Factorial(m)}");

            // 09 FizzBuzz from 1 to 20
            Console.WriteLine("09 FizzBuzz:");
            for (int i = 1; i <= 20; i++)
                Console.WriteLine($"{i} -> {FizzBuzz(i)}");

            // 10 Celsius ↔ Fahrenheit converter
            double[] celsius = { 0, 20, 37, 100, -40 };
            Console.WriteLine("10 Celsius ↔ Fahrenheit:");
            for (int i = 0; i < celsius.Length; i++)
            {
                double f = ToFahrenheit(celsius[i]);
                Console.WriteLine($"{celsius[i]}°C = {f:F1}°F");
            }
        }

        static int[] RotateLeft(int[] arr, int k)
        {
            int n = arr.Length;
            k = k % n;
            int[] result = new int[n];
            int index = 0;
            for (int i = k; i < n; i++)
                result[index++] = arr[i];
            for (int i = 0; i < k; i++)
                result[index++] = arr[i];
            return result;
        }

        static bool IsPalindrome(string s)
        {
            for (int i = 0; i < s.Length / 2; i++)
                if (s[i] != s[s.Length - 1 - i])
                    return false;
            return true;
        }

        static long Factorial(int n)
        {
            long result = 1;
            for (int i = 2; i <= n; i++)
                result *= i;
            return result;
        }

        static string FizzBuzz(int n)
        {
            if (n % 15 == 0) return "FizzBuzz";
            else if (n % 3 == 0) return "Fizz";
            else if (n % 5 == 0) return "Buzz";
            else return n.ToString();
        }

        static double ToFahrenheit(double c) => c * 9.0 / 5.0 + 32;
        static double ToCelsius(double f) => (f - 32) * 5.0 / 9.0;
    }
}