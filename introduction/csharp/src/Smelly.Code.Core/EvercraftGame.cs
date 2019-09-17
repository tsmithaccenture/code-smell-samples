using System;

namespace Smelly.Code.Core
{
    public class EvercraftGame
    {
        private int?[] Strength { get; } = {null, null};
        private int?[] Dexterity { get; } = {null, null};
        public Character[] Characters { get; set; }

        public void Start()
        {
            Characters = new[]
            {
                new Character(5, 10),
                new Character(5, 10),
            };
        }

        public void Roll(int roll)
        {
            var strengthModifier = 0;
            var dexterityModifier = 0;
            
            if (Strength[0] == 1)
            {
                strengthModifier = -5;
            } 
            else if (Strength[0] == 2 || Strength[0] == 3)
            {
                strengthModifier = -4;    
            }
            else if (Strength[0] == 4 || Strength[0] == 5)
            {
                strengthModifier = -3;
            }
            else if (Strength[0] == 6 || Strength[0] == 7)
            {
                strengthModifier = -2;
            }
            else if (Strength[0] == 8 || Strength[0] == 9)
            {
                strengthModifier = -1;
            }
            else if (Strength[0] == 12 || Strength[0] == 13)
            {
                strengthModifier = 1;
            }
            else if (Strength[0] == 14 || Strength[0] == 15)
            {
                strengthModifier = 2;
            }
            else if (Strength[0] == 16 || Strength[0] == 17)
            {
                strengthModifier = 3;
            }
            else if (Strength[0] == 18 || Strength[0] == 19)
            {
                strengthModifier = 4;
            }
            else if (Strength[0] == 20)
            {
                strengthModifier = 5;
            }

            if (Dexterity[0] == 1)
            {
                dexterityModifier = -5;
            } 
            else if (Dexterity[0] == 2 || Dexterity[0] == 3)
            {
                dexterityModifier = -4;    
            }
            else if (Dexterity[0] == 4 || Dexterity[0] == 5)
            {
                dexterityModifier = -3;
            }
            else if (Dexterity[0] == 6 || Dexterity[0] == 7)
            {
                dexterityModifier = -2;
            }
            else if (Dexterity[0] == 8 || Dexterity[0] == 9)
            {
                dexterityModifier = -1;
            }
            else if (Dexterity[0] == 12 || Dexterity[0] == 13)
            {
                dexterityModifier = 1;
            }
            else if (Dexterity[0] == 14 || Dexterity[0] == 15)
            {
                dexterityModifier = 2;
            }
            else if (Dexterity[0] == 16 || Dexterity[0] == 17)
            {
                dexterityModifier = 3;
            }
            else if (Dexterity[0] == 18 || Dexterity[0] == 19)
            {
                dexterityModifier = 4;
            }
            else if (Dexterity[0] == 20)
            {
                dexterityModifier = 5;
            }
            
            if (roll + strengthModifier >= Characters[1].Armor + dexterityModifier)
            {
                Characters[1].HitPoints = Characters[1].HitPoints - 1;    
            }

            if (Strength[0].HasValue)
            {
                if (strengthModifier > 0 && roll + strengthModifier >= Characters[1].Armor)
                {
                    Characters[1].HitPoints = Characters[1].HitPoints - strengthModifier;
                }
                else
                {
                    Characters[1].HitPoints = Characters[1].HitPoints - 1;
                }
            }
            

            if (roll == 20)
            {
                Characters[1].HitPoints = Characters[1].HitPoints - 1;
            }
        }

        public bool IsDead(Character character)
        {
            return character.HitPoints == 0;
        }

        public void EquipArmor(ArmorType armorType, Character character)
        {
            switch (armorType)
            {
                case ArmorType.Bronze:
                    character.Armor = character.Armor - 1;
                    break;
                case ArmorType.Steel:
                    character.Armor = character.Armor + 1;
                    break;
            }
        }

        public void ApplyStrength(int strength, Character character)
        {
            Strength[0] = strength;
        }

        public void ApplyDexterity(int dexterity, Character character)
        {
            Dexterity[0] = dexterity;
        }
    }
}