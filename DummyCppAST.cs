using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyCppCompiler
{
    class Expression
    {
        public virtual int GetExpressionType()
        {
            return 0;
        }
        public virtual string IntoString()
        {
            return "";
        }
    }


    class BinaryOperator : Expression
    {
        private string Operator;
        private Expression LeftOperand;
        private Expression RightOperand;

        public BinaryOperator(string Operator, Expression LeftOperand, Expression RightOperand)
        {
            this.Operator = Operator;
            this.LeftOperand = LeftOperand;
            this.RightOperand = RightOperand;
        }

        public override int GetExpressionType()
        {
            return ExpressionsID.BinaryOperator;
        }

        public override string IntoString()
        {
            return "(" + this.Operator + " " + this.LeftOperand.IntoString() + " " + this.RightOperand.IntoString() + ")";
        }

    }

    class IntLiteral : Expression
    {
        private int Value;

        public IntLiteral(int Value)
        {
            this.Value = Value;
        }

        public override int GetExpressionType()
        {
            return 
                ExpressionsID.IntLiteral;
        }

        public override string IntoString()
        {
            return Value.ToString();
        }
    }

   
    class Identifier : Expression
    {
        private string Name;

        public Identifier(string Name)
        {
            this.Name = Name;
        }

        public override int GetExpressionType()
        {
            return ExpressionsID.Identifier;
        }

        public override string IntoString()
        {
            return Name;
        }
    }

    class If : Expression
    {
        private Expression Condition;
        private Expression Then;
        private Expression Else;

        public If(Expression Condition, Expression Then, Expression Else)
        {
            this.Condition = Condition;
            this.Then = Then;
            this.Else = Else;
        }
        public If(Expression Condition, Expression Then)
        {
            this.Condition = Condition;
            this.Then = Then;
        }

        public override int GetExpressionType()
        {
            return ExpressionsID.IfExpression;
        }

        public override string IntoString()
        {
            if (Else != null)
                return "if" + Condition.IntoString() + ", then" + Then.IntoString() + ", else " + Else.IntoString();
            else
                return "if" + Condition.IntoString() + ", then" + Then.IntoString();
        }
    }

    class While : Expression
    {
        private Expression Condition;
        private Expression Body;

        public While(Expression Condition, Expression Body)
        {
            this.Condition = Condition;
            this.Body = Body;
        }

        public override int GetExpressionType()
        {
            return ExpressionsID.WhileExpression;
        }

        public override string IntoString()
        {
            return "while" + Condition.IntoString() + ", " + Body.IntoString();
        }
    }
}
