using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyCppCompiler
{
    abstract class AbstractLexer
    {
        protected string Input;
        protected int StringBegin;
        protected int StringEnd;
        protected LexerState State;
        protected TokenType AcceptType;
        protected string ER = "Error";
        public List<Token> TokensList = new List<Token>();
        public void initialize(string InputFromInitialization)
        {
            Input = InputFromInitialization;
            StringBegin = StringEnd = 0;
            State = LexerState.Ready;
        }
        public Token NextToken()
        {
            State = LexerState.Ready;
            char c;
            while (StringEnd != Input.Length)
            {
                c = read();
                switchState(c);
                if (State == LexerState.Accepted)
                {
                    Token T = Accept(AcceptType);
                    if (T.Type != TokenType.Token_SKIP)
                        return T;
                }
            }

            if (State == LexerState.Ready)
            {
                Token T = new Token();
                T.Lexeme = "";
                return T;
            }
            else
                throw new LexerException("End of file reached");
        }
        protected abstract LexerState switchState(char c);
        protected void Retract()
        {
            --StringEnd;
        }
        protected void Reset()
        {
            StringEnd = StringBegin;
        }
        protected char read()
        {
            char c = Input[StringEnd];
            StringEnd++;
            return c;
        }
        protected Token Accept(TokenType Type)
        {
            string Lexeme = Input.Substring(StringBegin, StringEnd - StringBegin);
            StringBegin = StringEnd;
            Token Temp = new Token();
            Temp.Lexeme = Lexeme;
            Temp.Type = Type;
            State = LexerState.Ready;
            if (Temp.Lexeme == "if" || Temp.Lexeme == "while" || Temp.Lexeme == "\r\nif" || Temp.Lexeme == "\r\nwhile")
                Temp.Type = TokenType.Token_RESERVEDWORD;
            TokensList.Add(Temp);
            return Temp;
        }
        protected void Error(string Message)
        {
            throw new LexerException(Message);
        }
    }
}
