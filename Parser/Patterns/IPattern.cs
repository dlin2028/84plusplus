using System;
using System.Collections.Generic;
using System.Text;
using Tokenizer;

namespace Parser.Patterns
{
    interface IPattern
    {
        public static SyntaxNode TryMatch(ReadOnlySpan<Token> tokens, ref int count) { return null;  }
    }
}
