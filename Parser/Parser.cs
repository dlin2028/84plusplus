using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Tokenizer;

namespace Parser
{
    class Parser
    {
        SyntaxTree tree;

        public Parser()
        {

        }

        int count = 0;
        public SyntaxTree Parse(ReadOnlySpan<Token> tokens)
        {
            tree = new SyntaxTree();
            tree.Head = new SyntaxNode();

            SyntaxNode currentNode = tree.Head;
            while(count < tokens.Length)
            {
                while(tokens[count].SpecificTokenType >= SpecificTokenType.Number && tokens[count].SpecificTokenType <= SpecificTokenType.Matrix)
                {
                    currentNode.Children.Add(new SyntaxNode());
                }
            }


            return tree;
        }



        private SyntaxNode expr(ReadOnlySpan<Token> tokens, int precedence = 0)
        {
            if (precedence == (int)SpecificTokenType.RightParenthesis)
            {
                return new SyntaxNode(tokens[count++]);
            }
            else if (tokens[count].SpecificTokenType == SpecificTokenType.LeftParenthesis)
            {
                count++;
                return expr(tokens);
            }

            var result = expr(tokens, precedence + 1);
            while (count < tokens.Length - 1 && tokens[count].SpecificTokenType == (SpecificTokenType)precedence)
            {
                SyntaxNode parent = new SyntaxNode(tokens[count++]);
                parent.Children.Add(result);
                parent.Children.Add(expr(tokens, precedence + 1));
                result = parent;
            }
            return result;
        }
    }

}
