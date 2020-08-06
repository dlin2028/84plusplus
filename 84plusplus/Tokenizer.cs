using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Tokenizer
{
    public class Tokenizer
    {
        SortedList<TokenType, Regex> regexes;
        private Func<TokenType, string, SpecificTokenType> specificTokenizer;

        public Tokenizer()
        {
            regexes = new SortedList<TokenType, Regex>();
            regexes.Add(TokenType.Comment, new Regex(@"\G(\/\*([^*]|[\r\n]|(\*+([^*\/]|[\r\n])))*\*+\/)|\G(\/\/.*)", RegexOptions.Compiled));
            regexes.Add(TokenType.Keyword, new Regex(@"\G(function|number|string|matrix|list|if|else|for|static|return|while|void|using)", RegexOptions.Compiled));
            regexes.Add(TokenType.Operator, new Regex(@"\G(<<|>>|\+|-|\*|\/|%|&|\||\^|<|>)=|^(\|\||&&|<<|>>|--|\+\+|->|==)|\G(\%|\&|\+|\-|\=|\/|\||\*|\:|>|<|\!|~|\^)", RegexOptions.Compiled));
            regexes.Add(TokenType.Constant, new Regex(@"\G([""'])(?:(?=(\\?))\2.)*?\1|(^[+-]?(\d*\.)?\d+)", RegexOptions.Compiled));
            regexes.Add(TokenType.Special, new Regex(@"\G[;(){}\[\],]", RegexOptions.Compiled));
            regexes.Add(TokenType.Identifier, new Regex(@"\G[_a-zA-Z][_a-zA-Z0-9]{0,30}", RegexOptions.Compiled));

            #region dont
            //AAH WHAT HAVE U DONE

            specificTokenizer = (t, s) =>
            {
                switch (t)
                {
                    case TokenType.Comment:
                        if (s.StartsWith("//"))
                            return SpecificTokenType.LineComment;
                        else
                            return SpecificTokenType.BlockComment;

                    case TokenType.Keyword:
                        switch (s)
                        {
                            case "function":
                                return SpecificTokenType.Function;
                            case "number":
                                return SpecificTokenType.Number;
                            case "string":
                                return SpecificTokenType.String;
                            case "matrix":
                                return SpecificTokenType.String;
                            case "list":
                                return SpecificTokenType.String;
                            case "if":
                                return SpecificTokenType.If;
                            case "for":
                                return SpecificTokenType.For;
                            case "static":
                                return SpecificTokenType.Static;
                            case "return":
                                return SpecificTokenType.Return;
                            case "while":
                                return SpecificTokenType.While;
                            case "void":
                                return SpecificTokenType.Void;
                            case "using":
                                return SpecificTokenType.Using;
                            default:
                                break;
                        }
                        break;
                    case TokenType.Identifier:
                        return SpecificTokenType.Identifier;
                    case TokenType.Operator:
                        switch (s)
                        {
                            case "<<=":
                                return SpecificTokenType.BitShiftLeftEquals;
                            case ">>=":
                                return SpecificTokenType.BitShiftRightEquals;
                            case "+=":
                                return SpecificTokenType.AddEquals;
                            case "-=":
                                return SpecificTokenType.SubtractEquals;
                            case "*=":
                                return SpecificTokenType.MultiplyEquals;
                            case "/=":
                                return SpecificTokenType.DivideEquals;
                            case "%=":
                                return SpecificTokenType.ModuloEquals;
                            case "&=":
                                return SpecificTokenType.AndEquals;
                            case "|=":
                                return SpecificTokenType.OrEquals;
                            case "^=":
                                return SpecificTokenType.AndEquals;
                            case "<=":
                                return SpecificTokenType.LessThanOrEqualTo;
                            case ">=":
                                return SpecificTokenType.GreaterThanOrEqualTo;
                            case "||":
                                return SpecificTokenType.LogicalOr;
                            case "&&":
                                return SpecificTokenType.LogicalAnd;
                            case "<<":
                                return SpecificTokenType.BitShiftLeft;
                            case ">>":
                                return SpecificTokenType.BitShiftRight;
                            case "--":
                                return SpecificTokenType.Decrement;
                            case "++":
                                return SpecificTokenType.Increment;
                            case "==":
                                return SpecificTokenType.EqualTo;
                            case "%":
                                return SpecificTokenType.Modulo;
                            case "&":
                                return SpecificTokenType.And;
                            case "+":
                                return SpecificTokenType.Add;
                            case "-":
                                return SpecificTokenType.Minus;
                            case "=":
                                return SpecificTokenType.Equals;
                            case "/":
                                return SpecificTokenType.Divide;
                            case "|":
                                return SpecificTokenType.Or;
                            case "*":
                                return SpecificTokenType.Multiply;
                            case "<":
                                return SpecificTokenType.LessThan;
                            case ">":
                                return SpecificTokenType.GreaterThan;
                            case "!":
                                return SpecificTokenType.Not;
                            case "^":
                                return SpecificTokenType.Xor;
                            default:
                                break;
                        }
                        break;
                    case TokenType.Constant:
                        if (s.StartsWith("\""))
                            return SpecificTokenType.StringConstant;
                        else
                            return SpecificTokenType.NumberConstant;
                    case TokenType.Special:
                        switch (s)
                        {
                            case "(":
                                return SpecificTokenType.LeftParenthesis;
                            case ")":
                                return SpecificTokenType.RightParenthesis;
                            case "[":
                                return SpecificTokenType.LeftBracket;
                            case "]":
                                return SpecificTokenType.RightBracket;
                            case "{":
                                return SpecificTokenType.LeftCurlyBrace;
                            case "}":
                                return SpecificTokenType.RightCurlyBrace;
                            case ";":
                                return SpecificTokenType.SemiColon;
                            case ",":
                                return SpecificTokenType.Comma;
                        }
                        break;
                    default:
                        break;
                }
                return SpecificTokenType.Void;
            };
            #endregion
        }

        public List<Token> Tokenize(string input)
        {
            List<Token> output = new List<Token>();
            int currentPos = 0;

            while(currentPos < input.Length)
            {
                foreach (var regex in regexes)
                {
                    var match = regex.Value.Match(input, currentPos);

                    if (match.Success)
                    {
                        var newToken = new Token(regex.Key, match.Value);
                        newToken.SpecificTokenType = specificTokenizer(newToken.TokenType, newToken.Lexeme);
                        output.Add(newToken);
                        currentPos += match.Value.Length;
                        break;
                    }
                }
                currentPos++;
            }

            return output;
        }
    }
}