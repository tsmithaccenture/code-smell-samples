namespace Smelly.Code.Core
{
    public class Character
    {
        public string Name { get; set; }
        public int HitPts { get; set; }
        public int Arm { get; set; }
        public int? Str { get; set; }
        public int? Dex { get; set; }
        public int? Const { get; set; }

        public Character(string name, int hitPts, int arm, int? str, int? dex, int? @const)
        {
            HitPts = hitPts;
            Arm = arm;
            Str = str;
            Dex = dex;
            Const = @const;
            Name = name;
        }
    }
}