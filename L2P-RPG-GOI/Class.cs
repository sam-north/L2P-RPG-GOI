using System.Collections.Generic;

namespace L2P_RPG_GOI
{
    public class Class
    {
        public Class(string name)
        {
            Name = name;

            if (Name == "Warrior")
            {
                Attacks.Add(new Attack
                {
                    Name = "Punch",
                    ActionPointCost = 2
                });
                Attacks.Add(new Attack
                {
                    Name = "Kick",
                    ActionPointCost = 3
                });
                Attacks.Add(new Attack
                {
                    Name = "Destroy",
                    ActionPointCost = 6
                });
            }
            else if (Name == "Archer")
            {
                Attacks.Add(new Attack
                {
                    Name = "Shoot",
                    ActionPointCost = 4
                });
                Attacks.Add(new Attack
                {
                    Name = "Snipe",
                    ActionPointCost = 8
                });
                Attacks.Add(new Attack
                {
                    Name = "Obliterate",
                    ActionPointCost = 10
                });
            }
            else if (Name == "Mage")
            {
                Attacks.Add(new Attack
                {
                    Name = "Fireball",
                    ActionPointCost = 3
                });
                Attacks.Add(new Attack
                {
                    Name = "Iceshard",
                    ActionPointCost = 1
                });
                Attacks.Add(new Attack
                {
                    Name = "Mind Fuck",
                    ActionPointCost = 7
                });
            }
        }


        public string Name { get; set; }
        public List<Attack> Attacks { get; set; } = new List<Attack>();
    }

    //var warriorClass = new Class("Warrior");



    //warriorClass.Attacks.Add("hit");
    //warriorClass.Attacks.Add("kick");
    //   { "hit", "kick" }


    //var attack = new Attack();
    //attack.Name = "Kick";
    //attack.APCost = 12;
    //attack.DoDamage = some shit we haven't done yet;

    //warriorClass.Attacks.Add(attack);
}
