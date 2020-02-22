using System;
using System.Collections.Generic;
using System.Linq;

namespace cslaba_3
{
    public class Sub : BinaryOperation
    {
        public override Expr Operand1 { get; }
        public override Expr Operand2 { get; }
        public Sub(Expr Operand1, Expr Operand2)
        {
            this.Operand1 = Operand1;
            this.Operand2 = Operand2;
        }
        public override double Compute(IReadOnlyDictionary<string, double> variableValues) => Operand1.Compute(variableValues) - Operand2.Compute(variableValues);
        public override bool IsPolynom { get => Operand1.IsPolynom && Operand2.IsPolynom; }
        public override Expr Diff(Variable a) => Operand1.Diff(a) - Operand2.Diff(a);
        public override string ToString() => Operand2 is Sum || Operand2
            is Sub || Operand2 is Minus ? $"{Operand1.ToString()} - ({Operand2.ToString()})" : $"{Operand1.ToString()} - {Operand2.ToString()}";
    }
}