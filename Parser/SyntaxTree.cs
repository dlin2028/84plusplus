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
    [DebuggerDisplay("{Token.Lexeme}")]
    class SyntaxNode
    {
        public List<SyntaxNode> Children;
        public List<Token> Tokens;

        public SyntaxNode()
        {
            Tokens = new List<Token>();
            Children = new List<SyntaxNode>();
        }
        public SyntaxNode(Token token)
        {
            Tokens = new List<Token>();
            Tokens.Add(token);
            Children = new List<SyntaxNode>();
        }
        /*
        public void PrintPretty(string indent, bool last)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("\\=");
                indent += "  ";
            }
            else
            {
                Console.Write("|=");
                indent += "| ";
            }
            Console.WriteLine(Tokens[0].Lexeme);

            for (int i = 0; i < Children.Count; i++)
                Children[i].PrintPretty(indent, i == Children.Count - 1);
        }

        public float Eval()
        {
            var Token = Tokens[0];
            if (Token.TokenType == TokenType.Constant)
            {
                return float.Parse(Token.Lexeme);
            }
            else
            {
                float total;
                if (Token.SpecificTokenType == SpecificTokenType.Add)
                {
                    total = Children[0].Eval();
                    for (int i = 1; i < Children.Count; i++)
                    {
                        total += Children[i].Eval();
                    }
                }
                else if (Token.SpecificTokenType == SpecificTokenType.Minus)
                {
                    total = Children[0].Eval();
                    for (int i = 1; i < Children.Count; i++)
                    {
                        total -= Children[i].Eval();
                    }
                }
                else if (Token.SpecificTokenType == SpecificTokenType.Multiply)
                {
                    total = Children[0].Eval();
                    for (int i = 1; i < Children.Count; i++)
                    {
                        total *= Children[i].Eval();
                    }
                }
                else // if (Token.SpecificTokenType == SpecificTokenType.Divide)
                {
                    total = Children[0].Eval();
                    for (int i = 1; i < Children.Count; i++)
                    {
                        total /= Children[i].Eval();
                    }
                }
                return total;
            }*/
    }

    class CompilationUnit : SyntaxNode
    {

    }
    class FunctionDeclaration : SyntaxNode
    {

    }
    class VariableDeclaration : SyntaxNode
    {

    }
    class ClassDeclaration : SyntaxNode
    {

    }

}
