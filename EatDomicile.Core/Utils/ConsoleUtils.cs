using System.Runtime.CompilerServices;
using Microsoft.IdentityModel.Tokens;

namespace EatDomicile.Core.Utils;

public static class ConsoleUtils
{
    public static int ReadLineInt(string str)
    {
        Console.WriteLine(str);
        return int.Parse(Console.ReadLine()!);

    }

    public static string ReadLineString(string str)
    {

        Console.WriteLine(str);
        var returnValue = Console.ReadLine()!;
        if (returnValue.IsNullOrEmpty())
        {
            throw new Exception("La valeur ne doit pas être vide!");
        }
        return returnValue;
    }

}