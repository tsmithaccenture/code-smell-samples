using FluentAssertions;
using Xunit;

namespace Smelly.Code.Core.Test
{
    public class EvercraftGameTest
    {
        [Fact]
        public void GivenGameIsNotStartedWhenStartNewGameThenDefaultCharactersAreCreated()
        {
            var game = new EvercraftGame();
            
            game.Start();

            game.Characters.Should().HaveCount(2);
            game.Characters[0].HitPoints.Should().Be(5);
            game.Characters[0].Armor.Should().Be(10);
            game.Characters[1].HitPoints.Should().Be(5);
            game.Characters[1].Armor.Should().Be(10);
        }

        [Fact]
        public void GivenGameHasStartedWhenRollIsGreaterThanArmorThenCharacterTakesDamage()
        {
            var game = new EvercraftGame();
            game.Start();

            game.Roll(11);

            game.Characters[1].HitPoints.Should().Be(4);
        }

        [Fact]
        public void GivenGameHasStartedWhenRollIsEqualToArmorThenCharacterTakesDamage()
        {
            var game = new EvercraftGame();
            game.Start();

            game.Roll(10);

            game.Characters[1].HitPoints.Should().Be(4);
        }

        [Fact]
        public void GivenGameHasStartedWhenRollIsLessThanArmorThenNoDamageIsDealt()
        {
            var game = new EvercraftGame();
            game.Start();

            game.Roll(9);

            game.Characters[1].HitPoints.Should().Be(5);
        }

        [Fact]
        public void GivenGameHasStartedWhenRollIsACriticalHitThenCharacterTakesDoubleDamage()
        {
            var game = new EvercraftGame();
            game.Start();

            game.Roll(20);

            game.Characters[1].HitPoints.Should().Be(3);
        }

        [Fact]
        public void GivenCharacterHasOneHitPointLeftWhenRollIsGreaterThanArmorThenCharacterIsDead()
        {
            var game = new EvercraftGame();
            game.Start();
            game.Roll(11);
            game.Roll(11);
            game.Roll(11);
            game.Roll(11);
            
            game.Roll(11);

            game.Characters[1].HitPoints.Should().Be(0);
            game.IsDead(game.Characters[1]).Should().Be(true);
        }

        [Fact]
        public void GivenGameHasStartedWhenCharacterEquipsBronzeArmorThenCharactersArmorIsDecreasedByOne()
        {
            var game = new EvercraftGame();
            game.Start();

            game.EquipArmor(ArmorType.Bronze, game.Characters[1]);

            game.Characters[1].Armor.Should().Be(9);
        }

        [Fact]
        public void GivenGameHasStartedWhenCharacterEquipsSteelArmorThenCharactersArmorIsIncreasedByOne()
        {
            var game = new EvercraftGame();
            game.Start();

            game.EquipArmor(ArmorType.Steel, game.Characters[1]);

            game.Characters[1].Armor.Should().Be(11);
        }

        [Fact]
        public void GivenGameHasStartedWhenCharacterEquipsIronArmorThenCharactersArmorIsUnchanged()
        {
            var game = new EvercraftGame();
            game.Start();

            game.EquipArmor(ArmorType.Iron, game.Characters[1]);

            game.Characters[1].Armor.Should().Be(10);
        }

        [Theory]
        [InlineData(1, -5)]
        [InlineData(2, -4)]
        [InlineData(3, -4)]
        [InlineData(4, -3)]
        [InlineData(5, -3)]
        [InlineData(6, -2)]
        [InlineData(7, -2)]
        [InlineData(8, -1)]
        [InlineData(9, -1)]
        public void GivenCharacterHasStrengthWithNegativeModifierWhenRollIsModifiedToBeLessThanArmorThenCharacterTakesOneDamage(int strength, int modifier)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyStrength(strength, game.Characters[0]);

            game.Roll(9 - modifier);

            game.Characters[1].HitPoints.Should().Be(4);
        }

        [Theory]
        [InlineData(1, -5)]
        [InlineData(2, -4)]
        [InlineData(3, -4)]
        [InlineData(4, -3)]
        [InlineData(5, -3)]
        [InlineData(6, -2)]
        [InlineData(7, -2)]
        [InlineData(8, -1)]
        [InlineData(9, -1)]
        public void GivenCharacterHasStrengthWithNegativeModifierWhenRollIsModifiedToBeGreaterThanArmorThenCharacterTakesTwoDamage(int strength, int modifier)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyStrength(strength, game.Characters[0]);

            game.Roll(10 - modifier);

            game.Characters[1].HitPoints.Should().Be(3);
        }

        [Theory]
        [InlineData(12, 1)]
        [InlineData(13, 1)]
        [InlineData(14, 2)]
        [InlineData(15, 2)]
        [InlineData(16, 3)]
        [InlineData(17, 3)]
        [InlineData(18, 4)]
        [InlineData(19, 4)]
        [InlineData(20, 5)]
        public void GivenCharacterHasStrengthWithPositiveModifierWhenRollIsModifiedToBeGreaterThanArmorThenCharacterTakesModifierDamage(int strength, int modifier)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyStrength(strength, game.Characters[0]);
            
            game.Roll(10 - modifier);

            game.Characters[1].HitPoints.Should().Be(4 - modifier);
        }

        [Theory]
        [InlineData(12, 1)]
        [InlineData(13, 1)]
        [InlineData(14, 2)]
        [InlineData(15, 2)]
        [InlineData(16, 3)]
        [InlineData(17, 3)]
        [InlineData(18, 4)]
        [InlineData(19, 4)]
        [InlineData(20, 5)]
        public void GivenCharacterHasStrengthWithPositiveModifierWhenRollIsModifiedToBeLessThanArmorThenCharacterTakesOneDamage(int strength, int modifier)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyStrength(strength, game.Characters[0]);
            
            game.Roll(9 - modifier);

            game.Characters[1].HitPoints.Should().Be(4);
        }

        [Theory]
        [InlineData(1, -5)]
        [InlineData(2, -4)]
        [InlineData(3, -4)]
        [InlineData(4, -3)]
        [InlineData(5, -3)]
        [InlineData(6, -2)]
        [InlineData(7, -2)]
        [InlineData(8, -1)]
        [InlineData(9, -1)]
        public void GivenCharacterHasDexterityWithNegativeModifierWhenRollIsGreaterThanModifiedArmorThenCharacterTakesDamage(int dexterity, int modifier)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyDexterity(dexterity, game.Characters[0]);
            
            game.Roll(10 + modifier);

            game.Characters[1].HitPoints.Should().Be(4);
        }
        
        [Theory]
        [InlineData(1, -5)]
        [InlineData(2, -4)]
        [InlineData(3, -4)]
        [InlineData(4, -3)]
        [InlineData(5, -3)]
        [InlineData(6, -2)]
        [InlineData(7, -2)]
        [InlineData(8, -1)]
        [InlineData(9, -1)]
        public void GivenCharacterHasDexterityWithNegativeModifierWhenRollIsLessThanModifiedArmorThenCharacterDoesNotTakeDamage(int dexterity, int modifier)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyDexterity(dexterity, game.Characters[0]);
            
            game.Roll(9 + modifier);

            game.Characters[1].HitPoints.Should().Be(5);
        }

        [Theory]
        [InlineData(12, 1)]
        [InlineData(13, 1)]
        [InlineData(14, 2)]
        [InlineData(15, 2)]
        [InlineData(16, 3)]
        [InlineData(17, 3)]
        [InlineData(18, 4)]
        [InlineData(19, 4)]
        [InlineData(20, 5)]
        public void GivenCharacterHasDexterityWithPositiveModifierWhenRollIsGreaterThanModifiedArmorThenCharacterTakesDamage(int dexterity, int modifier)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyDexterity(dexterity, game.Characters[0]);
            
            game.Roll(10 + modifier);

            game.Characters[1].HitPoints.Should().Be(4);
        }
        
        [Theory]
        [InlineData(12, 1)]
        [InlineData(13, 1)]
        [InlineData(14, 2)]
        [InlineData(15, 2)]
        [InlineData(16, 3)]
        [InlineData(17, 3)]
        [InlineData(18, 4)]
        [InlineData(19, 4)]
        [InlineData(20, 5)]
        public void GivenCharacterHasDexterityWithPositiveModifierWhenRollIsLessThanModifiedArmorThenCharacterTakesNoDamage(int dexterity, int modifier)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyDexterity(dexterity, game.Characters[0]);
            
            game.Roll(9 + modifier);

            game.Characters[1].HitPoints.Should().Be(5);
        }
        
        
    }
}