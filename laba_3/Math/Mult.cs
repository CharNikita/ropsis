using System;
using System.Collections.Generic;
using System.Linq;

namespace cslaba_3
{
    public class Mult : BinaryOperation
    {
        public override Expr Operand1 { get; }
        public override Expr Operand2 { get; }
        public Mult(Expr Operand1, Expr Operand2)
        {
            this.Operand1 = Operand1;
            this.Operand2 = Operand2;
        }
        public override double Compute(IReadOnlyDictionary<string, double> variableValues) => Operand1.Compute(variableValues) * Operand2.Compute(variableValues);
        public override bool IsPolynom { get => Operand1.IsPolynom && Operand2.IsPolynom; }
        public override Expr Diff(Variable a) => Operand1.Diff(a) * Operand2 + Operand2.Diff(a) * Operand1;
        public override string ToString()
        {
            bool v = (Operand1 is Sum || Operand1 is Sub || Operand1 is Minus);
            bool v1 = (Operand2 is Sum || Operand2 is Sub || Operand2 is Minus);

            if (v && v1)
            return $"({Operand1.ToString()}) * ({Operand2.ToString()})";

            if (v)
            return $"({Operand1.ToString()}) * {Operand2.ToString()}";

            if (v1)
            return $"{Operand1.ToString()} * ({Operand2.ToString()})";

            return $"{Operand1.ToString()} * {Operand2.ToString()}";
        }
    }
}