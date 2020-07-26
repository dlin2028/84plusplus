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

        public static int IsMatch(ReadOnlySpan<Token> tokens)
        {
            var declaration = new VariableDeclaration();
            if (tokens[count].SpecificTokenType >= SpecificTokenType.Number && tokens[count].SpecificTokenType <= SpecificTokenType.Matrix)
            {
                declaration.TypeToken = tokens[count++];
                if (tokens[count].SpecificTokenType == SpecificTokenType.Equals)
                {
                    var declarator = new VariableDeclarator();
                    count++;
                    declarator.Expression = new Expression(tokens);
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
