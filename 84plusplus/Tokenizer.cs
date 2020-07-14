using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Tokenizer
{
    public class Tokenizer
    {
        Dictionary<TokenType, Regex> regexes;
        private Func<TokenType, string, SpecificTokenType> specificTokenizer;

        public Tokenizer()
        {
            regexes = new Dictionary<TokenType, Regex>();
            //THE ORDER HERE DOES NOT MATTER!!!!!!!!!!!!!!!!!!!!!!!!!!!
            regexes.Add(TokenType.Comment, new Regex(@"\/\*([^*]|\*+[^\/])*\*+\/|\/\/.*$"));
            regexes.Add(TokenType.Keyword, new Regex("(number|string|if|else|for|static|return|while|void|using)"));
            regexes.Add(TokenType.Operator, new Regex(@"(<<|>>|\+|-|\*|\/|%|&|\||\^|<|>)=|(\|\||&&|<<|>>|--|\+\+|->|==)|(\%|\&|\+|\-|\=|\/|\||\*|\:|>|<|\!|~|\^)"));
            regexes.Add(TokenType.StringConstant, new Regex(@"""(?:\\.|[^""\\])*"""));
            regexes.Add(TokenType.NumberConstant, new Regex(@"^[+-]?(\d*\.)?\d+"));
            regexes.Add(TokenType.Special, new Regex(@"[;(){}\[\],]"));
            regexes.Add(TokenType.Identifier, new Regex(@"[_a-zA-Z][_a-zA-Z0-9]{0,30}"));

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
                            case "number":
                                return SpecificTokenType.Number;
                            case "string":
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
                    case TokenType.StringConstant:
                        return SpecificTokenType.StringConstant;
                    case TokenType.NumberConstant:
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

                    if(match.Success && match.Index == 0) //this really needs to be optimized but i hate regex
                    {
                        var newToken = new Token((TokenType)j, match.Value);
                        newToken.SpecificTokenType = specificTokenizer(newToken.TokenType, newToken.Lexeme);
                        output.Add(newToken);
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