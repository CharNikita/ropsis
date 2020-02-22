using System;
using System.Collections.Generic;
using System.Linq;

namespace cslaba_3
{
    public abstract class Function : Expr
    {
        abstract public Expr Argument { get; }
        public override IEnumerable<string> Variables => Argument.Variables;
        public override bool IsConstant { get => Argument.IsConstant ? true : false; }
        public override bool IsPolynom { get => false; }
    }
}