using System;

namespace Smelly.Code.Core
{
    public class EvercraftGame
    {
        private int?[] Strength { get; } = {null, null};
        private int?[] Dexterity { get; } = {null, null};
        public Character[] Chars { get; set; }

        public void Start()
        {
            Chars = new[]
            {
                new Character(5, 10),
                new Character(5, 10),
            };
        }

        public void Attack(int roll, Character character)
        {
            var sM = 0;
            var dM = 0;
            var charIndex = Array.IndexOf(Chars, character);

            if (charIndex == 0)
            {
                if (Strength[0] == 1)
                {
                    sM = -5;
                }
                else if (Strength[0] == 2 || Strength[0] == 3)
                {
                    sM = -4;
                }
                else if (Strength[0] == 4 || Strength[0] == 5)
                {
                    sM = -3;
                }
                else if (Strength[0] == 6 || Strength[0] == 7)
                {
                    sM = -2;
                }
                else if (Strength[0] == 8 || Strength[0] == 9)
                {
                    sM = -1;
                }
                else if (Strength[0] == 12 || Strength[0] == 13)
                {
                    sM = 1;
                }
                else if (Strength[0] == 14 || Strength[0] == 15)
                {
                    sM = 2;
                }
                else if (Strength[0] == 16 || Strength[0] == 17)
                {
                    sM = 3;
                }
                else if (Strength[0] == 18 || Strength[0] == 19)
                {
                    sM = 4;
                }
                else if (Strength[0] == 20)
                {
                    sM = 5;
                }

                if (Dexterity[1] == 1)
                {
                    dM = -5;
                }
                else if (Dexterity[1] == 2 || Dexterity[1] == 3)
                {
                    dM = -4;
                }
                else if (Dexterity[1] == 4 || Dexterity[1] == 5)
                {
                    dM = -3;
                }
                else if (Dexterity[1] == 6 || Dexterity[1] == 7)
                {
                    dM = -2;
                }
                else if (Dexterity[1] == 8 || Dexterity[1] == 9)
                {
                    dM = -1;
                }
                else if (Dexterity[1] == 12 || Dexterity[1] == 13)
                {
                    dM = 1;
                }
                else if (Dexterity[1] == 14 || Dexterity[1] == 15)
                {
                    dM = 2;
                }
                else if (Dexterity[1] == 16 || Dexterity[1] == 17)
                {
                    dM = 3;
                }
                else if (Dexterity[1] == 18 || Dexterity[1] == 19)
                {
                    dM = 4;
                }
                else if (Dexterity[1] == 20)
                {
                    dM = 5;
                }

                if (roll + sM >= Chars[1].Armor + dM)
                {
                    Chars[1].HitPoints = Chars[1].HitPoints - 1;
                }

                if (Strength[0].HasValue)
                {
                    if (sM > 0 && roll + sM >= Chars[1].Armor)
                    {
                        Chars[1].HitPoints = Chars[1].HitPoints - sM;
                    }
                    else
                    {
                        Chars[1].HitPoints = Chars[1].HitPoints - 1;
                    }
                }


                if (roll == 20)
                {
                    Chars[1].HitPoints = Chars[1].HitPoints - 1;
                }
            }
            else
            {
                if (Strength[1] == 1)
                {
                    sM = -5;
                }
                else if (Strength[1] == 2 || Strength[1] == 3)
                {
                    sM = -4;
                }
                else if (Strength[1] == 4 || Strength[1] == 5)
                {
                    sM = -3;
                }
                else if (Strength[1] == 6 || Strength[1] == 7)
                {
                    sM = -2;
                }
                else if (Strength[1] == 8 || Strength[1] == 9)
                {
                    sM = -1;
                }
                else if (Strength[1] == 12 || Strength[1] == 13)
                {
                    sM = 1;
                }
                else if (Strength[1] == 14 || Strength[1] == 15)
                {
                    sM = 2;
                }
                else if (Strength[1] == 16 || Strength[1] == 17)
                {
                    sM = 3;
                }
                else if (Strength[1] == 18 || Strength[1] == 19)
                {
                    sM = 4;
                }
                else if (Strength[1] == 20)
                {
                    sM = 5;
                }
                
                if (Dexterity[0] == 1)
                {
                    dM = -5;
                }
                else if (Dexterity[0] == 2 || Dexterity[0] == 3)
                {
                    dM = -4;
                }
                else if (Dexterity[0] == 4 || Dexterity[0] == 5)
                {
                    dM = -3;
                }
                else if (Dexterity[0] == 6 || Dexterity[0] == 7)
                {
                    dM = -2;
                }
                else if (Dexterity[0] == 8 || Dexterity[0] == 9)
                {
                    dM = -1;
                }
                else if (Dexterity[0] == 12 || Dexterity[0] == 13)
                {
                    dM = 1;
                }
                else if (Dexterity[0] == 14 || Dexterity[0] == 15)
                {
                    dM = 2;
                }
                else if (Dexterity[0] == 16 || Dexterity[0] == 17)
                {
                    dM = 3;
                }
                else if (Dexterity[0] == 18 || Dexterity[0] == 19)
                {
                    dM = 4;
                }
                else if (Dexterity[0] == 20)
                {
                    dM = 5;
                }
                
                if (roll + sM >= Chars[0].Armor + dM)
                {
                    Chars[0].HitPoints = Chars[0].HitPoints - 1;
                }
                
                if (Strength[1].HasValue)
                {
                    if (sM > 0 && roll + sM >= Chars[0].Armor)
                    {
                        Chars[0].HitPoints = Chars[0].HitPoints - sM;
                    }
                    else
                    {
                        Chars[0].HitPoints = Chars[0].HitPoints - 1;
                    }
                }
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
            var charIndex = Array.IndexOf(Chars, character);
            Strength[charIndex] = strength;
        }

        public void ApplyDexterity(int dexterity, Character character)
        {
            var charIndex = Array.IndexOf(Chars, character);
            Dexterity[charIndex] = dexterity;
        }
    }
}