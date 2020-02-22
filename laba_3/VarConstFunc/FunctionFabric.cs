using System;
using System.Collections.Generic;
using System.Linq;

namespace cslaba_3
{
    public static class FunctionFabric
    {
        public static Expr Differ(Expr Funct, Variable a) => Funct.Diff(a);
        public static Constant Integral(Expr Funct,
                                        Variable x,
                                        Expr low,
                                        Expr up,
                                        int accuracy,
                                        IReadOnlyDictionary<string, double> variableValues) => Funct.Integ(x, low, up, accuracy, variableValues);
        public static Sin Sin(Expr Arg) => new Sin(Arg);
        public static Cos Cos(Expr Arg) => new Cos(Arg);
        public static Tg Tg(Expr Arg) => new Tg(Arg);
        public static Ctg Ctg(Expr Arg) => new Ctg(Arg);
    }
}