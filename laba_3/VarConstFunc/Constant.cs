using System;
using System.Collections.Generic;
using System.Linq;

namespace cslaba_3
{
    public class Constant : Expr
    {
        public double constant { get; }
        public override IEnumerable<string> Variables => new List<string>();
        public Constant(double constant) => this.constant = constant;
        public override bool IsConstant { get => true; }
        public override bool IsPolynom { get => true; }
        public override double Compute(IReadOnlyDictionary<string, double> variableValues) => constant;
        public override Expr Diff(Variable a) => new Constant(0);
        public override string ToString() => constant.ToString();
    }
}