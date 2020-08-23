using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tokenizer
{
    public enum TokenType
    {
        Expression = -1,
        None,
        Comment,
        Keyword,
        Identifier,
        Operator,
        Constant,
        Special
    };

    public enum SpecificTokenType
    {
        None = 0,
        //comment
        LineComment = 7,
        BlockComment,

        //keyword
        Number,
        String,
        List,
        Matrix,
        If,
        Else,
        For,
        Static,
        Return,
        While,
        Void,
        Using,
        Function,

        //operator
        BitShiftLeftEquals,
        BitShiftRightEquals,
        AddEquals,
        SubtractEquals,
        MultiplyEquals,
        DivideEquals,
        ModuloEquals,
        AndEquals,
        OrEquals,
        XorEquals,

        //binary operator
        Add,
        Minus,
        Multiply,
        Divide,
        Modulo,
        BitShiftLeft,
        BitShiftRight,
        LogicalAnd,
        LogicalOr,
        And,
        Or,
        Xor,
        Not,
        EqualTo,
        LessThan,
        GreaterThan,
        GreaterThanOrEqualTo,
        LessThanOrEqualTo,

        //unary operator
        Increment,
        Decrement,

        Equals,


        //Special
        LeftParenthesis,
        RightParenthesis,

        //Identifier
        Identifier,
        //Constant
        StringConstant,
        NumberConstant,

        //Special
        LeftCurlyBrace,
        RightCurlyBrace,
        LeftBracket,
        RightBracket,

        Comma,
        SemiColon,
    }

    
    public class Token
    {
        public TokenType TokenType;
        public SpecificTokenType SpecificTokenType;
        public string Lexeme;

        public Token(TokenType tokenType, string lexeme)
        {
            TokenType = tokenType;
            Lexeme = lexeme;
        }
        public static bool operator ==(Token b1, TokenType b2)
        {
            return b1.Equals(b2);
        }
        public static bool operator !=(Token b1, TokenType b2)
        {
            return !(b1 == b2);
        }
        public static bool operator ==(Token b1, SpecificTokenType b2)
        {
            return b1.Equals(b2);
        }
        public static bool operator !=(Token b1, SpecificTokenType b2)
        {
            return !(b1 == b2);
        }
        public static bool operator ==(Token b1, Token b2)
        {
            if (b1 is null)
                return b2 is null;

            return b1.Equals(b2);
        }
        public static bool operator !=(Token b1, Token b2)
        {
            return !(b1 == b2);
        }

        public override bool Equals(object obj)
        {
            var type = obj.GetType();
            if (type == typeof(TokenType))
                return TokenType == (TokenType)obj;
            else if (type == typeof(SpecificTokenType))
                return SpecificTokenType == (SpecificTokenType)obj;
            else if (type == typeof(Token))
                return SpecificTokenType == ((Token)obj).SpecificTokenType && TokenType == ((Token)obj).TokenType;
            else
                return false;
        }
    }
}
