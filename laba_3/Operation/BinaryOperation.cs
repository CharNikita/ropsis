using System;
using System.Collections.Generic;
using System.Linq;

namespace cslaba_3
{
    public abstract class BinaryOperation : Expr
    {
        abstract public Expr Operand1 { get; }
        abstract public Expr Operand2 { get; }
        public override IEnumerable<string> Variables => Operand1.Variables.Union(Operand2.Variables);
        public override bool IsConstant { get => Operand1.IsConstant && Operand2.IsConstant; }
    }
}
