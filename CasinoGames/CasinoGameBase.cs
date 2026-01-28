using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vokhmyanina_GUN40_FinalTask.CasinoGames
{
    public abstract class CasinoGameBase
    {
        public event EventHandler? OnWin; //три события
        public event EventHandler? OnLoose; //EventHandler-стандартный делегат в C# принимающий два параметра
        public event EventHandler? OnDraw;

        protected CasinoGameBase()
        { 
            GameResultsCheck();
        }
        public abstract void PlayGame(); //публичиный абстрактный метод

        protected virtual void OnWinInvoke() //защищенный метод, вызывающий соответствующее событие
        {
            OnWin?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnLooseInvoke()
        {
            OnLoose?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnDrawInvoke()
        {
            OnDraw?.Invoke(this, EventArgs.Empty);
        }
        protected abstract void FactoryMethod(); //защищенный метод, вызывающийся в конструкторе

        protected virtual void GameResultsCheck() //вывод результатов игры в консоль
        {
            OnWin += (sender, args) => Console.WriteLine($"Win!\nGame: {GetType().Name}");
            OnLoose += (sender, args) => Console.WriteLine($"Loose!\nGame: {GetType().Name}");
            OnDraw += (sender, args) => Console.WriteLine($"Draw!\nGame: {GetType().Name}");
        }
    }
}
