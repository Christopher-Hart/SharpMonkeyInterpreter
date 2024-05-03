namespace Lexer.Tests;

public class Tests
{
    [Test]
    public void TestBasicNextToken()
    {
        string input = "=+(){},;";

        (string expected_type, string expected_literal)[] expected =
        [
            (TokenConstants.ASSIGN,"="),
            (TokenConstants.PLUS,"+"),
            (TokenConstants.L_PAREN,"("),
            (TokenConstants.R_PAREN,")"),
            (TokenConstants.L_BRACE,"{"),
            (TokenConstants.R_BRACE,"}"),
            (TokenConstants.COMMA,","),
            (TokenConstants.SEMICOLON,";"),
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

    [Test]
    public void TestNextToken()
    {
        string input = """
        let five = 5;
        let ten = 10;
        let add = fn(x,y) {
            x + y;
        };

        let results = add(five,ten);
        """;

        (string expected_type, string expected_literal)[] expected =
        [
            (TokenConstants.LET,"let"),
            (TokenConstants.IDENT,"five"),
            (TokenConstants.ASSIGN,"="),
            (TokenConstants.INT,"5"),
            (TokenConstants.SEMICOLON,";"),
            (TokenConstants.LET,"let"),
            (TokenConstants.IDENT,"ten"),
            (TokenConstants.ASSIGN,"="),
            (TokenConstants.INT,"10"),
            (TokenConstants.SEMICOLON,";"),
            (TokenConstants.LET,"let"),
            (TokenConstants.IDENT,"add"),
            (TokenConstants.ASSIGN,"="),
            (TokenConstants.FUNCTION,"fn"),
            (TokenConstants.L_PAREN,"("),
            (TokenConstants.IDENT,"x"),
            (TokenConstants.COMMA,","),
            (TokenConstants.IDENT,"y"),
            (TokenConstants.R_PAREN,")"),
            (TokenConstants.L_BRACE,"{"),
            (TokenConstants.IDENT,"x"),
            (TokenConstants.PLUS,"+"),
            (TokenConstants.IDENT,"y"),
            (TokenConstants.SEMICOLON,";"),
            (TokenConstants.R_BRACE,"}"),
            (TokenConstants.SEMICOLON,";"),
            (TokenConstants.LET,"let"),
            (TokenConstants.IDENT,"results"),
            (TokenConstants.ASSIGN,"="),
            (TokenConstants.IDENT,"add"),
            (TokenConstants.L_PAREN,"("),
            (TokenConstants.IDENT,"five"),
            (TokenConstants.COMMA,","),
            (TokenConstants.IDENT,"ten"),
            (TokenConstants.R_PAREN,")"),
            (TokenConstants.SEMICOLON,";"),
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