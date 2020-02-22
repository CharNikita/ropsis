using System;
using System.Collections.Generic;
using System.Linq;

namespace cslaba_3
{
    public class Cos : Function
    {
        public Cos(Expr argument) => Argument = argument;
        public override Expr Argument { get; }
        public override double Compute(IReadOnlyDictionary<string, double> variableValues)
        {
            var arg = Argument.Compute(variableValues);
            return Math.Cos(arg);
        }
        public override Expr Diff(Variable a) => new Minus(new Sin(Argument)) * Argument.Diff(a);
        public override string ToString() => "Cos(" + Argument.ToString() + ")";
    }
}