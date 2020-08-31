using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenizer;

namespace Parser
{
    static class Parser
    {

        static SyntaxNode ParseStatement(Stack<Token> tokens)
        {
            var currToken = tokens.Peek();
            if(currToken == SpecificTokenType.Function)
            {
                return new FunctionDeclaration(tokens);
            }
            else if(currToken == SpecificTokenType.Using)
            {
                return new UsingDirective(tokens);
            }
            else if(currToken == SpecificTokenType.If)
            {
                return new IfStatement(tokens);
            }
            else if(currToken == SpecificTokenType.While)
            {

            }
            else if(currToken == SpecificTokenType.Number)
            {

            }
            else if(currToken == SpecificTokenType.String)
            {

            }
            else if (currToken == SpecificTokenType.List)
            {

            }
            else if (currToken == SpecificTokenType.Matrix)
            {

            }
            else
            {
                //panik
            }
        }
    }
}
