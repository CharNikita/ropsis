using System;
using System.Collections.Generic;
using System.Linq;

namespace cslaba_3
{
    public class Sin : Function
    {
        public Sin(Expr argument) => Argument = argument;
        public override Expr Argument { get; }
        public override double Compute(IReadOnlyDictionary<string, double> variableValues)
        {
            var arg = Argument.Compute(variableValues);
            return Math.Sin(arg);
        }
        public override Expr Diff(Variable a) => new Cos(Argument) * Argument.Diff(a);
        public override string ToString() => "Sin(" + Argument.ToString() + ")";
    }
}