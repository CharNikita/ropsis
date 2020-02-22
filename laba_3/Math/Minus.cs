using System;
using System.Collections.Generic;
using System.Linq;

namespace cslaba_3
{
    public class Minus : UnaryOperation
    {
        public Minus(Expr operand) => Operand = operand;
        public override Expr Operand { get; }
        public override double Compute(IReadOnlyDictionary<string, double> variableValues) => -Operand.Compute(variableValues);
        public override Expr Diff(Variable a) => -Operand.Diff(a);
        public override string ToString()
        {
            if (Operand is Constant || Operand is Variable || Operand is Function)
                return "-" + Operand.ToString();
            else
                return "-(" + Operand.ToString() + ")";
        }
    }
}