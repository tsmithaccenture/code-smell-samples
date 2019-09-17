using System;

namespace Smelly.Code.Core
{
    public class EvercraftGame
    {
        private int?[] StrengthModifiers { get; } = {null, null};
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
            if (roll + StrengthModifiers[0].GetValueOrDefault() >= Characters[1].Armor)
            {
                Characters[1].HitPoints--;    
            }

            if (StrengthModifiers[0].HasValue)
            {
                if (StrengthModifiers[0].GetValueOrDefault() > 0 && roll + StrengthModifiers[0].GetValueOrDefault() >= Characters[1].Armor)
                {
                    Characters[1].HitPoints -= StrengthModifiers[0].GetValueOrDefault();
                }
                else
                {
                    Characters[1].HitPoints--;    
                }
            }
            

            if (roll == 20)
            {
                Characters[1].HitPoints--;
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
                    character.Armor--;
                    break;
                case ArmorType.Steel:
                    character.Armor++;
                    break;
            }
        }

        public void ApplyStrength(int strength, Character character)
        {
            if (strength == 1)
            {
                StrengthModifiers[0] = -5;
            } 
            else if (strength == 2 || strength == 3)
            {
                StrengthModifiers[0] = -4;    
            }
            else if (strength == 4 || strength == 5)
            {
                StrengthModifiers[0] = -3;
            }
            else if (strength == 6 || strength == 7)
            {
                StrengthModifiers[0] = -2;
            }
            else if (strength == 8 || strength == 9)
            {
                StrengthModifiers[0] = -1;
            }
            else if (strength == 12 || strength == 13)
            {
                StrengthModifiers[0] = 1;
            }
            else if (strength == 14 || strength == 15)
            {
                StrengthModifiers[0] = 2;
            }
            else if (strength == 16 || strength == 17)
            {
                StrengthModifiers[0] = 3;
            }
            else if (strength == 18 || strength == 19)
            {
                StrengthModifiers[0] = 4;
            }
            else if (strength == 20)
            {
                StrengthModifiers[0] = 5;
            }
        }
    }
}