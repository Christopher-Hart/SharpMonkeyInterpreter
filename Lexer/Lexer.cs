using System.ComponentModel.DataAnnotations;

namespace Lexer;

public class Lexer
{
    public string input;
    public int position;
    public int readPosition;
    public char character;

    public Lexer(string input)
    {
        position = 0;
        readPosition = 0;
        character = '\0';
        this.input = input;
        ReadChar();
    }

    public void ReadChar()
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
        Token token = null;

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
        }

        ReadChar();
        return token;
    }

}