using System;

namespace Smelly.Code.Core
{
    public class EvercraftGame
    {
        private int?[] Str { get; } = {null, null};
        private int?[] Dex { get; } = {null, null};
        public int?[] Const { get; } = {null, null};
        public bool[] Attacked { get; } = {false, false};
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

            if (charIndex != 0)
            {
                Attacked[1] = true;
                if (Str[0] == 1)
                {
                    sM = -5;
                }
                else if (Str[0] == 2 || Str[0] == 3)
                {
                    sM = -4;
                }
                else if (Str[0] == 4 || Str[0] == 5)
                {
                    sM = -3;
                }
                else if (Str[0] == 6 || Str[0] == 7)
                {
                    sM = -2;
                }
                else if (Str[0] == 8 || Str[0] == 9)
                {
                    sM = -1;
                }
                else if (Str[0] == 12 || Str[0] == 13)
                {
                    sM = 1;
                }
                else if (Str[0] == 14 || Str[0] == 15)
                {
                    sM = 2;
                }
                else if (Str[0] == 16 || Str[0] == 17)
                {
                    sM = 3;
                }
                else if (Str[0] == 18 || Str[0] == 19)
                {
                    sM = 4;
                }
                else if (Str[0] == 20)
                {
                    sM = 5;
                }

                if (Dex[1] == 1)
                {
                    dM = -5;
                }
                else if (Dex[1] == 2 || Dex[1] == 3)
                {
                    dM = -4;
                }
                else if (Dex[1] == 4 || Dex[1] == 5)
                {
                    dM = -3;
                }
                else if (Dex[1] == 6 || Dex[1] == 7)
                {
                    dM = -2;
                }
                else if (Dex[1] == 8 || Dex[1] == 9)
                {
                    dM = -1;
                }
                else if (Dex[1] == 12 || Dex[1] == 13)
                {
                    dM = 1;
                }
                else if (Dex[1] == 14 || Dex[1] == 15)
                {
                    dM = 2;
                }
                else if (Dex[1] == 16 || Dex[1] == 17)
                {
                    dM = 3;
                }
                else if (Dex[1] == 18 || Dex[1] == 19)
                {
                    dM = 4;
                }
                else if (Dex[1] == 20)
                {
                    dM = 5;
                }

                if (roll + sM >= Chars[1].Armor + dM)
                {
                    Chars[1].HitPoints = Chars[1].HitPoints - 1;
                }

                if (Str[0].HasValue)
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
                Attacked[0] = true;
                if (Str[1] == 1)
                {
                    sM = -5;
                }
                else if (Str[1] == 2 || Str[1] == 3)
                {
                    sM = -4;
                }
                else if (Str[1] == 4 || Str[1] == 5)
                {
                    sM = -3;
                }
                else if (Str[1] == 6 || Str[1] == 7)
                {
                    sM = -2;
                }
                else if (Str[1] == 8 || Str[1] == 9)
                {
                    sM = -1;
                }
                else if (Str[1] == 12 || Str[1] == 13)
                {
                    sM = 1;
                }
                else if (Str[1] == 14 || Str[1] == 15)
                {
                    sM = 2;
                }
                else if (Str[1] == 16 || Str[1] == 17)
                {
                    sM = 3;
                }
                else if (Str[1] == 18 || Str[1] == 19)
                {
                    sM = 4;
                }
                else if (Str[1] == 20)
                {
                    sM = 5;
                }
                
                if (Dex[0] == 1)
                {
                    dM = -5;
                }
                else if (Dex[0] == 2 || Dex[0] == 3)
                {
                    dM = -4;
                }
                else if (Dex[0] == 4 || Dex[0] == 5)
                {
                    dM = -3;
                }
                else if (Dex[0] == 6 || Dex[0] == 7)
                {
                    dM = -2;
                }
                else if (Dex[0] == 8 || Dex[0] == 9)
                {
                    dM = -1;
                }
                else if (Dex[0] == 12 || Dex[0] == 13)
                {
                    dM = 1;
                }
                else if (Dex[0] == 14 || Dex[0] == 15)
                {
                    dM = 2;
                }
                else if (Dex[0] == 16 || Dex[0] == 17)
                {
                    dM = 3;
                }
                else if (Dex[0] == 18 || Dex[0] == 19)
                {
                    dM = 4;
                }
                else if (Dex[0] == 20)
                {
                    dM = 5;
                }
                
                if (roll + sM >= Chars[0].Armor + dM)
                {
                    Chars[0].HitPoints = Chars[0].HitPoints - 1;
                }
                
                if (Str[1].HasValue)
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
            var charIndex = Array.IndexOf(Chars, character);
            var hitPoints = character.HitPoints;
            var hM = 0;
            if (Const[charIndex].HasValue)
            {
                if (Const[charIndex] == 1)
                {
                    hM = -5;
                }
                else if (Const[charIndex] == 2 || Const[charIndex] == 3)
                {
                    hM = -4;
                }
                else if (Const[charIndex] == 4 || Const[charIndex] == 5)
                {
                    hM = -3;
                }
                else if (Const[charIndex] == 6 || Const[charIndex] == 7)
                {
                    hM = -2;
                }
                else if (Const[charIndex] == 8 || Const[charIndex] == 9)
                {
                    hM = -1;
                }
                else if (Const[charIndex] == 12 || Const[charIndex] == 13)
                {
                    hM = 1;
                }
                else if (Const[charIndex] == 14 || Const[charIndex] == 15)
                {
                    hM = 2;
                }
                else if (Const[charIndex] == 16 || Const[charIndex] == 17)
                {
                    hM = 3;
                }
                else if (Const[charIndex] == 18 || Const[charIndex] == 19)
                {
                    hM = 4;
                }
                else if (Const[charIndex] == 20)
                {
                    hM = 5;
                }
            }
            return hitPoints + hM <= 0 && Attacked[charIndex];
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
            Str[charIndex] = strength;
        }

        public void ApplyDexterity(int dexterity, Character character)
        {
            var charIndex = Array.IndexOf(Chars, character);
            Dex[charIndex] = dexterity;
        }

        public void ApplyConstitution(int constitution, Character character)
        {
            var charIndex = Array.IndexOf(Chars, character);
            Const[charIndex] = constitution;
        }
    }
}