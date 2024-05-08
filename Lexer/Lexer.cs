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

    private char PeekChar()
    {
        if (readPosition >= input.Length)
        {
            return '\0';
        }
        else
        {
            return input[readPosition];
        }
    }

    public Token NextToken()
    {
        Token token;

        SkipWhitespace();

        switch (character)
        {
            case '=':
                if (PeekChar() == '=')
                {
                    char ch = character;
                    ReadChar();
                    token = new(Token.EQUAL, ch.ToString() + character.ToString());
                }
                else
                {
                    token = new(Token.ASSIGN, character);
                }
                break;
            case '-':
                token = new(Token.MINUS, character);
                break;
            case '!':
                if (PeekChar() == '=')
                {
                    char ch = character;
                    ReadChar();
                    token = new(Token.NOT_EQUAL, ch.ToString() + character.ToString());
                }
                else
                {
                    token = new(Token.BANG, character);
                }
                break;
            case '*':
                token = new(Token.ASTRISK, character);
                break;
            case '/':
                token = new(Token.SLASH, character);
                break;
            case '<':
                token = new(Token.LT, character);
                break;
            case '>':
                token = new(Token.GT, character);
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
        return ('0' <= ch) && (ch <= '9');
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