using Parser.Patterns;
using System;
using System.Collections.Generic;
using Tokenizer;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {



            Tokenizer.Tokenizer tokenizer = new Tokenizer.Tokenizer();
            List<Token> tokens = tokenizer.Tokenize("using blah;".AsSpan());

            Parser parser = new Parser();

            List<Pattern> patterns = new List<Pattern>();
            var arguments = new List<int[]>();

            //number hi = expr;
            patterns.Add(new Pattern((t) => { return new VariableDeclaration(t); }, arguments));
            arguments.Add(new int[]{ (int)SpecificTokenType.Number, (int)SpecificTokenType.String, (int)SpecificTokenType.List, (int)SpecificTokenType.Matrix });
            arguments.Add(new int[] { (int)TokenType.Identifier });
            arguments.Add(new int[] { (int)SpecificTokenType.Equals });
            arguments.Add(new int[] { (int)TokenType.Expression });
            arguments.Add(new int[] { (int)SpecificTokenType.SemiColon });
            arguments.Clear();

            //number hello()
            patterns.Add(new Pattern((t) => { return new FunctionDeclaration(t); }, arguments));
            arguments.Add(new int[] { (int)SpecificTokenType.Function});
            arguments.Add(new int[] { (int)SpecificTokenType.Number, (int)SpecificTokenType.String, (int)SpecificTokenType.List, (int)SpecificTokenType.Matrix });
            arguments.Add(new int[] { (int)TokenType.Identifier });
            arguments.Add(new int[] { (int)SpecificTokenType.LeftParenthesis });
            arguments.Add(new int[] { (int)TokenType.Expression });
            arguments.Add(new int[] { (int)SpecificTokenType.RightParenthesis });
            arguments.Clear();

            arguments.Add(new int[] { (int)SpecificTokenType.If}); //wow very epic
            arguments.Add(new int[] { (int)SpecificTokenType.LeftParenthesis });
            arguments.Add(new int[] { (int)TokenType.Expression });
            arguments.Add(new int[] { (int)SpecificTokenType.RightParenthesis });
            patterns.Add(new Pattern((t) => { return new VariableDeclaration(t); }, arguments));  //need to do :D
            arguments.Clear();


            arguments.Add(new int[] { (int)SpecificTokenType.Using }); //wow very epic
            arguments.Add(new int[] { (int)TokenType.Identifier });
            arguments.Add(new int[] { (int)SpecificTokenType.SemiColon });
            patterns.Add(new Pattern((t) => { return new UsingDirective(t); }, arguments));
            arguments.Clear();

            var magicalParsedTree = parser.Parse(new Stack<Token>(tokens), patterns.ToArray());


        }

    }
}
