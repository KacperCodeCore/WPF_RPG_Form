using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPF_RPG_Form
{
    public class Heroe
    {
        public static List<Heroe> ListoOfHeroes = new List<Heroe>();
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int hp { get; set; }
        public int mana { get; set; }
        public int skill { get; set; }
        public string weapon { get; set; }
        //public Image image { get; set; }          

        public Heroe(){}
        public Heroe(int id, string name, string type, int hp, int mana, int skill, string weapon)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.hp = hp;
            this.mana = mana;
            this.skill = skill;
            this.weapon = weapon;
        }
        public Heroe(Heroe heroe)
        {
            this.id = heroe.id;
            this.name = heroe.name;
            this.type = heroe.type;
            this.hp = heroe.hp;
            this.mana = heroe.mana;
            this.skill = heroe.skill;
            this.weapon = heroe.weapon;
        }
    }
}