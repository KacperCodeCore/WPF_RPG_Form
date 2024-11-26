using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_RPG_Form
{
    internal class DataBase
    {
        static int id;
        //public DataBase()
        //{
        //}

        private SqlCommand Conect(string query)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MYCOREOFUNIVERS;Initial Catalog=heroedb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            return cmd;
        }

        private void Disconect(SqlCommand cmd)
        {
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Connection.Close();
            }
            cmd.Dispose();
        }
        public void LoadAllHeroes()
        {
            SqlCommand cmd = Conect("selectheroe");

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var newHeroe = new Heroe(
                    Convert.ToInt32(reader.GetValue(0)),
                    reader.GetValue(1).ToString(),
                    reader.GetValue(2).ToString(),
                    Convert.ToInt32(reader.GetValue(3)),
                    Convert.ToInt32(reader.GetValue(4)),
                    reader.GetValue(5).ToString(),
                    reader.GetValue(6).ToString(),
                    reader.GetValue(7).ToString(),
                    Convert.ToInt32(reader.GetValue(8)));
                Heroe.ListoOfHeroes.Add(newHeroe);
            }
            reader.Close();

            Disconect(cmd);
        }
  
        public void UpdateHeroe(int id, string name, string type, int hp, int mana, string skill, string skill2, string weapon, int lvl)
        {
            SqlCommand cmd = Conect($"UpdateHeroe '{id}','{name}','{type}',{hp},{mana},'{skill}','{skill2}','{weapon}', {lvl},p");
            cmd.ExecuteNonQuery();
            Disconect(cmd);
        }

        public void DeleteHeroe(int id)
        {
            SqlCommand cmd = Conect($"DeleteHeroe {id}");
            cmd.ExecuteNonQuery();
            Disconect(cmd);
        }
        public void AddHeroe(string name, string type, int hp, int mana, string skill, string skill2, string weapon, int lvl)
        {
            SqlCommand cmd = Conect($"InsertHeroe '{name}', '{type}', {hp}, {mana}, '{skill}', '{skill2}', '{weapon}', {lvl}, 'p'");
            cmd.ExecuteNonQuery();
            Disconect(cmd);
        }
        public void LoadRemovedHeroe()
        {
            SqlCommand cmd = Conect("selectRemovedheroe");

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var newHeroe = new Heroe(
                    Convert.ToInt32(reader.GetValue(0)),
                    reader.GetValue(1).ToString(),
                    reader.GetValue(2).ToString(),
                    Convert.ToInt32(reader.GetValue(3)),
                    Convert.ToInt32(reader.GetValue(4)),
                    reader.GetValue(5).ToString(),
                    reader.GetValue(6).ToString(),
                    reader.GetValue(7).ToString(),
                    Convert.ToInt32(reader.GetValue(8)));
                Heroe.ListoOfRemovedHeroes.Add(newHeroe);
            }
            reader.Close();

            Disconect(cmd);
        }

        public void AddDeletedHeroe(string name, string type, int hp, int mana, string skill, string skill2, string weapon, int lvl)
        {
            SqlCommand cmd = Conect($"InsertRemovedHeroe '{name}', '{type}', {hp}, {mana}, '{skill}', '{skill2}', '{weapon}', {lvl}, p");
            cmd.ExecuteNonQuery();
            Disconect(cmd);
        }
        public void MoveFromRemovedToHeroe(int id)
        {
            SqlCommand cmd = Conect($"MoveFromRemovedToHeroe {id}");
            cmd.ExecuteNonQuery();
            Disconect(cmd);
        }
        public void DeleteRemovedHeroe(int id)
        {
            SqlCommand cmd = Conect($"DeleteRemovedHeroe {id}");
            cmd.ExecuteNonQuery();
            Disconect(cmd);
        }
        

    }


    
}
