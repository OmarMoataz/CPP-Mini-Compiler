using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyCppCompiler
{
    public enum LexerState
    { Accepted, Fail, Ready, RestOfToken}
    public enum TokenType
    {
        Token_INT_LITERAL, Token_IDENTIFIER, Token_LPAREN, Token_RPAREN, Token_LBRACE,
        Token_RBRACE, Token_OPERATOR,Token_SEMICOLON,
        Token_BINDING, Token_EQUALITY_OPERATOR,Token_SKIP, Token_LBRACKETS, Token_RBRACKETS,
        Token_LESS_THAN, Token_GREATER_THAN,Token_Space,Token_RESERVEDWORD,Token_COMPARE,Token_NEWLINE,Token_EOF
    }
    public class Token
    {
        public TokenType Type;
        public string Lexeme;
        public Token()
        {
            Lexeme = "";
        }
        public Token(TokenType _Type, string _Lexeme)
        {
            Type = _Type;
            Lexeme = _Lexeme;
        }
        public bool Is(string _Lexeme)
        {
            return Lexeme == _Lexeme;
        }
        public bool Is(TokenType _Type)
        {
            return Type == _Type;
        }
    }
    public class LexerException : SystemException
    {
        public string message;
        public LexerException(string s)
        {
            message = s;
        }
    }
    class LexicalAnalyzer : AbstractLexer
    {
        public LexicalAnalyzer()
        {

        }
        public void appendEOF()
        {
            Token temp = new Token(TokenType.Token_EOF, "");
            TokensList.Add(temp);
        }
        
        
        public bool IsFinished()
        {
            return (StringEnd >= Input.Length);
        }
        

        public LexicalAnalyzer(string InputFromTextBox)
        {
            initialize(InputFromTextBox);
        }

        LexerState DoStateReady(char c)
        {
            {
                if (char.IsDigit(c))
                {
                        AcceptType = TokenType.Token_INT_LITERAL;
                        State = LexerState.RestOfToken;
                }
                else if (char.IsLetter(c))
                {
                        AcceptType = TokenType.Token_IDENTIFIER;
                        State = LexerState.RestOfToken;
                }
                else if (c == '=')
                {
                    
                    AcceptType = TokenType.Token_EQUALITY_OPERATOR;
                    State = LexerState.Accepted;
                }
                else if (c == '(')
                {
                    State = LexerState.Accepted;
                    AcceptType = TokenType.Token_LPAREN;
                }
                else if (c == ')')
                {
                    State = LexerState.Accepted;
                    AcceptType = TokenType.Token_RPAREN;
                }
                else if (c == '{')
                {
                    State = LexerState.Accepted;
                    AcceptType = TokenType.Token_LBRACE;
                }
                else if (c == '}')
                {
                    State = LexerState.Accepted;
                    AcceptType = TokenType.Token_RBRACE;
                }
                else if (c == '+' || c == '-' || c == '*' || c == '/' || c == '&' || c == '|')
                {
                    State = LexerState.Accepted;
                    AcceptType = TokenType.Token_OPERATOR;
                }

                else if (c == '<')
                {
                    State = LexerState.Accepted;
                    AcceptType = TokenType.Token_LESS_THAN;
                }
                else if (c == '>')
                {
                    State = LexerState.Accepted;
                    AcceptType = TokenType.Token_GREATER_THAN;
                }
                else if (c == ']')
                {
                    State = LexerState.Accepted;
                    AcceptType = TokenType.Token_RBRACKETS;
                }
                else if (c == ']')
                {
                    State = LexerState.Accepted;
                    AcceptType = TokenType.Token_LBRACKETS;
                }
                else if (c == ';')
                {
                    State = LexerState.Accepted;
                    AcceptType = TokenType.Token_SEMICOLON;
                }
                else if(c == '?')
                {
                    State = LexerState.Accepted;
                    AcceptType = TokenType.Token_COMPARE;
                }
                
                return State;
            }
        }
        LexerState DoState1(char c)
        {
            if (!char.IsLetterOrDigit(c) || c== '\r' || c=='\n')
            {
                Retract();
                State = LexerState.Accepted;
                AcceptType = TokenType.Token_IDENTIFIER;
            }
            
            AcceptType = TokenType.Token_IDENTIFIER;
            return State;
        }
        LexerState DoState2(char c)
        {
            if (!char.IsDigit(c))
            {
                Retract();
                State = LexerState.Accepted;
            }
            AcceptType = TokenType.Token_INT_LITERAL;
            return State;
        }

        LexerState DoStateFail(char c, int state, ref int acceptType)
        {
            Error("lexer error: incorrect state.");
            return LexerState.Fail;
        }
        protected override LexerState switchState(char c)
        {
            if (State == LexerState.Ready)
                return DoStateReady(c);
            else if (AcceptType == TokenType.Token_IDENTIFIER)
                return DoState1(c);
            else if (AcceptType == TokenType.Token_INT_LITERAL)
                return DoState2(c);
            else
            {
                Error(ER);
                return LexerState.Fail; //dummy return
            }
        }
        public void RemoveEnterCharacter()
        {
            for (int i = 0; i < TokensList.Count; i++)
            {
                string Temp = TokensList[i].Lexeme;
                if (Temp.Length >=4 && Temp.Substring(0, 2) == "\r\n")
                {
                    Temp.Replace("\r\n", string.Empty);
                    TokensList[i].Lexeme = Temp;
                }
            }
        }
    }

}
