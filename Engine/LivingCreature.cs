using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class LivingCreature:INotifyPropertyChanged
    {
        private int currentHP;

        public int CurrentHP {
            set
            {
                currentHP = value;
                OnPropertyChanged("CurrentHP");
            }
            get { return currentHP; }
        }
        public int MaxHP { set; get; }

        public bool IsDead { get { return CurrentHP <= 0; } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public LivingCreature(int currentHP, int maxHP)
        {
            CurrentHP = currentHP;
            MaxHP = maxHP;
        }
    }
}
