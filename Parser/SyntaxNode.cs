using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenizer;

namespace Parser
{
    public class SyntaxNode
    {
        public Token Token;
        public List<SyntaxNode> Children;

        public SyntaxNode(Token token)
        {
            Token = token;
            Children = new List<SyntaxNode>();
        }
        public SyntaxNode()
        {
            Children = new List<SyntaxNode>();
        }
    }
}
