using System;
using System.Collections.Generic;
using System.Linq;

namespace cslaba_3
{
    using static FunctionFabric;

    class Program
    {
        static void Main(string[] args)
        {
        var a = new Variable("a");
        var b = new Variable("b");
        var Up = new Variable("U");
        var Low = new Variable("L");
        int acc = 10000;

        var expr = (Sin(a) + Cos(b)) * (Tg((a + 3) / 4) + Ctg(4)) - Integral((a + b)
            * 2, a, Low, Up, acc, new Dictionary<string, double> { ["b"] = 3, ["U"] = 5, ["L"] = -1 });

            string value = $"Выражение (Sin(a) + Cos(b)) * (Tg((a + 3) / 4) + Ctg(4)) - Integral(((a + b) * 2)da) = {expr.Compute(new Dictionary<string, double> { ["a"] = 4, ["b"] = 3 }):0.00} при a = 4 и b = 3";
            Console.WriteLine(value);
        Console.ReadLine();
        }
    }
}