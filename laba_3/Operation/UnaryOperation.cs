using System;
using System.Collections.Generic;
using System.Linq;

namespace cslaba_3
{
    public abstract class UnaryOperation : Expr
    {
        abstract public Expr Operand { get; }
        public override IEnumerable<string> Variables => Operand.Variables;
        public override bool IsConstant { get => Operand.IsConstant; }
        public override bool IsPolynom { get => Operand.IsPolynom; }
    }
}