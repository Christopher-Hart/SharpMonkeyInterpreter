using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace Lexer;

public class Lexer
{
    private string input;
    private int position;
    private int readPosition;
    private char character;

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
                token = new(TokenConstants.ASSIGN, character);
                break;
            case ';':
                token = new(TokenConstants.SEMICOLON, character);
                break;
            case '(':
                token = new(TokenConstants.L_PAREN, character);
                break;
            case ')':
                token = new(TokenConstants.R_PAREN, character);
                break;
            case ',':
                token = new(TokenConstants.COMMA, character);
                break;
            case '+':
                token = new(TokenConstants.PLUS, character);
                break;
            case '{':
                token = new(TokenConstants.L_BRACE, character);
                break;
            case '}':
                token = new(TokenConstants.R_BRACE, character);
                break;
            case '\0':
                token = new(TokenConstants.EOF, '\0');
                break;
            default:
                if (IsLetter(character))
                {
                    string identifier = ReadIdentifer();
                    token = new(TokenUtils.GetTokenType(identifier),identifier);
                    return token;
                }
                else if (IsDigit(character))
                {
                    token = new(TokenConstants.INT,ReadInt());
                    return token;
                }
                else
                {
                    token = new(TokenConstants.ILLEGAL, character);
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