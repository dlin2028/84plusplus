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
    }
}
