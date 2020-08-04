using System;
using System.Collections.Generic;
using System.Text;
using Tokenizer;

namespace Parser.Patterns
{
    class UsingDirective : SyntaxNode
    {

        public UsingDirective(Stack<Token> tokens)
        {
            int count = 1;
            while (tokens.Peek().SpecificTokenType != SpecificTokenType.SemiColon)
            {
                Children.Add(new TokenNode(tokens.Pop()));
            }
            Children.Add(new TokenNode(tokens.Peek()));
        }
    }
}
