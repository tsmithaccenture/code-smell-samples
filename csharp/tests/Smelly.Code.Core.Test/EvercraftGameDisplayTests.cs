using System.Linq;
using Fizzler.Systems.HtmlAgilityPack;
using FluentAssertions;
using HtmlAgilityPack;
using Xunit;

namespace Smelly.Code.Core.Test
{
    public class EvercraftGameDisplayTests
    {
        [Fact]
        public void GivenConsoleDisplayTypeWhenRenderedThenCharacterInfoIsRenderedUsingAString()
        {
            var game = new EvercraftGame();
            game.Start("Thing 1", "Thing 2");
            
            var display = new EvercraftGameDisplay(DisplayType.Console);

            var content = display.Render(game);

            content.Should().Be("Characters\n" +
                                "Thing 1:\n" +
                                "\tHit Points: 5\n" +
                                "\tArmor: 10\n" +
                                "\tStrength: N/A\n" +
                                "\tDexterity: N/A\n" +
                                "\tConstitution: N/A\n" +
                                "Thing 2:\n" +
                                "\tHit Points: 5\n" +
                                "\tArmor: 10\n" +
                                "\tStrength: N/A\n" +
                                "\tDexterity: N/A\n" +
                                "\tConstitution: N/A\n");
        }
        
        [Fact]
        public void GivenConsoleDisplayTypeAndCharactersWithAttributesWhenRenderedThenCharacterAttributesAreRenderedUsingString()
        {
            var game = new EvercraftGame();
            game.Start("Thing 1", "Thing 2");
            game.ApplyStrength(1, game.Chars[0]);
            game.ApplyStrength(2, game.Chars[1]);
            game.ApplyDexterity(3, game.Chars[0]);
            game.ApplyDexterity(4, game.Chars[1]);
            game.ApplyConstitution(5, game.Chars[0]);
            game.ApplyConstitution(6, game.Chars[1]);
            
            var display = new EvercraftGameDisplay(DisplayType.Console);

            var content = display.Render(game);

            content.Should().Be("Characters\n" +
                                "Thing 1:\n" +
                                "\tHit Points: 5\n" +
                                "\tArmor: 10\n" +
                                "\tStrength: 1\n" +
                                "\tDexterity: 3\n" +
                                "\tConstitution: 5\n" +
                                "Thing 2:\n" +
                                "\tHit Points: 5\n" +
                                "\tArmor: 10\n" +
                                "\tStrength: 2\n" +
                                "\tDexterity: 4\n" +
                                "\tConstitution: 6\n");
        }

        [Fact]
        public void GivenWebDisplayTypeWhenRenderedThenCharacterInfoIsRenderedUsingHtml()
        {
            var game = new EvercraftGame();
            game.Start("Thing 1", "Thing 2");
            
            var display = new EvercraftGameDisplay(DisplayType.Web);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(display.Render(game));

            var characters = htmlDoc.DocumentNode.QuerySelectorAll("[data-character]").ToArray();
            characters.Should().HaveCount(2);

            characters.ElementAt(0).QuerySelector("[data-name]").InnerText.Should().Contain("Thing 1");
            characters.ElementAt(0).QuerySelector("[data-hit-points]").InnerText.Should().Contain("5");
            characters.ElementAt(0).QuerySelector("[data-armor]").InnerText.Should().Contain("10");
            characters.ElementAt(0).QuerySelector("[data-strength]").InnerText.Should().Contain("N/A");
            characters.ElementAt(0).QuerySelector("[data-dexterity]").InnerText.Should().Contain("N/A");
            characters.ElementAt(0).QuerySelector("[data-constitution]").InnerText.Should().Contain("N/A");
            
            characters.ElementAt(1).QuerySelector("[data-name]").InnerText.Should().Contain("Thing 2");
            characters.ElementAt(1).QuerySelector("[data-hit-points]").InnerText.Should().Contain("5");
            characters.ElementAt(1).QuerySelector("[data-armor]").InnerText.Should().Contain("10");
            characters.ElementAt(1).QuerySelector("[data-strength]").InnerText.Should().Contain("N/A");
            characters.ElementAt(1).QuerySelector("[data-dexterity]").InnerText.Should().Contain("N/A");
            characters.ElementAt(1).QuerySelector("[data-constitution]").InnerText.Should().Contain("N/A");
        }
        
        [Fact]
        public void GivenWebDisplayTypeAndCharactersWithAttributesWhenRenderedThenCharacterAttributesAreRenderedUsingHtml()
        {
            var game = new EvercraftGame();
            game.Start("Thing 1", "Thing 2");
            game.ApplyStrength(1, game.Chars[0]);
            game.ApplyStrength(2, game.Chars[1]);
            game.ApplyDexterity(3, game.Chars[0]);
            game.ApplyDexterity(4, game.Chars[1]);
            game.ApplyConstitution(5, game.Chars[0]);
            game.ApplyConstitution(6, game.Chars[1]);
            
            var display = new EvercraftGameDisplay(DisplayType.Web);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(display.Render(game));

            var characters = htmlDoc.DocumentNode.QuerySelectorAll("[data-character]").ToArray();
            characters.Should().HaveCount(2);

            characters.ElementAt(0).QuerySelector("[data-name]").InnerText.Should().Contain("Thing 1");
            characters.ElementAt(0).QuerySelector("[data-hit-points]").InnerText.Should().Contain("5");
            characters.ElementAt(0).QuerySelector("[data-armor]").InnerText.Should().Contain("10");
            characters.ElementAt(0).QuerySelector("[data-strength]").InnerText.Should().Contain("1");
            characters.ElementAt(0).QuerySelector("[data-dexterity]").InnerText.Should().Contain("3");
            characters.ElementAt(0).QuerySelector("[data-constitution]").InnerText.Should().Contain("5");
            
            characters.ElementAt(1).QuerySelector("[data-name]").InnerText.Should().Contain("Thing 2");
            characters.ElementAt(1).QuerySelector("[data-hit-points]").InnerText.Should().Contain("5");
            characters.ElementAt(1).QuerySelector("[data-armor]").InnerText.Should().Contain("10");
            characters.ElementAt(1).QuerySelector("[data-strength]").InnerText.Should().Contain("2");
            characters.ElementAt(1).QuerySelector("[data-dexterity]").InnerText.Should().Contain("4");
            characters.ElementAt(1).QuerySelector("[data-constitution]").InnerText.Should().Contain("6");
        }
    }
}