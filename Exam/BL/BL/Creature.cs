using System;
using BL;

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

    public static Creature ToCreature(Hero hero)
    {
        var damage = hero.Damage.Split("d");
        var result = new Creature()
        {
            UserName = hero.UserName,
            HitPoints = hero.HitPoints,
            AttackModifier = hero.AttackModifier,
            AttackPerRound = hero.AttackPerRound,
            Dice = Convert.ToInt32(damage[1]),
            Damage = Convert.ToInt32(damage[0]),
            Weapon = hero.Weapon,
            DamageModifier = hero.DamageModifier,
            AC = hero.AC
        };
        return result;
    }
}