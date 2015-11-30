using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DummyCppCompiler
{
    class DummyCppParser : AbstractParser
    {

        public List<string> ParserFinalOutput = new List<string>();

        public string ParserOutput = "";
        public string ERROR = "";
        
        public DummyCppParser(LexicalAnalyzer Lexer)
            : base(Lexer)
        {
            Lexer.appendEOF();
            SyntaxChecker CheckError = new SyntaxChecker(Lexer.TokensList);
            try
            {
                CheckError.Check();
            }
            catch (ParseException ex)
            {
                 ERROR = ex.Msg;
           
            }
        }

        public void Parse()
        {
            if(MoreTokens())
            Lookahead = NextToken();

            Expression Pointer = Expression();
        }

        private Expression Expression()
        {

            Expression FirstPointer = ComparisonExpression();


            while (Lookahead.Is("&") || Lookahead.Is("|") || Lookahead.Is("="))
            {

                string Operator = Lookahead.Lexeme;
                Match(Lookahead.Lexeme);
                Expression SecondPointer = ComparisonExpression();
                FirstPointer = new BinaryOperator(Operator, FirstPointer, SecondPointer);
            }

            

            if (Lookahead.Is(";"))
            {
                Lookahead = NextToken();
                //ParserOutput = FirstPointer.IntoString();
                //ParserFinalOutput.Add(ParserOutput);

                if (MoreTokens())
                {
                    if (Lookahead.Type == TokenType.Token_IDENTIFIER || Lookahead.Type == TokenType.Token_RESERVEDWORD)// && Lookahead.Type!=TokenType.Token_EOF&& Lookahead.Lexeme!="}" &&  Lookahead.Lexeme!=")")
                        Expression();
                }
            }
     
            if (Lookahead.Type == TokenType.Token_EOF)
            {
                ParserOutput = FirstPointer.IntoString();
                ParserFinalOutput.Add(ParserOutput);
                return FirstPointer;
            }

            return FirstPointer;
        }

        private Expression ComparisonExpression()
        {
            Expression FirstPointer = ArithmeticExpression();

            while (Lookahead.Is(">") || Lookahead.Is("?") || Lookahead.Is("<"))
            {
                string Operator = Lookahead.Lexeme;
                Match(Lookahead.Lexeme);
                Expression SecondPointer = ArithmeticExpression();
                FirstPointer = new BinaryOperator(Operator, FirstPointer, SecondPointer);
            }
            return FirstPointer;
        }

        private Expression ArithmeticExpression()
        {
            Expression FirstPointer = Term();

            while (Lookahead.Is("+") || Lookahead.Is("-"))
            {
                string Operator = Lookahead.Lexeme;
                Match(Lookahead.Lexeme);
                Expression SecondPointer = Term();
                FirstPointer = new BinaryOperator(Operator, FirstPointer, SecondPointer);
            }
            return FirstPointer;
        }

        private Expression Term()
        {
            Expression FirstPointer = Factor();

            while (Lookahead.Is("*") || Lookahead.Is("/"))
            {
                string Operator = Lookahead.Lexeme;
                Match(Lookahead.Lexeme);
                Expression SecondPointer = Factor();
                FirstPointer = new BinaryOperator(Operator, FirstPointer, SecondPointer);
            }
            return FirstPointer;
        }

        private Expression Factor()
        {
            Expression FirstPointer = null;
            if (Lookahead.Is("("))
            {
                Match("(");
                FirstPointer = Expression();
                Match(")");
                return FirstPointer;
            }

            if (Lookahead.Is(TokenType.Token_INT_LITERAL))
            {
                int Value = int.Parse(Lookahead.Lexeme);
                Match(ExpressionsID.IntLiteral);
                FirstPointer = new IntLiteral(Value);
                return FirstPointer;
            }

            if (Lookahead.Is(TokenType.Token_IDENTIFIER))
            {
                FirstPointer = Identifier();
                return FirstPointer;
            }

            if (Lookahead.Is("if"))
            {
                Match("if");
                Match("(");
                Expression Condition = Expression();
                Match(")");
                Match("{");
                Expression Then = Expression();
                Match("}");
                if ( Lookahead.Lexeme!="else")
                {
                    FirstPointer = new If(Condition, Then);
                    return FirstPointer;
                }
                Match("else");
                Match("{");
                Expression Else = Expression();
                Match("}");
                FirstPointer = new If(Condition, Then, Else);
                return FirstPointer;
            }

            if (Lookahead.Is("while"))
            {
                Match("while");
                Match("(");
                Expression Condition = Expression();
                Match(")");
                Match("{");
                Expression Body = new Expression();
                while (!Lookahead.Is("}"))
                {
                    Body = Expression();
                }
                Match("}");
                FirstPointer = new While(Condition, Body);
                return FirstPointer;
            }
            if (Lookahead.Type == TokenType.Token_EOF)
            {
                return FirstPointer;
            }

            return FirstPointer;
          
        }

        private Identifier Identifier()
        {
            string Name = Lookahead.Lexeme;
            Match(TokenType.Token_IDENTIFIER);
            Identifier pointer = new Identifier(Name);
            return pointer;
        }

    }
}
