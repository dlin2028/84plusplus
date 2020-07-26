using System;
using System.Collections.Generic;
using System.Text;
using Tokenizer;

namespace Parser
{
    class Expression : SyntaxNode
    {
        public Token Token;
        public Value Value;

        public Expression(Token token)
        {
            Token = token;
        }
        public Expression(ReadOnlySpan<Token> tokens)
        {
            Value = (Value)expr(tokens);
        }

        private int count = 0;
        protected Expression expr(ReadOnlySpan<Token> tokens, int precedence = 0)
        {
            if (precedence == (int)SpecificTokenType.RightParenthesis)
            {
                return new NumericLiteralExpression(tokens[count++]);
            }
            else if (tokens[count].SpecificTokenType == SpecificTokenType.LeftParenthesis)
            {
                count++;
                return expr(tokens);
            }

            var result = expr(tokens, precedence + 1);
            while (count < tokens.Length - 1 && tokens[count].SpecificTokenType == (SpecificTokenType)precedence)
            {
                OperatorExpression parent = new OperatorExpression(tokens[count++]);
                parent.Left = result;
                parent.Right = expr(tokens, precedence + 1);
                result = parent;
            }
            return result;
        }
    }
    class Value : Expression
    {
        public Expression Left { get { return (Expression)Children[0]; } set { Children[0] = value; } }
        public Expression Right { get { return (Expression)Children[1]; } set { Children[1] = value; } }
        public Value(Token token) : base(token)
        {
        }
    }
    class NumericLiteralExpression : Expression
    {
        public NumericLiteralExpression(Token token) : base(token)
        {
        }
    }
    class OperatorExpression : Expression
    {
        public Expression Left { get { return (Expression)Children[0]; } set { Children[0] = value; } }
        public Expression Right { get { return (Expression)Children[1]; } set { Children[1] = value; } }

        public OperatorExpression(Token token) : base(token)
        {
            Children = new List<SyntaxNode>(new SyntaxNode[] { null, null });
        }
    }
}
