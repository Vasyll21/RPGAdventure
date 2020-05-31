using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Enemy : LivingCreature
    {
        public int ID { set; get; }
        public int MaxDmg { set; get; }
        public int RewardExpPoints { set; get; }
        public int RewardGold { set; get; }
        public string Name { set; get; }
        public List<LootItem> LootTable { set; get; }

        internal List<InventoryItem> LootItems { get; }

        public Enemy(int id, string name, int maxDmg, int rewardExpPoints, int rewardGold, int currentHP, int maxHP)
            : base(currentHP, maxHP)
        {
            ID = id;
            Name = name;
            MaxDmg = maxDmg;
            RewardExpPoints = rewardExpPoints;
            RewardGold = rewardGold;
            LootTable = new List<LootItem>();
            LootItems = new List<InventoryItem>();
        }

        internal Enemy NewInstanceOfEnemy()
        {
            Enemy newEnemy =
                new Enemy(ID, Name, MaxDmg, RewardExpPoints, RewardGold, CurrentHP, MaxHP);

            foreach (LootItem lootItem in LootTable.Where(lootItem => RandomNumberGenerator.NumberBetween(1, 100) <= lootItem.DropPercentage))
            {
                newEnemy.LootItems.Add(new InventoryItem(lootItem.Details, 1));
            }

            if (newEnemy.LootItems.Count == 0)
            {
                foreach (LootItem lootItem in LootTable.Where(x => x.IsDefaultItem))
                {
                    newEnemy.LootItems.Add(new InventoryItem(lootItem.Details, 1));
                }
            }

            return newEnemy;
        }
    }
}
