using System;
using System.Numerics;

namespace BL.Battle
{
    public class Battle
    {
        private static Creature Monster { get; set; }
        private static Creature Hero { get; set; }

        public Battle(Creature monster, Hero hero)
        {
            Monster = monster;
            Hero = Creature.ToCreature(hero);;
        }

        public Log Fighting()
        {
            var log = new Log();
            while (Hero.HitPoints > 0 && Monster.HitPoints > 0)
            {
                log = Round(log);
            }
            if(Hero.HitPoints > 0) 
                log.steps.Add($"{Hero.UserName} победил");
            else
                log.steps.Add($"{Monster.UserName} победил");
            return log;
        }

        public Log Round(Log log)
        {
            var playerAttackPerRound = Hero.AttackPerRound;
            var monsterAttackPerRound = Monster.AttackPerRound;

            while (playerAttackPerRound != 0)
            {
                if (Monster.HitPoints == 0)
                    return log;
                var damage = Damage(Hero, Monster);
                if (damage > Monster.HitPoints)
                {
                    Monster.HitPoints = 0;
                }
                else
                {
                    Monster.HitPoints -= damage;
                }
                log.steps.Add($"{Monster.UserName} Hit: {Monster.HitPoints} <-- damage: {damage} <-- {Hero.UserName} Hit: {Hero.HitPoints}");
                playerAttackPerRound--;
            }
            while (monsterAttackPerRound != 0)
            {
                if (Hero.HitPoints == 0)
                    return log;
                var damage = Damage(Monster, Hero);
                if (damage > Hero.HitPoints)
                {
                    Hero.HitPoints = 0;
                }
                else
                {
                    Hero.HitPoints -= damage;
                }
                log.steps.Add($"{Monster.UserName} Hit: {Monster.HitPoints} --> damage: {damage} --> {Hero.UserName} Hit: {Hero.HitPoints}");
                monsterAttackPerRound--;
            }

            return log;
        }

        public static int Damage(Creature attack, Creature defend)
        {
            var roll = DiceRolls.Roll(20);
            if (roll == 1)
                return 0;
            if (roll + attack.AttackModifier < defend.AC)
            {
                return 0;
            }
            var damage = DiceRolls.Roll(attack.Dice) + attack.DamageModifier + attack.Weapon;
            return damage;
        }
    }
}