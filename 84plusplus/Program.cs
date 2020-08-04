using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Permissions;
using System.Text.RegularExpressions;

namespace Tokenizer
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadOnlySpan<char> input = File.ReadAllText(@"ExampleCode.txt").AsSpan();
            //ReadOnlySpan<char> input = "using blah;".AsSpan();

            Tokenizer tokenizer = new Tokenizer();//, specificTokenizer); trust me i know what im doing

            List<Token> tokens = tokenizer.Tokenize(input);

            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];

                Console.WriteLine($"{i}   {token.SpecificTokenType.ToString()} : {token.Lexeme}");
            }
        }
    }
}
