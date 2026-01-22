using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vokhmyanina_GUN40_FinalTask.SaveLoadService
{
    public interface ISaveLoadService<T>
    {
        void SaveData (T data, string id);
        T LoadData(string id);

    }
}
