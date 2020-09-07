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
                return new WhileStatement(tokens);
            }
            else if(currToken == SpecificTokenType.Number)
            {
                return new NumberDeclarationStatement(tokens);
            }
            else if(currToken == SpecificTokenType.String)
            {
                return new StringDeclarationStatement(tokens);
            }
            else if (currToken == SpecificTokenType.List)
            {
                return new ListDeclarationStatement(tokens);
            }
            else if (currToken == SpecificTokenType.Matrix)
            {
                return new MatrixDeclarationStatement(tokens);
            }
            else
            {
                //panik
            }
        }
    }
}
