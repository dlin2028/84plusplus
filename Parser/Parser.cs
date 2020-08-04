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
        public SyntaxTree Parse(Stack<Token> tokens, Pattern[] grammar)
        {
            tree = new SyntaxTree();
            tree.Head = new CompilationUnit();

            TokenTrie tokenTrie = GenerateTokenTrie(grammar);

            //using must precede all other stuff
            var syntaxNode = tree.Head;
            var tokenNode = tokenTrie.Head;
            while (count < tokens.Count) {
                tokenNode = tokenNode.Children[(int)tokens.Pop().TokenType];
                if(tokenNode.Value != null)
                {
                    syntaxNode.Children.Add(tokenNode.Value(tokens));
                }
            }


            return tree;
        }

        public TokenTrie GenerateTokenTrie(Pattern[] grammar)
        {
            //avert eyes
            return GenerateTokenTrie(grammar.Select(x => x.Constructor).ToArray(), grammar.Select(x => x.Arguments.Select(y => y.ToArray().Select(z => (int)z.TokenType).ToArray()).ToArray()).ToArray());
        }

        public TokenTrie GenerateTokenTrie(Func<Stack<Token>, SyntaxNode>[] nodeConstructors, int[][][] grammar)
        {
            TokenTrie output = new TokenTrie();

            for (int i = 0; i < grammar.Length; i++)  //different statements
            {
                Queue<TokenTrieNode> currentNodes = new Queue<TokenTrieNode>();
                currentNodes.Enqueue(output.Head);
                for (int j = 0; j < grammar[i].Length; j++) //order of arguments
                {
                    Queue<TokenTrieNode> nextNodes = new Queue<TokenTrieNode>();
                    foreach (var item in currentNodes)
                    {
                        for (int k = 0; k < grammar[i][j].Length; k++) //differnt arguments
                        {
                            var token = grammar[i][j][k];
                            var newNode = new TokenTrieNode(token);

                            if (!item.Children.ContainsKey(token))
                            {
                                item.Children.Add(token, newNode);
                            }

                            nextNodes.Enqueue(newNode);
                        }
                        currentNodes = nextNodes;
                    }
                    
                }
                foreach (var item in currentNodes)
                {
                    item.Children.Add(0, new TokenTrieNode(nodeConstructors[i]));
                }
            }
            return output;
        }
    }

}
