using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Lista_3_formularz
{
    public class Heroe
    {
        public static List<Heroe> ListoOfHeroes = new List<Heroe>();
        public string name { get; set; }
        public string type { get; set; }
        public int hp { get; set; }
        public int mana { get; set; }
        public string skill { get; set; }
        public string weapon { get; set; }

        public Heroe(){}
        public Heroe(string name, string type, int hp, int mana, string skill, string weapon)
        {
            this.name = name;
            this.type = type;
            this.hp = hp;
            this.mana = mana;
            this.skill = skill;
            this.weapon = weapon;
        }
        public Heroe(Heroe heroe)
        {
            this.name = heroe.name;
            this.type = heroe.type;
            this.hp = heroe.hp;
            this.mana = heroe.mana;
            this.skill = heroe.skill;
            this.weapon = heroe.weapon;
        }
    }
}