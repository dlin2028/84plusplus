using System;
using System.Collections.Generic;
using System.Text;
using Tokenizer;

namespace Parser
{
    class VariableDeclaration : SyntaxNode
    {
        public Token TypeToken;
        public VariableDeclarator Declarator;

        public VariableDeclaration(Stack<Token> tokens)
        {
            int count = 0;
            TypeToken = tokens.Pop();
            count++; //the equals
            Declarator.Expression = new Expression(tokens);
        }
    }
    class VariableDeclarator : SyntaxNode
    {
        public Token IdentifierToken;
        public SyntaxNode Expression;
    }
}
