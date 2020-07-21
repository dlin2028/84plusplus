using System;
using System.Collections.Generic;
using System.Text;
using Tokenizer;

namespace Parser.Patterns
{
    class UsingDirective : SyntaxNode, IPattern
    {
        public static bool TryMatch(ReadOnlySpan<Token> tokens, ref int count, out SyntaxNode result)
        {
            int oldCount = count;

            result = new UsingDirective();
            if (tokens[count].SpecificTokenType == SpecificTokenType.Using)
            {
                bool containsIdentifier = false;
                while (tokens[count].SpecificTokenType != SpecificTokenType.SemiColon)
                {
                    if (tokens[count].TokenType == TokenType.Identifier)
                        containsIdentifier = true;
                    else if (tokens[count].TokenType != TokenType.Comment)
                    {
                        count = oldCount;
                        return false;
                    }

                    result.Children.Add(new TokenNode(tokens[count++]));
                }
                result.Children.Add(new TokenNode(tokens[count++]));
                return containsIdentifier;
            }
            count = oldCount;
            return false;
        }
    }
}
