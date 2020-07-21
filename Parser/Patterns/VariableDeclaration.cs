using System;
using System.Collections.Generic;
using System.Text;
using Tokenizer;

namespace Parser
{
    class VariableDeclaration : SyntaxNode
    {
        public Token TypeToken;
        public SyntaxNode Declarator;

        public static void IsMatch(ReadOnlySpan<Token> tokens, ref int count)
        {
            int oldCount = count;

            var declaration = new VariableDeclaration();
            if (tokens[count].SpecificTokenType >= SpecificTokenType.Number && tokens[count].SpecificTokenType <= SpecificTokenType.Matrix)
            {
                declaration.TypeToken = tokens[count++];
                if (tokens[count].SpecificTokenType == SpecificTokenType.Equals)
                {
                    var declarator = new VariableDeclarator();
                    count++;
                    declarator.Expression = new Expression(tokens, ref count);
                    declaration.Declarator = declarator;
                }
                else
                {
                    declaration.Declarator = new InvalidTokenNode(tokens[count++]);
                }
                return declaration;
            }
        }
    }
    class VariableDeclarator : SyntaxNode
    {
        public Token IdentifierToken;
        public SyntaxNode Expression;
    }
}
