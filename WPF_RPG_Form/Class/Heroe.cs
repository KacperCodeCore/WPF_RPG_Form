using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace WPF_RPG_Form
{
    public class Heroe
    {
        public static List<Heroe> ListoOfHeroes = new List<Heroe>();
        public static List<Heroe> ListoOfRemovedHeroes = new List<Heroe>();
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int hp { get; set; }
        public int mana { get; set; }
        public string skill { get; set; }
        public string skill2 { get; set; }
        public string weapon { get; set; }

        public Heroe()
        {
            this.name = "HeroeName";
            this.type = "Paladin";
            this.hp = 100;
            this.mana = 100;
            this.skill = "FireBall";
            this.skill2 = "Teleport";
            this.weapon = "FireStaff";
        }
        public Heroe(int id, string name, string type, int hp, int mana, string skill, string skill2, string weapon)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.hp = hp;
            this.mana = mana;
            this.skill = skill;
            this.skill2 = skill2;
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
            this.skill2 = heroe.skill2;
            this.weapon = heroe.weapon;
        }
    }
}