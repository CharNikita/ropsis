using System;
using System.Collections.Generic;
using System.Linq;

namespace cslaba_3
{
    public abstract class Expr : IExpr
    {
        public abstract double Compute(IReadOnlyDictionary<string, double> variableValues);
        public abstract IEnumerable<string> Variables { get; }
        public abstract bool IsConstant { get; }
        public abstract bool IsPolynom { get; }
        public abstract Expr Diff(Variable a); 
        public Constant Integ(Variable x, Expr beg, Expr end, int accuracy, IReadOnlyDictionary<string, double> variableValues)
        {
            var low = beg.Compute(variableValues);
            var up = end.Compute(variableValues);
            if (low > up)
            {
                var temp = low;
                low = up;
                up = temp;
            }
            double step = (up - low) / accuracy, sum = 0, buffer;
            var points = new Dictionary<string, double>(variableValues);
            points.Add(x.var, low);
            for (int i = 0; i < accuracy+1; i++)
            {
                buffer = Compute(points);
                points[x.var] += step;
                sum += ((buffer + Compute(points)) / 2) * step;
            }
            return new Constant(sum);
        }
        public static Expr operator -(Expr Op) => new Minus(Op);
        public static Expr operator +(Expr Op1, Expr Op2) => new Sum(Op1, Op2);
        public static Expr operator -(Expr Op1, Expr Op2) => new Sub(Op1, Op2);
        public static Expr operator *(Expr Op1, Expr Op2) => new Mult(Op1, Op2);
        public static Expr operator /(Expr Op1, Expr Op2) => new Div(Op1, Op2);
        public static implicit operator Expr(double arg) => new Constant(arg);
    }
}