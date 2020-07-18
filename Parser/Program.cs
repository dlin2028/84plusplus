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
            List<Token> tokens = tokenizer.Tokenize("a+b-c*d/e+f");

            Parser parser = new Parser();
            var hi = parser.Parse(tokens.ToArray().AsSpan());

            //Console.WriteLine(hi.Eval());

            //hi.PrintPretty();
        }

    }
}
