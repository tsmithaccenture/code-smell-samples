using System;
using System.IO;
using System.Linq;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json.Linq;

namespace Smelly.Code.Core
{
    public class EvercraftGame
    {
        public bool[] Attacked { get; } = {false, false};
        public Character[] Chars { get; set; } = {null, null};

        public void Start(string charOne = "Jack", string charTwo = "Bob")
        {
            Chars = new[]
            {
                new Character(charOne, 5, 10, null, null, null),
                new Character(charTwo, 5, 10, null, null, null),
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
                if (Chars[0].Str == 1)
                {
                    sM = -5;
                }
                else if (Chars[0].Str == 2 || Chars[0].Str == 3)
                {
                    sM = -4;
                }
                else if (Chars[0].Str == 4 || Chars[0].Str == 5)
                {
                    sM = -3;
                }
                else if (Chars[0].Str == 6 || Chars[0].Str == 7)
                {
                    sM = -2;
                }
                else if (Chars[0].Str == 8 || Chars[0].Str == 9)
                {
                    sM = -1;
                }
                else if (Chars[0].Str == 12 || Chars[0].Str == 13)
                {
                    sM = 1;
                }
                else if (Chars[0].Str == 14 || Chars[0].Str == 15)
                {
                    sM = 2;
                }
                else if (Chars[0].Str == 16 || Chars[0].Str == 17)
                {
                    sM = 3;
                }
                else if (Chars[0].Str == 18 || Chars[0].Str == 19)
                {
                    sM = 4;
                }
                else if (Chars[0].Str == 20)
                {
                    sM = 5;
                }

                if (Chars[1].Dex == 1)
                {
                    dM = -5;
                }
                else if (Chars[1].Dex == 2 || Chars[1].Dex == 3)
                {
                    dM = -4;
                }
                else if (Chars[1].Dex == 4 || Chars[1].Dex == 5)
                {
                    dM = -3;
                }
                else if (Chars[1].Dex == 6 || Chars[1].Dex == 7)
                {
                    dM = -2;
                }
                else if (Chars[1].Dex == 8 || Chars[1].Dex == 9)
                {
                    dM = -1;
                }
                else if (Chars[1].Dex == 12 || Chars[1].Dex == 13)
                {
                    dM = 1;
                }
                else if (Chars[1].Dex == 14 || Chars[1].Dex == 15)
                {
                    dM = 2;
                }
                else if (Chars[1].Dex == 16 || Chars[1].Dex == 17)
                {
                    dM = 3;
                }
                else if (Chars[1].Dex == 18 || Chars[1].Dex == 19)
                {
                    dM = 4;
                }
                else if (Chars[1].Dex == 20)
                {
                    dM = 5;
                }

                if (roll + sM >= Chars[1].Arm + dM)
                {
                    Chars[1].HitPts = Chars[1].HitPts - 1;
                }

                if (Chars[0].Str.HasValue)
                {
                    if (sM > 0 && roll + sM >= Chars[1].Arm)
                    {
                        Chars[1].HitPts = Chars[1].HitPts - sM;
                    }
                    else
                    {
                        Chars[1].HitPts = Chars[1].HitPts - 1;
                    }
                }


                if (roll == 20)
                {
                    Chars[1].HitPts = Chars[1].HitPts - 1;
                }
            }
            else
            {
                Attacked[0] = true;
                if (Chars[1].Str == 1)
                {
                    sM = -5;
                }
                else if (Chars[1].Str == 2 || Chars[1].Str == 3)
                {
                    sM = -4;
                }
                else if (Chars[1].Str == 4 || Chars[1].Str == 5)
                {
                    sM = -3;
                }
                else if (Chars[1].Str == 6 || Chars[1].Str == 7)
                {
                    sM = -2;
                }
                else if (Chars[1].Str == 8 || Chars[1].Str == 9)
                {
                    sM = -1;
                }
                else if (Chars[1].Str == 12 || Chars[1].Str == 13)
                {
                    sM = 1;
                }
                else if (Chars[1].Str == 14 || Chars[1].Str == 15)
                {
                    sM = 2;
                }
                else if (Chars[1].Str == 16 || Chars[1].Str == 17)
                {
                    sM = 3;
                }
                else if (Chars[1].Str == 18 || Chars[1].Str == 19)
                {
                    sM = 4;
                }
                else if (Chars[1].Str == 20)
                {
                    sM = 5;
                }
                
                if (Chars[0].Dex == 1)
                {
                    dM = -5;
                }
                else if (Chars[0].Dex == 2 || Chars[0].Dex == 3)
                {
                    dM = -4;
                }
                else if (Chars[0].Dex == 4 || Chars[0].Dex == 5)
                {
                    dM = -3;
                }
                else if (Chars[0].Dex == 6 || Chars[0].Dex == 7)
                {
                    dM = -2;
                }
                else if (Chars[0].Dex == 8 || Chars[0].Dex == 9)
                {
                    dM = -1;
                }
                else if (Chars[0].Dex == 12 || Chars[0].Dex == 13)
                {
                    dM = 1;
                }
                else if (Chars[0].Dex == 14 || Chars[0].Dex == 15)
                {
                    dM = 2;
                }
                else if (Chars[0].Dex == 16 || Chars[0].Dex == 17)
                {
                    dM = 3;
                }
                else if (Chars[0].Dex == 18 || Chars[0].Dex == 19)
                {
                    dM = 4;
                }
                else if (Chars[0].Dex == 20)
                {
                    dM = 5;
                }
                
                if (roll + sM >= Chars[0].Arm + dM)
                {
                    Chars[0].HitPts = Chars[0].HitPts - 1;
                }
                
                if (Chars[1].Str.HasValue)
                {
                    if (sM > 0 && roll + sM >= Chars[0].Arm)
                    {
                        Chars[0].HitPts = Chars[0].HitPts - sM;
                    }
                    else
                    {
                        Chars[0].HitPts = Chars[0].HitPts - 1;
                    }
                }
            }
        }

        public bool IsDead(Character character)
        {
            var charIndex = Array.IndexOf(Chars, character);
            var hitPoints = character.HitPts;
            var hM = 0;
            if (Chars[charIndex].Const.HasValue)
            {
                if (Chars[charIndex].Const == 1)
                {
                    hM = -5;
                }
                else if (Chars[charIndex].Const == 2 || Chars[charIndex].Const == 3)
                {
                    hM = -4;
                }
                else if (Chars[charIndex].Const == 4 || Chars[charIndex].Const == 5)
                {
                    hM = -3;
                }
                else if (Chars[charIndex].Const == 6 || Chars[charIndex].Const == 7)
                {
                    hM = -2;
                }
                else if (Chars[charIndex].Const == 8 || Chars[charIndex].Const == 9)
                {
                    hM = -1;
                }
                else if (Chars[charIndex].Const == 12 || Chars[charIndex].Const == 13)
                {
                    hM = 1;
                }
                else if (Chars[charIndex].Const == 14 || Chars[charIndex].Const == 15)
                {
                    hM = 2;
                }
                else if (Chars[charIndex].Const == 16 || Chars[charIndex].Const == 17)
                {
                    hM = 3;
                }
                else if (Chars[charIndex].Const == 18 || Chars[charIndex].Const == 19)
                {
                    hM = 4;
                }
                else if (Chars[charIndex].Const == 20)
                {
                    hM = 5;
                }
            }
            return hitPoints + hM <= 0 && Attacked[charIndex];
        }

        public void EquipArmor(ArmorType armorType, int weight, Character character)
        {
            switch (armorType)
            {
                case ArmorType.Bronze:
                    character.Arm = character.Arm - 1;
                    break;
                case ArmorType.Steel:
                    character.Arm = character.Arm + 1;
                    break;
            }

            if (weight > 50)
            {
                character.Arm = character.Arm + 2;
            }
        }

        public void ApplyStrength(int strength, Character character)
        {
            var charIndex = Array.IndexOf(Chars, character);
            Chars[charIndex].Str = strength;
        }

        public void ApplyDexterity(int dexterity, Character character)
        {
            var charIndex = Array.IndexOf(Chars, character);
            Chars[charIndex].Dex = dexterity;
        }

        public void ApplyConstitution(int constitution, Character character)
        {
            var charIndex = Array.IndexOf(Chars, character);
            Chars[charIndex].Const = constitution;
        }

        public void Load(string filePath)
        {
            if (filePath.EndsWith(".json"))
            {
                var jObject = JObject.Parse(File.ReadAllText(filePath));
                var characters = jObject.Value<JArray>("characters");
                for (var i = 0; i < characters.Count; i++)
                {
                    Chars[i] = new Character(characters[i].Value<string>("name"), 5, characters[i].Value<int>("arm"), characters[i].Value<int>("str"), characters[i].Value<int>("dex"), characters[i].Value<int>("const"));
                }
            }
            else if (filePath.EndsWith(".db"))
            {
                using (var connection = new SqliteConnection($"Data Source={filePath}"))
                {
                    connection.Open();
                    
                    var selectCharactersText = "select [Name], Armor, Str, Dex, Const from [Characters]";
                    using (var command = new SqliteCommand(selectCharactersText, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            var current = 0;
                            while (reader.Read())
                            {
                                Chars[current] = new Character(reader.GetFieldValue<string>(0), 5, reader.GetFieldValue<int>(1), reader.GetFieldValue<int>(2), reader.GetFieldValue<int>(3), reader.GetFieldValue<int>(4));
                                current = current + 1;
                            }
                        }    
                    }
                }
            }
            else
            {
                var lines = File.ReadAllLines(filePath)
                    .Skip(1)
                    .ToArray();
                for (var i = 0; i < lines.Length; i++)
                {
                    var vs = lines[i].Split(',');
                    Chars[i] = new Character(vs[0], 5, int.Parse(vs[1]), int.Parse(vs[2]), int.Parse(vs[3]), int.Parse(vs[4]));
                }
            }
        }
    }
}