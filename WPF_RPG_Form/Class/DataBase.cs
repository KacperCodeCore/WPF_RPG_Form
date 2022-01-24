using System;
using System.Collections.Generic;
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
            //AddHeroe();
            //UpdateHeroe(4, "name1", "type1", 99, 1, "11", "weapon1");
            //DeleteHeroe(6);
            //ConectHeroe();

        }

        public void ConectHeroe()
        {
            string connetionString = @"Data Source=DESKTOP-HUCK62B;Initial Catalog=HeroeData;User ID=sa;Password=kacper1";
            SqlConnection cnn = new SqlConnection(connetionString);

            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;

            String sql = "Select id,name,type,hp,mana,skill,weapon From heroes";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                var newHeroe = new Heroe(
                    Convert.ToInt32(dataReader.GetValue(0)),
                    dataReader.GetValue(1).ToString(), 
                    dataReader.GetValue(2).ToString(),
                    Convert.ToInt32(dataReader.GetValue(3)),
                    Convert.ToInt32(dataReader.GetValue(4)),
                    dataReader.GetValue(5).ToString(),
                    dataReader.GetValue(6).ToString());
                Heroe.ListoOfHeroes.Add(newHeroe);
            }

            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }

        public void UpdateHeroe(int id, string name, string type, int hp, int mana, string skill, string weapon)
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = @"Data Source=DESKTOP-HUCK62B;Initial Catalog=HeroeData;User ID=sa;Password=kacper1";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = $"Update Heroes set name='{name}',type='{type}',hp='{hp}',mana='{mana}',skill='{skill}',weapon='{weapon}' Where id={id}";

            command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();

            command.Dispose();
            cnn.Close();
        }

        public void DeleteHeroe(int id)
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = @"Data Source=DESKTOP-HUCK62B;Initial Catalog=HeroeData;User ID=sa;Password=kacper1";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = $"Delete heroes where id='{id}'";

            command = new SqlCommand(sql, cnn);
            adapter.DeleteCommand = new SqlCommand(sql, cnn);
            adapter.DeleteCommand.ExecuteNonQuery();

            command.Dispose();
            cnn.Close();
        }
        public void AddHeroe(string name, string type, int hp, int mana, string skill, string weapon)
        {
            

            string connetionString = @"Data Source=DESKTOP-HUCK62B;Initial Catalog=HeroeData;User ID=sa;Password=kacper1";
            string query = $"EXECUTE InsertHeroe {name}, {type}, {hp}, {mana}, {skill}, {weapon}, NULL";

            SqlConnection connection = new SqlConnection(connetionString);
            SqlCommand cnn = new SqlCommand(query, connection);
            connection.Open();
            cnn.ExecuteNonQuery();

            connection.Close();
            cnn.Dispose();

        }


    }

    
}
