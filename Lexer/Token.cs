namespace Lexer;

using TokenType = String;

public class Token
{
    //Constants
    public const string ILLEGAL = "ILLEGAL";
    public const string EOF = "EOF";
    //Identifiers
    public const string INT = "INT";
    public const string IDENT = "IDENT";
    //Operators
    public const string ASSIGN = "=";
    public const string PLUS = "+";
    public const string MINUS = "-";
    public const string BANG = "!";
    public const string ASTRISK = "*";
    public const string SLASH = "/";
    public const string LT = "<";
    public const string GT = ">";
    public const string EQUAL = "==";
    public const string NOT_EQUAL = "!=";
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
    public const string TRUE = "TRUE";
    public const string FALSE = "FALSE";
    public const string IF = "IF";
    public const string ELSE = "ELSE";
    public const string RETURN = "RETURN";

    //Members
    public TokenType Type;
    public string Literal;

    //Constructors
    public Token(TokenType input_type, string input_literal)
    {
        Type = input_type;
        Literal = input_literal;
    }
    public Token(TokenType input_type, char input_literal)
    {
        Type = input_type;
        Literal = input_literal.ToString();
    }

    //Static Utils
    private static readonly Dictionary<string, TokenType> GetKeyword = new()
    {
        {"fn",FUNCTION},
        {"let",LET},
        {"true",TRUE},
        {"false",FALSE},
        {"if",IF},
        {"else",ELSE},
        {"return",RETURN}
    };

    public static TokenType GetTokenType(string literal)
    {
        try
        {
            return GetKeyword[literal];
        }
        catch
        {
            return IDENT;
        }
    }

    public override string ToString()
    {
        return "{Type: " + Type + ", " + "Literal: \'" + Literal + "\'}";
    }
}


