namespace Lexer.Tests;

public class Tests
{
    [Test]
    public void TestNextToken()
    {
        string input = """
        let five = 5;
        let ten = 10;
        let add = fn(x,y) {
            x + y;
        };

        let results = add(five, ten);
        !-/*5;
        5 < 10 > 5;

        if (5 < 10) {
            return true;
        } else {
            return false;
        }

        10 == 10;
        10 != 9;
        """;

        (string expected_type, string expected_literal)[] expected =
        [
            (Token.LET,"let"),
            (Token.IDENT,"five"),
            (Token.ASSIGN,"="),
            (Token.INT,"5"),
            (Token.SEMICOLON,";"),
            (Token.LET,"let"),
            (Token.IDENT,"ten"),
            (Token.ASSIGN,"="),
            (Token.INT,"10"),
            (Token.SEMICOLON,";"),
            (Token.LET,"let"),
            (Token.IDENT,"add"),
            (Token.ASSIGN,"="),
            (Token.FUNCTION,"fn"),
            (Token.L_PAREN,"("),
            (Token.IDENT,"x"),
            (Token.COMMA,","),
            (Token.IDENT,"y"),
            (Token.R_PAREN,")"),
            (Token.L_BRACE,"{"),
            (Token.IDENT,"x"),
            (Token.PLUS,"+"),
            (Token.IDENT,"y"),
            (Token.SEMICOLON,";"),
            (Token.R_BRACE,"}"),
            (Token.SEMICOLON,";"),
            (Token.LET,"let"),
            (Token.IDENT,"results"),
            (Token.ASSIGN,"="),
            (Token.IDENT,"add"),
            (Token.L_PAREN,"("),
            (Token.IDENT,"five"),
            (Token.COMMA,","),
            (Token.IDENT,"ten"),
            (Token.R_PAREN,")"),
            (Token.SEMICOLON,";"),
            (Token.BANG,"!"),
            (Token.MINUS,"-"),
            (Token.SLASH,"/"),
            (Token.ASTRISK,"*"),
            (Token.INT,"5"),
            (Token.SEMICOLON,";"),
            (Token.INT,"5"),
            (Token.LT,"<"),
            (Token.INT,"10"),
            (Token.GT,">"),
            (Token.INT,"5"),
            (Token.SEMICOLON,";"),
            (Token.IF,"if"),
            (Token.L_PAREN,"("),
            (Token.INT,"5"),
            (Token.LT,"<"),
            (Token.INT,"10"),
            (Token.R_PAREN,")"),
            (Token.L_BRACE,"{"),
            (Token.RETURN,"return"),
            (Token.TRUE,"true"),
            (Token.SEMICOLON,";"),
            (Token.R_BRACE,"}"),
            (Token.ELSE,"else"),
            (Token.L_BRACE,"{"),
            (Token.RETURN,"return"),
            (Token.FALSE,"false"),
            (Token.SEMICOLON,";"),
            (Token.R_BRACE,"}"),
            (Token.INT,"10"),
            (Token.EQUAL,"=="),
            (Token.INT,"10"),
            (Token.SEMICOLON,";"),
            (Token.INT,"10"),
            (Token.NOT_EQUAL,"!="),
            (Token.INT,"9"),
            (Token.SEMICOLON,";"),
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