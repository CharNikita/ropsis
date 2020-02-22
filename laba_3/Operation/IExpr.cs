using System;
using System.Collections.Generic;
using System.Linq;

namespace cslaba_3
{
    interface IExpr
    {
        double Compute(IReadOnlyDictionary<string, double> variableValues);
        IEnumerable<string> Variables { get; }
        bool IsConstant { get; }
        bool IsPolynom { get; }
    }
}