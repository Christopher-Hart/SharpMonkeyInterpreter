namespace Lexer;

using TokenType = String;

public class TokenConstants
{
    public const string ILLEGAL = "ILLEGAL";
    public const string EOF = "EOF";
    //Identifiers
    public const string INT = "INT";
    public const string IDENT = "IDENT";
    //Operators
    public const string ASSIGN = "=";
    public const string PLUS = "+";
    //Delimiters
    public const string COMMA = ",";
    public const string SEMICOLON = ";";
    public const string L_PAREN = "(";
    public const string R_PAREN = ")";
    public const string L_BRACE = "{";
    public const string R_BRACE = "}";

    //Keywords
    public const string FUNCTION = "FUNCTION";
    public const string LET = "LET";
}

public class Token
{
    public TokenType Type;
    public string Literal;

    public Token(TokenType input_type, string input_literal)
    {
        Type = input_type;
        Literal = input_literal;
    }

    public override string ToString()
    {
        return Type + "(" + Literal + ")";
    }
}


