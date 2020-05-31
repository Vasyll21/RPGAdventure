using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Quest
    {
        public int ID { set; get; }
        public int RewardExpPoints { set; get; }
        public int RewardGold { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public Item RewardItem { set; get; }
        public List<QuestCompletionItem> QuestCompletionItems { set; get; }

        public Quest(int id, string name, string description, int rewardExpPoints, int rewardGold)
        {
            ID = id;
            Name = name;
            Description = description;
            RewardExpPoints = rewardExpPoints;
            RewardGold = rewardGold;

            QuestCompletionItems = new List<QuestCompletionItem>();
        }
    }
}
