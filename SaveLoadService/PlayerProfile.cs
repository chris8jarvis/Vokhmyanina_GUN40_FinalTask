using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vokhmyanina_GUN40_FinalTask.SaveLoadService
{
    public struct PlayerProfile
    {
        private readonly string Name;
        private readonly int Age; //зачем Age?

        private int Bank {  get; set; }
        public PlayerProfile(string name, int age, int bank)
        {
            Name = name;
            Age = age;
            Bank = bank;
        }
        public void IncreaseBank(int money)
        {
            Bank += money;
        }
        public void DecreaseBank(int money)
        {
            Bank -= money;
        }
    }
}
