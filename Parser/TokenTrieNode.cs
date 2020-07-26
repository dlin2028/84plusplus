﻿using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;
using Tokenizer;

namespace Parser
{
    class TokenTrie
    {
        public TokenTrieNode Head;

        public TokenTrie()
        {
            Head = new TokenTrieNode(SpecificTokenType.None);
        }
    }

    class TokenTrieNode
    {
        int token = 0;

        public TokenType TokenType => (TokenType)token;
        public SpecificTokenType SpecificTokenType => (SpecificTokenType)token;

        public Func<List<Token>, SyntaxNode> Value;
        public Dictionary<int, TokenTrieNode> Children;

        public TokenTrieNode(Func<List<Token>, SyntaxNode> value)
        {
            Value = value;
        }
        public TokenTrieNode(int token)
        {
            this.token = token;
        }
        public TokenTrieNode(TokenType tokenType)
        {
            token = (int)tokenType;
        }
        public TokenTrieNode(SpecificTokenType specificTokenType)
        {
            token = (int)specificTokenType;
        }
        public bool IsMatch(SpecificTokenType specificTokenType)
        {
            return specificTokenType == SpecificTokenType;
        }
        public bool IsMatch(TokenType tokenType)
        {
            return tokenType == TokenType;
        }
    }
}
