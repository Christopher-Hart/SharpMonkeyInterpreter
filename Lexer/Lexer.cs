namespace Lexer;

public class Lexer
{
    //Members
    private string input;
    private int position;
    private int readPosition;
    private char character;

    //Constructor
    public Lexer(string input)
    {
        position = 0;
        readPosition = 0;
        character = '\0';
        this.input = input;
        ReadChar();
    }

    private void ReadChar()
    {
        if (readPosition >= input.Length)
        {
            character = '\0';
        }
        else
        {
            character = input[readPosition];
        }

        position = readPosition;
        readPosition++;
    }

    public Token NextToken()
    {
        Token token;

        SkipWhitespace();

        switch (character)
        {
            case '=':
                token = new(Token.ASSIGN, character);
                break;
            case ';':
                token = new(Token.SEMICOLON, character);
                break;
            case '(':
                token = new(Token.L_PAREN, character);
                break;
            case ')':
                token = new(Token.R_PAREN, character);
                break;
            case ',':
                token = new(Token.COMMA, character);
                break;
            case '+':
                token = new(Token.PLUS, character);
                break;
            case '{':
                token = new(Token.L_BRACE, character);
                break;
            case '}':
                token = new(Token.R_BRACE, character);
                break;
            case '\0':
                token = new(Token.EOF, '\0');
                break;
            default:
                if (IsLetter(character))
                {
                    string identifier = ReadIdentifer();
                    token = new(Token.GetTokenType(identifier), identifier);
                    return token;
                }
                else if (IsDigit(character))
                {
                    token = new(Token.INT, ReadInt());
                    return token;
                }
                else
                {
                    token = new(Token.ILLEGAL, character);
                }
                break;
        }

        ReadChar();
        return token;
    }

    private bool IsLetter(char ch)
    {
        return (('a' <= ch) && (ch <= 'z')) || (ch == '_') || (('A' <= ch) && (ch <= 'Z'));
    }

    private bool IsDigit(char ch)
    {
        return ('0' >= ch) || (ch <= '9');
    }

    private void SkipWhitespace()
    {
        while (character == ' ' || character == '\t' || character == '\n' || character == '\r')
        {
            ReadChar();
        }
    }
    private string ReadIdentifer()
    {
        int starting_position = position;
        while (IsLetter(character))
        {
            ReadChar();
        }

        int ident_length = position - starting_position;
        return input.Substring(starting_position, ident_length);
    }

    private string ReadInt()
    {
        int starting_position = position;
        while (IsDigit(character))
        {
            ReadChar();
        }

        int ident_length = position - starting_position;
        return input.Substring(starting_position, ident_length);
    }

}