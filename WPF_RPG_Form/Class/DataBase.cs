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
        public DataBase()
        {
            //ConectHeroe();
            //AddHeroe("1","1",1,1,"1","1");
            //UpdateHeroe(15, "x", "fdf", 10, 10, "s1", "w1");
            //DeleteHeroe(23);

        }
        public void ConectHeroe()
        {
            SqlConnection con = new SqlConnection(@"Data Source=CODEBAKERTY;Initial Catalog=heroedb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("selectheroe", con);
            con.Open();

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
                    reader.GetValue(7).ToString());
                Heroe.ListoOfHeroes.Add(newHeroe);
            }

            reader.Close();
            cmd.Dispose();
            con.Close();
        }
        public void UpdateHeroe(int id, string name, string type, int hp, int mana, string skill, string skill2, string weapon)
        {
            SqlConnection con = new SqlConnection(@"Data Source=CODEBAKERTY;Initial Catalog=heroedb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand($"UpdateHeroe '{id}','{name}','{type}',{hp},{mana},'{skill}','{skill2}','{weapon}',p", con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void DeleteHeroe(int id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=CODEBAKERTY;Initial Catalog=heroedb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand($"DeleteHeroe {id}", con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void AddHeroe(string name, string type, int hp, int mana, string skill, string skill2, string weapon)
        {
            SqlConnection con = new SqlConnection(@"Data Source=CODEBAKERTY;Initial Catalog=heroedb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand($"InsertHeroe '{name}', '{type}', {hp}, {mana}, '{skill}', '{skill2}', '{weapon}', 'p'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void ConectRemovedHeroe()
        {
            SqlConnection con = new SqlConnection(@"Data Source=CODEBAKERTY;Initial Catalog=heroedb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("selectRemovedheroe", con);
            con.Open();

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
                    reader.GetValue(7).ToString());
                Heroe.ListoOfRemovedHeroes.Add(newHeroe);
            }

            reader.Close();
            cmd.Dispose();
            con.Close();
        }

        public void AddDeletedHeroe(string name, string type, int hp, int mana, string skill, string skill2, string weapon)
        {
            SqlConnection con = new SqlConnection(@"Data Source=CODEBAKERTY;Initial Catalog=heroedb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand($"InsertRemovedHeroe '{name}', '{type}', {hp}, {mana}, '{skill}', '{skill2}', '{weapon}', p", con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void MoveFromRemovedToHeroe(int id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=CODEBAKERTY;Initial Catalog=heroedb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand($"MoveFromRemovedToHeroe {id}", con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void DeleteRemovedHeroe(int id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=CODEBAKERTY;Initial Catalog=heroedb;Integrated Security=True");
            SqlCommand cmd = new SqlCommand($"DeleteRemovedHeroe {id}", con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        

    }


    
}
