using Parser.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using Tokenizer;

namespace Parser
{
    class Parser
    {
        SyntaxTree tree;

        public Parser()
        {

        }
        int count = 0;
        public SyntaxTree Parse(ReadOnlySpan<Token> tokens)
        {
            tree = new SyntaxTree();

            SyntaxNode currentNode = tree.Head;
            currentNode = new CompilationUnit();
            
            //using must precede all other stuff

            while (count < tokens.Length) { 
            }


            return tree;
        }

        public TokenTrie GenerateTokenTrie(Pattern[] grammar)
        {
            //avert eyes
            return GenerateTokenTrie(grammar.Select(x => x.Constructor).ToArray(), grammar.Select(x => x.Arguments.Select(y => y.ToArray().Select(x => (int)x.TokenType).ToArray()).ToArray()).ToArray());
        }

        public TokenTrie GenerateTokenTrie(Func<List<Token>, SyntaxNode>[] nodeConstructors, int[][][] grammar)
        {
            TokenTrie output = new TokenTrie();

            Queue<TokenTrieNode> currentNodes = new Queue<TokenTrieNode>();
            currentNodes.Enqueue(output.Head);

            for (int i = 0; i < grammar.Length; i++)  //different statements
            {
                for (int j = 0; j < grammar[i].Length; j++) //order of arguments
                {
                    for (int k = 0; k < grammar[j][k].Length; k++) //differnt arguments
                    {
                        Queue<TokenTrieNode> nextNodes = new Queue<TokenTrieNode>();
                        foreach (var item in currentNodes)
                        {
                            var token = grammar[i][j][k];
                            var newNode = new TokenTrieNode(token);
                            item.Children.Add(token, newNode);
                            nextNodes.Enqueue(newNode);
                        }
                        currentNodes = nextNodes;
                    }
                    foreach (var item in currentNodes)
                    {
                        item.Children.Add(0, new TokenTrieNode(nodeConstructors[i]));
                    }
                }
            }
            return output;
        }
    }

}
