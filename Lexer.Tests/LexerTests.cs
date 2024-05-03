namespace Lexer.Tests;

public class Tests
{
    [Test]
    public void TestNextToken()
    {
        string input = "=+(){},;";

        (string expected_type, char expected_literal)[] expected =
        [
            (TokenConstants.ASSIGN,'='),
            (TokenConstants.PLUS,'+'),
            (TokenConstants.L_PAREN,'('),
            (TokenConstants.R_PAREN,')'),
            (TokenConstants.L_BRACE,'{'),
            (TokenConstants.R_BRACE,'}'),
            (TokenConstants.COMMA,','),
            (TokenConstants.SEMICOLON,';'),
        ];

        Lexer tester = new(input);

        for (int i = 0; i < expected.Length; i++)
        {
            Token token = tester.NextToken();
            Assert.Multiple(() =>
            {
                Assert.That(token.Type, Is.EqualTo(expected[i].expected_type));
                Assert.That(token.Literal, Is.EqualTo(expected[i].expected_literal));
            });
        }
    }
}