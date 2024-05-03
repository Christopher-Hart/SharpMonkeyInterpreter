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
    public const string ASSIGN = "ASSIGN";
    public const string PLUS = "PLUS";
    //Delimiters
    public const string COMMA = "COMMA";
    public const string SEMICOLON = "SEMICOLON";
    public const string L_PAREN = "L_PAREN";
    public const string R_PAREN = "R_PAREN";
    public const string L_BRACE = "L_BRACE";
    public const string R_BRACE = "R_BRACE";

    //Keywords
    public const string FUNCTION = "FUNCTION";
    public const string LET = "LET";
}

public class TokenUtils
{
    private static readonly Dictionary<string, TokenType> GetKeyword = new()
    {
        {"fn",TokenConstants.FUNCTION},
        {"let",TokenConstants.LET}
    };

    public static TokenType GetTokenType(string literal)
    {
        try
        {
            return GetKeyword[literal];
        }
        catch
        {
            return TokenConstants.IDENT;
        }
    }
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
    public Token(TokenType input_type, char input_literal)
    {
        Type = input_type;
        Literal = input_literal.ToString();
    }

    public override string ToString()
    {
        return Type + "(" + Literal + ")";
    }
}


