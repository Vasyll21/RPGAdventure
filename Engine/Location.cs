using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Location
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public Item ItemRequiredToEnter { set; get; }
        public Quest QuestAvailableHere { set; get; }
        public Enemy EnemyLivingHere { set; get; }
        public Location LocationToNorth { set; get; }
        public Location LocationToEast { set; get; }
        public Location LocationToSouth { set; get; }
        public Location LocationToWest { set; get; }
        public Vendor VendorWorkingHere { set; get; }

        public bool HasAQuest { get { return QuestAvailableHere != null; } }
        public bool DoesNotHaveAnItemRequiredToEnter { get { return ItemRequiredToEnter == null; } }

        public Location(int id, string name, string description, Item itemRequiredToEnter = null, Quest questAvailableHere = null, Enemy enemyLivingHere = null)
        {
            ID = id;
            Name = name;
            Description = description;
            ItemRequiredToEnter = itemRequiredToEnter;
            QuestAvailableHere = questAvailableHere;
            EnemyLivingHere = enemyLivingHere;
        }

        public Enemy NewInstanceOfEnemyLivingHere()
        {
            return EnemyLivingHere == null ? null : EnemyLivingHere.NewInstanceOfEnemy();
        }
    }
}
