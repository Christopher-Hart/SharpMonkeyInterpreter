using System.ComponentModel.DataAnnotations;

namespace Lexer;

public class Lexer
{
    public string input;
    public int position;
    public int readPosition;
    public char character;
    Lexer(string input)
    {
        input = input;
    }

    public void readChar()
    {
        if (readPosition >= input.Length)
        {
            char = 0
        }
        else
        {
            char = input[readPosition]
        }

        position = readPosition;
        readPosition++;
    }
}