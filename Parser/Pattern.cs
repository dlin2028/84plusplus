using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokenizer;

namespace Parser
{
    class Pattern
    {
        public Func<Stack<Token>, SyntaxNode> Constructor;
        public List<Token[]> Arguments; //change Stack<Token> to int[] later please

        public Pattern(Func<Stack<Token>, SyntaxNode> constructor, List<int[]> arguments)
        {
            Constructor = constructor;
            Arguments = new List<Token[]>();
            Arguments.AddRange(arguments.Select(x => x.Select(y => new Token((TokenType)y, "")).ToArray()).ToArray()); //this is pretty bad
        }
    }
}