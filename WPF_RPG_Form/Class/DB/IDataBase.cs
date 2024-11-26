using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Lista_3_formularz.Class.DB
{
    public interface IDataBase
    {
        void ConectHeroe();
        void UpdateHeroe(int id, string name, string type, int hp, int mana, string skill, string skill2, string weapon, int lvl);
        void DeleteHeroe(int id);
        void AddHeroe(string name, string type, int hp, int mana, string skill, string skill2, string weapon, int lvl);
        void ConectRemovedHeroe();
        void AddDeletedHeroe(string name, string type, int hp, int mana, string skill, string skill2, string weapon, int lvl);
        void MoveFromRemovedToHeroe(int id);
        void DeleteRemovedHeroe(int id);
    }

}
