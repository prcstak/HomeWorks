using System;

namespace BL.Battle
{
    public class DiceRolls
    {
        public static int Roll(int sides)
        {
            var r = new Random();
            return r.Next(1, sides+1);
        }
    }
}