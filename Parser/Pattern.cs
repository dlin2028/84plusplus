using System;
using System.Collections.Generic;
using System.Text;
using Tokenizer;

namespace Parser
{
    class Pattern
    {
        public Func<List<Token>, SyntaxNode> Constructor;
        public List<List<Token>> Arguments;

        public Pattern(Func<List<Token>, SyntaxNode> constructor, List<List<Token>> arguments)
        {
            Constructor = constructor;
            Arguments = arguments;
        }
    }
}
