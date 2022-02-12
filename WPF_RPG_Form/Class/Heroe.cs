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

        //private BitmapSource? _image;
        //[XmlIgnore]
        //public BitmapSource? Image
        //{
        //    get { return _image; }
        //    set { _image = value; }
        //}

        //[XmlElement("Image")]
        //public byte[]? ImageBuffer
        //{
        //    get
        //    {
        //        byte[]? imageBuffer = null;

        //        if (Image != null)
        //        {
        //            using (var stream = new MemoryStream())
        //            {
        //                var encoder = new PngBitmapEncoder();
        //                encoder.Frames.Add(BitmapFrame.Create(Image));
        //                encoder.Save(stream);
        //                imageBuffer = stream.ToArray();
        //            }
        //        }

        //        return imageBuffer;
        //    }
        //    set
        //    {
        //        if (value == null)
        //        {
        //            Image = null;
        //        }
        //        else
        //        {
        //            using (var stream = new MemoryStream(value))
        //            {
        //                var decoder = BitmapDecoder.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
        //                Image = decoder.Frames[0];
        //            }
        //        }
        //    }
        //}

        public Heroe()
        {
            this.name = "HeroeName";
            this.type = "Paladin+1000HP";
            this.hp = 1000;
            this.mana = 1000;
            this.skill = "Shield";
            this.skill2 = "Strike";
            this.weapon = "Sword";
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