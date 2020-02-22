using System;
using System.Collections.Generic;
using System.Linq;

namespace cslaba_3
{
    public class Variable : Expr
    {
        public string var { get; }
        public override IEnumerable<string> Variables => new List<string> { var };
        public Variable(string Var) => var = Var;
        public override bool IsConstant { get => false; }
        public override bool IsPolynom { get => true; }
        public override double Compute(IReadOnlyDictionary<string, double> variableValues) => variableValues[var];
        public override Expr Diff(Variable a) => var == a.var ? new Constant(1) : new Constant(0);
        public override string ToString() => var;
    }
}