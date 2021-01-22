using System;

namespace L2P_RPG_GOI.Models
{
    public class Attack
    {
        public string Name { get; set; }
        public int ActionPointCost { get; set; }
        public int DoDamage(int modifier)
        {
            var random = new Random();
            var damage = modifier / random.Next(8, 13) * ActionPointCost / 2;
            return damage;
        }
    }
}
