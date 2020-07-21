using Parser.Patterns;
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

            SyntaxNode currentNode = tree.Head;
            currentNode = new CompilationUnit();
            
            //using must precede all other stuff

            while (count < tokens.Length) { 
            }


            return tree;
        }
    }

}
