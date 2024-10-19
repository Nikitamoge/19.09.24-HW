using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text.Json;
using System.IO;
using System.Linq;

//Task 1
public delegate void MessageDelegate(string message);

public class Program
{
    public static void ShowMessage(string message)
    {
        Console.WriteLine("Message: " + message);
    }

    public static void AnotherMessage(string message)
    {
        Console.WriteLine("Another message: " + message);
    }

    //Task 2
    public delegate double ArithmeticDelegate(double a, double b);

    public static double Add(double a, double b)
    {
        return a + b;
    }

    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    //Task 3
    public static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    public static bool IsOdd(int number)
    {
        return number % 2 != 0;
    }

    public static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        for (int i = 2; i < number; i++)
            if (number % i == 0) return false;
        return true;
    }

    public static bool IsFibonacci(int number)
    {
        int a = 0, b = 1, temp = 0;
        while (temp < number)
        {
            temp = a + b;
            a = b;
            b = temp;
        }
        return number == temp || number == 0;
    }


    static void Main(string[] args)
    {
        //Task 1
        MessageDelegate messageDelegate = ShowMessage;
        messageDelegate("Hello, world!");

        messageDelegate = AnotherMessage;
        messageDelegate("How are you?");

        messageDelegate = msg => Console.WriteLine("Lambda message: " + msg);
        messageDelegate("This is a lambda expression!");


        //Task 2
        ArithmeticDelegate addDelegate = Add;
        ArithmeticDelegate subtractDelegate = Subtract;
        ArithmeticDelegate multiplyDelegate = Multiply;

        Console.WriteLine("Addition: " + addDelegate.Invoke(10, 5));
        Console.WriteLine("Subtraction: " + subtractDelegate.Invoke(10, 5));
        Console.WriteLine("Multiplication: " + multiplyDelegate.Invoke(10, 5));

        //Task 3
        Predicate<int> evenPredicate = IsEven;
        Predicate<int> oddPredicate = IsOdd;
        Predicate<int> primePredicate = IsPrime;
        Predicate<int> fibonacciPredicate = IsFibonacci;

        Console.WriteLine("Is 10 even? " + evenPredicate(10));
        Console.WriteLine("Is 9 odd? " + oddPredicate(9));
        Console.WriteLine("Is 7 prime? " + primePredicate(7));
        Console.WriteLine("Is 8 Fibonacci? " + fibonacciPredicate(8));


        //Task 4
        Predicate<int> isEven = delegate (int number)
        {
            return number % 2 == 0;
        };

        Console.WriteLine("Is 10 even? " + isEven(10));


        //Task 5
        Func<int, int> cube = x => x * x * x;
        Console.WriteLine("Cube of 3: " + cube(3));


        //Task 6
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var oddNumbers = numbers.Where(n => n % 2 != 0);

        Console.WriteLine("Odd numbers: " + string.Join(", ", oddNumbers));


        //Task 7
        string text = "Hi, use C#";
        Console.WriteLine("Number of sentences: " + text.SentenceCount());


        //Task 8
        string anotherText = "Don't use Python";
        Console.WriteLine("Number of words starting and ending with the same letter: " + anotherText.CountWordsWithSameStartEnd());


        //Task 9
        Predicate<int> primePredicateTask9 = IsPrime;
        Func<DateTime, DateTime, int> countDaysFunc = CountDaysBetween;

        Console.WriteLine("Is 21 prime? " + primePredicateTask9(21));
        Console.WriteLine("Days between 2023-1-05 and 2023-1-19: " + countDaysFunc(new DateTime(2024, 10, 01), new DateTime(2024, 10, 19)));
    }

    public static int CountDaysBetween(DateTime startDate, DateTime endDate)
    {
        return (endDate - startDate).Days;
    }
}


//Task 7
public static class StringExtensions
{
    public static int SentenceCount(this string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return 0;

        return text.Split(new char[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }


    //Task 8
    public static int CountWordsWithSameStartEnd(this string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return 0;

        string[] words = text.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        int count = 0;

        foreach (var word in words)
        {
            if (char.ToLower(word[0]) == char.ToLower(word[word.Length - 1]))
                count++;
        }

        return count;
    }
}
