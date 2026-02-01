using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vokhmyanina_GUN40_FinalTask.CasinoGames
{
    public abstract class CasinoGameBase
    {
        public abstract event Action OnWin;
        public abstract event Action OnLoose;
        public abstract event Action OnDraw;

        protected CasinoGameBase()
        { 
            // GameResultsCheck();
        }
        public abstract void PlayGame();

        protected abstract void FactoryMethod();

    }
}
