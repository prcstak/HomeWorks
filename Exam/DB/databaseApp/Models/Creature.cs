namespace databaseApp.Models
{
    public class Creature
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int HitPoints { get; set; }
        public int AttackModifier { get; set; }
        public int AttackPerRound { get; set; }
        public int Dice { get; set; }
        public int Damage { get; set; }
        public int Weapon { get; set; }
        public int DamageModifier { get; set; }
        public int AC { get; set; }
    }
}