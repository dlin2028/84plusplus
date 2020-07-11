using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Tokenizer
{
    class Tokenizer
    {
        Dictionary<SpecificTokenType, Func<string, SpecificTokenType>> specificTokenizer;
        Dictionary<TokenType, Regex> regexes;
        public Tokenizer(Dictionary<TokenType, Regex> regexes, Dictionary<SpecificTokenType, Func<string, SpecificTokenType>> specificTokenizer)
        {
            this.regexes = regexes;
            this.specificTokenizer = specificTokenizer;
        }
        public List<Token> Tokenize(ReadOnlySpan<char> input)
        {
            List<Token> output = new List<Token>();
            int currentPos = 0;
            var curr = input;

            while(currentPos < input.Length)
            {
                while (curr[0] == ' ')
                {
                    curr = input.Slice(++currentPos);
                }
                 
                var nIndex = curr.IndexOf('\n');
                if(nIndex != -1)
                {
                    curr = curr.Slice(0, Math.Min(nIndex, curr.IndexOf(';')) + 1);
                }
                else
                {
                    curr = curr.Slice(0);
                }

                for (int j = 0; j < regexes.Count; j++)
                {
                    var match = regexes[(TokenType)j].Match(curr.ToString());

                    if(match.Success && match.Index == 0)
                    {
                        if (output.Count == 36)
                        {
                            int x = 1;
                        }

                        output.Add(new Token((TokenType)j, match.Value));
                        currentPos += match.Value.Length - 1;
                        break;
                    }
                }
                curr = input.Slice(++currentPos);
            }

            return output;
        }
    }
}