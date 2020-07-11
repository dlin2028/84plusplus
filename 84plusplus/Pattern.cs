using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Tokenizer
{
    class Pattern
    {
        private Regex regex;
        public Pattern(string regexPattern)
        {
            regex = new Regex(regexPattern);
        }

        public bool Match(string input)
        {
            return regex.IsMatch(input);
        }
    }
}
