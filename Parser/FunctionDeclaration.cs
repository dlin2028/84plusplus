using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenizer;

namespace Parser
{
    class FunctionDeclaration
    {
        public Token ReturnTypeToken;
        public Token IdentifierToken;
        public SyntaxNode ParameterList;
        public SyntaxNode Body;
        public FunctionDeclaration(Stack<Token> tokens)
        {
            ReturnTypeToken = tokens.Pop();
            IdentifierToken = tokens.Pop();
            ParameterList = new ParameterList(tokens);
        }
    }
    class ParameterList : SyntaxNode
    {
        public Token OpenParenToken { get { return Token; } set { Token = value; } }
        public List<Parameter> Parameters;
        public Token CloseParenToken;
        public ParameterList(Stack<Token> tokens)
        {
            Parameters = new List<Parameter>();
            OpenParenToken = tokens.Pop();
            Token currToken = tokens.Pop();
            do
            {
                Parameters.Add(new Parameter(tokens));
            } while ((currToken = tokens.Pop()) != SpecificTokenType.RightParenthesis);
            CloseParenToken = tokens.Pop();
        }
    }
    class Parameter : SyntaxNode
    {
        public Parameter(Stack<Token> tokens)
        {
            Children.Add(new SyntaxNode(tokens.Pop()));
            Children.Add(new SyntaxNode(tokens.Pop()));
        }
    }
}
