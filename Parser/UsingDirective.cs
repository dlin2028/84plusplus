using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenizer;

namespace Parser
{
    class UsingDirective : SyntaxNode
    {
        public Token UsingToken;
        public Token IdentifierToken;
        public Token SemicolonToken;
        public UsingDirective(Stack<Token> tokens)
        {
            UsingToken = tokens.Pop();
            IdentifierToken = tokens.Pop();
            SemicolonToken = tokens.Pop();
        }
    }
}
