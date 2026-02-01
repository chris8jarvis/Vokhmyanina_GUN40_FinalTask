using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vokhmyanina_GUN40_FinalTask.Profile
{
    public class PlayerProfile
    {

        private const int MAX_BANK = 1000000;

        private int _bank;

        public string Name { get; private set; }

        public int Bank => _bank;

        public PlayerProfile(string name, int bank)
        {
            Name = name;
            _bank = bank;
        }

        public void IncreaseBank(int amount)
        {
            _bank += amount;
            if (_bank > MAX_BANK)
            {
                _bank = MAX_BANK;
            }
        }

        public void DecreaseBank(int amount)
        {
            _bank -= amount;
        }
    }
}
