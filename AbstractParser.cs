using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyCppCompiler
{

    abstract class AbstractParser
    {
        protected LexicalAnalyzer Lexer=new LexicalAnalyzer();
        protected Token Lookahead=new Token();
        int Index = 0;
        public AbstractParser(LexicalAnalyzer Lexer )
        {
            this.Lexer = Lexer;
        }

        public bool MoreTokens()
        {
            return Index + 1 <= Lexer.TokensList.Count();
        }

       public Token NextToken()
       {
           if(MoreTokens())
           return Lexer.TokensList[Index++];
           return null;
       }

        protected bool Match(string Lexeme)
        {
            if (Lookahead.Lexeme == Lexeme)
            {
                if (MoreTokens())
                {
                    Lookahead = NextToken();
                    
                }
                else
                {
                    Lookahead = new Token();
                    Lookahead.Type =TokenType.Token_EOF;
                }
                return true;
            }
            else
            {
                throw new ParseException("Expected " + " " + Lexeme);
                return false;
            }
        }

        protected bool Match(TokenType TokenType)
        {
                if (Lookahead.Type == TokenType)
                {
                    if (MoreTokens())
                    Lookahead = NextToken();
                    return true;
                }
            else
            {
                throw new ParseException("Expected " + " " + TokenType.ToString());
                return false;
            }
        }
    }

    class ParseException : SystemException
    {
        public string Msg;

        public ParseException(string Message)
        {
            Msg = Message;
        }
    }

}