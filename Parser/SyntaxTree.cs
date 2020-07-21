using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Tokenizer;

namespace Parser
{
    class SyntaxTree
    {
        public SyntaxNode Head;
        public SyntaxTree()
        {
            Head = null;
        }
        /*
        public float Eval()
            => Head.Eval();

        public void PrintPretty()
            => Head.PrintPretty("", true);*/
    }


    public abstract class SyntaxNode
    {
        public List<SyntaxNode> Children;
        public SyntaxNode()
        {
            Children = new List<SyntaxNode>();
        }
    }
    class TokenNode : SyntaxNode
    {
        Token Token;
        public TokenNode(Token token)
        {
            Token = token;
        }
    }


    class CompilationUnit : SyntaxNode
    {
    }
    class InvalidTokenNode : TokenNode
    {
        public InvalidTokenNode(Token token) : base(token)
        {
        }
    }
}
