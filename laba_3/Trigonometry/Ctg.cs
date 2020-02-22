using System;
using System.Collections.Generic;
using System.Linq;

namespace cslaba_3
{
    public class Ctg : Function
    {
        public Ctg(Expr argument) => Argument = argument;
        public override Expr Argument { get; }
        public override double Compute(IReadOnlyDictionary<string, double> variableValues)
        {
            var arg = Argument.Compute(variableValues);
            return 1 / Math.Tan(arg);
        }
        public override Expr Diff(Variable a) => -1 / (new Sin(Argument) * new Sin(Argument)) * Argument.Diff(a);
        public override string ToString() => "Ctg(" + Argument.ToString() + ")";
    }
}