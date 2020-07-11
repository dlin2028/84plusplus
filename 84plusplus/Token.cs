using System;
using System.Collections.Generic;
using System.Text;

namespace Tokenizer
{
    public enum TokenType
    {
        Comment,
        Keyword,
        Identifier,
        Operator,
        StringConstant,
        NumberConstant,
        Special
    };

    public enum SpecificTokenType
    {
        //comment
        LineComment,
        BlockComment,

        //keyword
        Number,
        String,
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
        Increment,
        Decrement,

        BitShiftLeft,
        BitShiftRight,
        Add,
        Minus,
        Multiply,
        Divide,
        Modulo,
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
        
        Equals,
        //Constant
        StringConstant,
        NumberConstant,

        //Special
        LeftCurlyBrace,
        RightCurlyBrace,
        LeftBracket,
        RightBracket,
        LeftParenthesis,
        RightParenthesis,

        Comma,
        SemiColon,

        //Identifier
        Identifier
    }

    
    class Token
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
