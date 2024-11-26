using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_RPG_Form;

namespace P_Lista_3_formularz.Class.DB
{
    internal class TestDataBase : IDataBase
    {
        public void ConectHeroe()
        {

                //var newHeroe = new Heroe(
                //    12,
                //    "12",
                //    "32323",
                //    2,
                //    1,
                //    "2323",
                //    "2323",
                //    "2323",
                //    2;
                //Heroe.ListoOfHeroes.Add(newHeroe);
            

        }
    
        public void AddDeletedHeroe(string name, string type, int hp, int mana, string skill, string skill2, string weapon, int lvl)
        {
            throw new NotImplementedException();
        }

        public void AddHeroe(string name, string type, int hp, int mana, string skill, string skill2, string weapon, int lvl)
        {
            throw new NotImplementedException();
        }


        public void ConectRemovedHeroe()
        {
            throw new NotImplementedException();
        }

        public void DeleteHeroe(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteRemovedHeroe(int id)
        {
            throw new NotImplementedException();
        }

        public void MoveFromRemovedToHeroe(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateHeroe(int id, string name, string type, int hp, int mana, string skill, string skill2, string weapon, int lvl)
        {
            throw new NotImplementedException();
        }
    }
}
