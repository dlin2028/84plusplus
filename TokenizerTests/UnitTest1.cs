using System;
using System.Collections.Generic;
using Xunit;
using Tokenizer;
using System.Linq;

namespace TokenizerTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("number a = 5", new SpecificTokenType[] { SpecificTokenType.Number, SpecificTokenType.Identifier, SpecificTokenType.Equals, SpecificTokenType.NumberConstant })]
        [InlineData("string a = \"this is cool\"", new SpecificTokenType[] { SpecificTokenType.String, SpecificTokenType.Identifier, SpecificTokenType.Equals, SpecificTokenType.StringConstant })]
        public void InstantiationTests(string input, SpecificTokenType[] tokenArr)
        {
            Tokenizer.Tokenizer tokenizer = new Tokenizer.Tokenizer();
            var tokens = tokenizer.Tokenize(input.AsSpan());
            Assert.Equal(tokens.Select(x => x.SpecificTokenType).ToArray(), tokenArr);
        }

        [Theory]
        [InlineData("a -=- 5", new SpecificTokenType[] { SpecificTokenType.Identifier, SpecificTokenType.SubtractEquals, SpecificTokenType.Minus, SpecificTokenType.NumberConstant })]
        public void MutationTests(string input, SpecificTokenType[] tokenArr)
        {
            Tokenizer.Tokenizer tokenizer = new Tokenizer.Tokenizer();
            var tokens = tokenizer.Tokenize(input.AsSpan());
            Assert.Equal(tokens.Select(x => x.SpecificTokenType).ToArray(), tokenArr);
        }
    }
}
