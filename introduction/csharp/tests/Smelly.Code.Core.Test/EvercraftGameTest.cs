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

            game.Chars.Should().HaveCount(2);
            game.Chars[0].HitPoints.Should().Be(5);
            game.Chars[0].Armor.Should().Be(10);
            game.Chars[1].HitPoints.Should().Be(5);
            game.Chars[1].Armor.Should().Be(10);
        }

        [Fact]
        public void GivenGameHasStartedWhenRollIsGreaterThanArmorThenCharacterTakesDamage()
        {
            var game = new EvercraftGame();
            game.Start();

            game.Attack(11, game.Chars[1]);

            game.Chars[1].HitPoints.Should().Be(4);
        }

        [Fact]
        public void GivenGameHasStartedWhenRollIsEqualToArmorThenCharacterTakesDamage()
        {
            var game = new EvercraftGame();
            game.Start();

            game.Attack(10, game.Chars[1]);

            game.Chars[1].HitPoints.Should().Be(4);
        }

        [Fact]
        public void GivenGameHasStartedWhenRollIsLessThanArmorThenNoDamageIsDealt()
        {
            var game = new EvercraftGame();
            game.Start();

            game.Attack(9, game.Chars[1]);

            game.Chars[1].HitPoints.Should().Be(5);
        }

        [Fact]
        public void GivenGameHasStartedWhenRollIsACriticalHitThenCharacterTakesDoubleDamage()
        {
            var game = new EvercraftGame();
            game.Start();

            game.Attack(20, game.Chars[1]);

            game.Chars[1].HitPoints.Should().Be(3);
        }

        [Fact]
        public void GivenCharacterHasOneHitPointLeftWhenRollIsGreaterThanArmorThenCharacterIsDead()
        {
            var game = new EvercraftGame();
            game.Start();
            game.Attack(11, game.Chars[1]);
            game.Attack(11, game.Chars[1]);
            game.Attack(11, game.Chars[1]);
            game.Attack(11, game.Chars[1]);
            
            game.Attack(11, game.Chars[1]);

            game.Chars[1].HitPoints.Should().Be(0);
            game.IsDead(game.Chars[1]).Should().Be(true);
        }

        [Fact]
        public void GivenGameHasStartedWhenCharacterEquipsBronzeArmorThenCharactersArmorIsDecreasedByOne()
        {
            var game = new EvercraftGame();
            game.Start();

            game.EquipArmor(ArmorType.Bronze, game.Chars[1]);

            game.Chars[1].Armor.Should().Be(9);
        }

        [Fact]
        public void GivenGameHasStartedWhenCharacterEquipsSteelArmorThenCharactersArmorIsIncreasedByOne()
        {
            var game = new EvercraftGame();
            game.Start();

            game.EquipArmor(ArmorType.Steel, game.Chars[1]);

            game.Chars[1].Armor.Should().Be(11);
        }

        [Fact]
        public void GivenGameHasStartedWhenCharacterEquipsIronArmorThenCharactersArmorIsUnchanged()
        {
            var game = new EvercraftGame();
            game.Start();

            game.EquipArmor(ArmorType.Iron, game.Chars[1]);

            game.Chars[1].Armor.Should().Be(10);
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
            game.ApplyStrength(strength, game.Chars[0]);

            game.Attack(9 - modifier, game.Chars[1]);

            game.Chars[1].HitPoints.Should().Be(4);
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
            game.ApplyStrength(strength, game.Chars[0]);

            game.Attack(10 - modifier, game.Chars[1]);

            game.Chars[1].HitPoints.Should().Be(3);
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
            game.ApplyStrength(strength, game.Chars[0]);
            
            game.Attack(10 - modifier, game.Chars[1]);

            game.Chars[1].HitPoints.Should().Be(4 - modifier);
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
            game.ApplyStrength(strength, game.Chars[0]);
            
            game.Attack(9 - modifier, game.Chars[1]);

            game.Chars[1].HitPoints.Should().Be(4);
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
        public void GivenSecondCharacterHasDexterityWithNegativeModifierWhenRollIsGreaterThanModifiedArmorThenSecondCharacterTakesDamage(int dexterity, int modifier)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyDexterity(dexterity, game.Chars[1]);
            
            game.Attack(10 + modifier, game.Chars[1]);

            game.Chars[1].HitPoints.Should().Be(4);
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
        public void GivenSecondCharacterHasDexterityWithNegativeModifierWhenRollIsLessThanModifiedArmorThenSecondCharacterDoesNotTakeDamage(int dexterity, int modifier)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyDexterity(dexterity, game.Chars[1]);
            
            game.Attack(9 + modifier, game.Chars[1]);

            game.Chars[1].HitPoints.Should().Be(5);
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
        public void GivenSecondCharacterHasDexterityWithPositiveModifierWhenRollIsGreaterThanModifiedArmorThenSecondCharacterTakesDamage(int dexterity, int modifier)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyDexterity(dexterity, game.Chars[1]);
            
            game.Attack(10 + modifier, game.Chars[1]);

            game.Chars[1].HitPoints.Should().Be(4);
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
        public void GivenSecondCharacterHasDexterityWithPositiveModifierWhenRollIsLessThanModifiedArmorThenSecondCharacterTakesNoDamage(int dexterity, int modifier)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyDexterity(dexterity, game.Chars[1]);
            
            game.Attack(9 + modifier, game.Chars[1]);

            game.Chars[1].HitPoints.Should().Be(5);
        }

        [Fact]
        public void GivenSecondCharacterHasConstitutionWithNegative_5_ThenCharacterIsNotDeadInitially()
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyConstitution(1, game.Chars[1]);

            game.IsDead(game.Chars[1]).Should().Be(false);
        }
        
        [Fact]
        public void GivenSecondCharacterHasConstitutionWithNegative_5_ModifierWhenRollIsGreaterThanArmorThenSecondCharacterDies()
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyConstitution(1, game.Chars[1]);

            game.Attack(10, game.Chars[1]);
            
            game.IsDead(game.Chars[1]).Should().Be(true);
        }
        
        [Fact]
        public void GivenFirstCharacterHasConstitutionWithNegative_5_ThenCharacterIsNotDeadInitially()
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyConstitution(1, game.Chars[0]);

            game.IsDead(game.Chars[0]).Should().Be(false);
        }
        
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 2)]
        [InlineData(5, 2)]
        [InlineData(6, 3)]
        [InlineData(7, 3)]
        [InlineData(8, 4)]
        [InlineData(9, 4)]
        public void GivenFirstCharacterHasConstitutionWithNegativeModifierWhenRollIsGreaterThanArmorThenFirstCharacterDiesAfterAttacks(int constitution, int attacks)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyConstitution(constitution, game.Chars[0]);

            for (var i = 0; i < attacks; i++)
            {
                game.Attack(10, game.Chars[0]);
            }

            game.IsDead(game.Chars[0]).Should().Be(true);  
        }
        
        [Theory]
        [InlineData(4, 1)]
        [InlineData(5, 1)]
        [InlineData(6, 2)]
        [InlineData(7, 2)]
        [InlineData(8, 3)]
        [InlineData(9, 3)]
        public void GivenFirstCharacterHasConstitutionWithNegativeModifierWhenRollIsGreaterThanArmorThenFirstCharacterIsAliveAfterAttacks(int constitution, int attacks)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyConstitution(constitution, game.Chars[0]);

            for (var i = 0; i < attacks; i++)
            {
                game.Attack(10, game.Chars[0]);
            }

            game.IsDead(game.Chars[0]).Should().Be(false);
        }

        [Theory]
        [InlineData(12, 6)]
        [InlineData(13, 6)]
        [InlineData(14, 7)]
        [InlineData(15, 7)]
        [InlineData(16, 8)]
        [InlineData(17, 8)]
        [InlineData(18, 9)]
        [InlineData(19, 9)]
        [InlineData(20, 10)]
        public void GivenFirstCharacterHasConstitutionWithPositiveModifierWhenRollIsGreaterThanArmorThenFirstCharacterDiesAfterAttacks(int constitution, int attacks)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyConstitution(constitution, game.Chars[0]);

            for (var i = 0; i < attacks; i++)
            {
                game.Attack(10, game.Chars[0]);
            }

            game.IsDead(game.Chars[0]).Should().Be(true);
        }
        
        [Theory]
        [InlineData(12, 5)]
        [InlineData(13, 5)]
        [InlineData(14, 6)]
        [InlineData(15, 6)]
        [InlineData(16, 7)]
        [InlineData(17, 7)]
        [InlineData(18, 8)]
        [InlineData(19, 8)]
        [InlineData(20, 9)]
        public void GivenFirstCharacterHasConstitutionWithPositiveModifierWhenRollIsGreaterThanArmorThenFirstCharacterIsAliveAfterAttacks(int constitution, int attacks)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyConstitution(constitution, game.Chars[0]);

            for (var i = 0; i < attacks; i++)
            {
                game.Attack(10, game.Chars[0]);
            }

            game.IsDead(game.Chars[0]).Should().Be(false);
        }
        
        [Fact]
        public void GivenGameHasStartedWhenSecondCharacterAttacksTheFirstThenFirstCharacterTakesDamage()
        {
            var game = new EvercraftGame();
            game.Start();
            
            game.Attack(10, game.Chars[0]);

            game.Chars[0].HitPoints.Should().Be(4);
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
        public void GivenSecondCharacterHasStrengthWithNegativeModifierWhenRollIsModifiedToBeLessThanArmorThenFirstCharacterTakesOneDamage(int strength, int modifier)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyStrength(strength, game.Chars[1]);

            game.Attack(9 - modifier, game.Chars[0]);

            game.Chars[0].HitPoints.Should().Be(4);
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
        public void GivenSecondCharacterHasStrengthWithNegativeModifierWhenRollIsModifiedToBeGreaterThanArmorThenSecondCharacterTakesTwoDamage(int strength, int modifier)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyStrength(strength, game.Chars[1]);

            game.Attack(10 - modifier, game.Chars[0]);

            game.Chars[0].HitPoints.Should().Be(3);
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
        public void GivenSecondCharacterHasStrengthWithPositiveModifierWhenRollIsModifiedToBeGreaterThanArmorThenSecondCharacterTakesModifierDamage(int strength, int modifier)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyStrength(strength, game.Chars[1]);
            
            game.Attack(10 - modifier, game.Chars[0]);

            game.Chars[0].HitPoints.Should().Be(4 - modifier);
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
        public void GivenSecondCharacterHasStrengthWithPositiveModifierWhenRollIsModifiedToBeLessThanArmorThenSecondCharacterTakesOneDamage(int strength, int modifier)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyStrength(strength, game.Chars[1]);
            
            game.Attack(9 - modifier, game.Chars[0]);

            game.Chars[0].HitPoints.Should().Be(4);
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
        public void GivenFirstCharacterHasDexterityWithNegativeModifierWhenRollIsLessThanModifiedArmorThenFirstCharacterTakesDamage(int dexterity, int modifier)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyDexterity(dexterity, game.Chars[0]);
            
            game.Attack(10 + modifier, game.Chars[0]);

            game.Chars[0].HitPoints.Should().Be(4);
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
        public void GivenFirstCharacterHasDexterityWithNegativeModifierWhenRollIsLessThanModifiedArmorThenFirstCharacterDoesNotTakeDamage(int dexterity, int modifier)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyDexterity(dexterity, game.Chars[0]);
            
            game.Attack(9 + modifier, game.Chars[0]);

            game.Chars[0].HitPoints.Should().Be(5);
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
        public void GivenFirstCharacterHasDexterityWithPositiveModifierWhenRollIsGreaterThanModifiedArmorThenFirstCharacterTakesDamage(int dexterity, int modifier)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyDexterity(dexterity, game.Chars[0]);
            
            game.Attack(10 + modifier, game.Chars[0]);

            game.Chars[0].HitPoints.Should().Be(4);
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
        public void GivenFirstCharacterHasDexterityWithPositiveModifierWhenRollIsLessThanModifiedArmorThenFirstCharacterTakesNoDamage(int dexterity, int modifier)
        {
            var game = new EvercraftGame();
            game.Start();
            game.ApplyDexterity(dexterity, game.Chars[0]);
            
            game.Attack(9 + modifier, game.Chars[0]);

            game.Chars[0].HitPoints.Should().Be(5);
        }
    }
}