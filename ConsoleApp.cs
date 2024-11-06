using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class ConsoleApp
{
    public static void PrintLn(object message, ConsoleColor textColor = ConsoleColor.White)
    {
        Console.ForegroundColor = textColor;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void PrintStp(object message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
        Environment.Exit(-1);
    }

    public static void Print(object message, ConsoleColor textColor = ConsoleColor.White)
    {
        Console.ForegroundColor = textColor;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static string? ReadLn()
    {
        return Console.ReadLine();
    }

    public static int Read()
    {
        return Console.Read();
    }

    public static void Pause()
    {
        Console.ReadLine();
    }

    public static ConsoleKeyInfo GetKey()
    {
        return Console.ReadKey();
    }
}
