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

        // попробовать ограничение по макс добавить в сетер. и наверное в конструкторе и в Инкрисе невозможно будет
        // ввести больше максимума
        // так же, так как у нас есть IncreaseBank и DecreaseBank, кажется что сеттер не может быть публичным
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

        // 1. Формат именования констант
        // 2. Проверка на максимальный банк
        // 3. Добавить процедуру для kick out (но не обязательно сейчас, возможно когда само казино и необходимость появится)
    }
}
