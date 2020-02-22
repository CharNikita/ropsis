using System;
using System.Collections.Generic;
using System.Linq;

namespace cslaba_3
{
    public class Tg : Function
    {
        public Tg(Expr argument) => Argument = argument;
        public override Expr Argument { get; }
        public override double Compute(IReadOnlyDictionary<string, double> variableValues)
        {
            var arg = Argument.Compute(variableValues);
            return Math.Tan(arg);
        }
        public override Expr Diff(Variable a) => 1 / (new Cos(Argument)* new Cos(Argument)) * Argument.Diff(a);
        public override string ToString() => "Tg(" + Argument.ToString() + ")";
    }
}