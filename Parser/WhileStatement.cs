using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenizer;

namespace Parser
{
    class WhileStatement : SyntaxNode
    {
        public Token WhileToken;
        public Token OpenParenToken;
        public ExpressionNode ExpressionNode;
        public Token CloseParenToken;
        public SyntaxNode Body;

        public WhileStatement(Stack<Token> tokens)
        {
            WhileToken = tokens.Pop();
            OpenParenToken = tokens.Pop();
            ExpressionNode = new ExpressionNode(tokens);
            CloseParenToken = tokens.Pop();
            Body = new BodyNode(tokens);
        }
    }
}
