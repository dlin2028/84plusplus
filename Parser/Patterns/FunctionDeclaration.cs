using Parser.Patterns;
using System;
using System.Collections.Generic;
using System.Text;
using Tokenizer;

namespace Parser
{
    class FunctionDeclaration : SyntaxNode
    {
        public ParameterList ParameterList;
        public ReturnType ReturnType;
        public Body Body;

        public FunctionDeclaration()
        {

        }
    }
    class ParameterList : SyntaxNode
    {
        public List<Parameter> Parameters;
    }
    class Parameter : SyntaxNode
    {
        public Token Type;
        public Token Identifier;
    }
    class ReturnType : SyntaxNode
    {
        public Token Keyword;
    }
}
