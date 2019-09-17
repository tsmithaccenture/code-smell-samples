namespace Smelly.Code.Core
{
    public class Character
    {
        public int HitPoints { get; set; }
        public int Armor { get; set; }

        public Character(int hitPoints, int armor)
        {
            HitPoints = hitPoints;
            Armor = armor;
        }
    }
}