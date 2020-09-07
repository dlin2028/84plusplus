using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tokenizer;

namespace Parser
{
    public class DeclarationStatement : SyntaxNode
    {
        public Token TypeToken;
        public Token IdentifierToken;
        public Token EqualsToken;
        public ExpressionNode Expression;
        public DeclarationStatement(Stack<Token> tokens)
        {
            TypeToken = tokens.Pop();
            IdentifierToken = tokens.Pop();
            EqualsToken = tokens.Pop();
            Expression = new ExpressionNode(tokens);
        }
    }
    public class NumberDeclarationStatement : DeclarationStatement
    {
        public NumberDeclarationStatement(Stack<Token> tokens) : base(tokens)
        {
        }
    }
    public class StringDeclarationStatement : DeclarationStatement
    {
        public StringDeclarationStatement(Stack<Token> tokens) : base(tokens)
        {
        }
    }
    public class ListDeclarationStatement : DeclarationStatement
    {
        public ListDeclarationStatement(Stack<Token> tokens) : base(tokens)
        {
        }
    }
    public class MatrixDeclarationStatement : DeclarationStatement
    {
        public MatrixDeclarationStatement(Stack<Token> tokens) : base(tokens)
        {
        }
    }
}
