using System.Linq.Expressions;
using Lexer;

public class Repl
{
    const string Prompt = ">> ";

    public static void Start()
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Prompt);
            Console.ResetColor();
            string input = Console.ReadLine();

            if (input == "\\quit")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            Lexer.Lexer lexer = new(input);

            for (Token t = lexer.NextToken(); t.Type != Token.EOF; t = lexer.NextToken())
            {
                Console.WriteLine(t);
            }
        }
    }
}