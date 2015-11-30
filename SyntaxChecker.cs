using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DummyCppCompiler
{
    class SyntaxChecker
    {

        List<Token> TokensList=new List<Token>();
         Token CurrentToken;
         Token NextToken;
            bool Error=false;

      public SyntaxChecker(List<Token> TokensList)
        {
            this.TokensList = TokensList;
            CurrentToken = new Token();
            NextToken = new Token();
        }

        public void Check()
    {
              for (int i = 0; i != TokensList.Count() - 1; i++)
                {
                    CurrentToken = TokensList[i];
                    NextToken = TokensList[i + 1];
                  
                    if (CurrentToken.Type == NextToken.Type)
                    {
                        if (CurrentToken.Lexeme != "{" && CurrentToken.Lexeme != "}" && CurrentToken.Lexeme != "(" && CurrentToken.Lexeme != ")")
                            Error = true;
                        break;

                    }

                    else if (CurrentToken.Type == TokenType.Token_INT_LITERAL && NextToken.Type == TokenType.Token_IDENTIFIER || CurrentToken.Type == TokenType.Token_INT_LITERAL && NextToken.Lexeme == "}" || CurrentToken.Type == TokenType.Token_INT_LITERAL && NextToken.Lexeme == "{")
                          {
                              Error = true;
                              break;
                          }
                      
                    else if (CurrentToken.Type == TokenType.Token_INT_LITERAL && NextToken.Lexeme == "=")
                    {
                        Error = true;
                        break;
                    }
                    else if (CurrentToken.Lexeme != ";" && NextToken.Type == TokenType.Token_RESERVEDWORD)
                    {
                        if (CurrentToken.Lexeme != "{" && CurrentToken.Lexeme != "}"

                            && CurrentToken.Lexeme != "(" && CurrentToken.Lexeme != ")")
                        {
                            Error = true;
                            break;
                        }
                    }
                     else if (CurrentToken.Lexeme != ";" && NextToken.Type == TokenType.Token_EOF)

                    {
                        if (CurrentToken.Lexeme == "}")
                            continue;
                        else
                       {
                            Error = true;
                            break;
                        }
                    }

            }
              if (Error)
              {
                  throw new ParseException("Syntax Error.");
              }
         
            }
                        
    }
        

    }

