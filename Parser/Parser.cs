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

            }
            else if(currToken == SpecificTokenType.Using)
            {

            }
            else if(currToken == SpecificTokenType.Static)
            {

            }
            else if(currToken == SpecificTokenType.If)
            {

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
        }
    }
}
