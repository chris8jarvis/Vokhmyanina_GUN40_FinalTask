using Vokhmyanina_GUN40_FinalTask.Launcher;

namespace CasinoGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // для видимости подключить namespace лаунчера
            new LaunchCasino().LaunchGame();
        }
    }
    
}
