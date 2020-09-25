using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

namespace newProject01.Models
{


    public class DBmessage
    {
        private readonly string ConnStr = "Data Source=DESKTOP-6Q13NT2;Initial Catalog=test;Integrated Security=True";

        //=======查詢==========
        public List<Card> GetCards()
        {
            List<Card> cards = new List<Card>();
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TodoList01");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Card card = new Card
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Narrate = reader.GetString(reader.GetOrdinal("narrate")),
                        Schedule = reader.GetString(reader.GetOrdinal("schedule")),
                        Date = reader.GetString(reader.GetOrdinal("date"))

                    };
                    cards.Add(card);
                }
            }
            else
            {
                Console.WriteLine("資料庫為空！");
            }
            sqlConnection.Close();
            return cards;

        }


        //=====================

        //新增
        public void NewCard(Card card)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand(
                @"INSERT INTO TodoList01 (name, narrate, date)
                  VALUES (@name, @narrate, @date)"
                );
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@name", card.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@narrate", card.Narrate));  //工作事項敘述 <----新功能
            sqlCommand.Parameters.Add(new SqlParameter("@date", card.Date));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();


        }
        //=====================

        //刪除
        public void DeletrCardByName(string Name)
        {

            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM TodoList01 WHERE Name= @Name");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@Name", Name));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();


        }
        //=====================

        //修改--檢查資料
        public Card GetCardsById(int id)
        {
            Card card = new Card();
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TodoList01 WHERE id = @id");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@id", id));
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    card = new Card
                    {

                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Narrate = reader.GetString(reader.GetOrdinal("narrate")),
                        Schedule = reader.GetString(reader.GetOrdinal("schedule")),
                        Date = reader.GetString(reader.GetOrdinal("date")),

                    };
                }
            }
            else
            {
                Console.WriteLine("資料庫為空！");
            }
            sqlConnection.Close();
            return card;

        }
        //修改--Updata資料
        public void UpDataCard(Card card)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand(@"UPDATE TodoList01 SET name = @name, narrate = @narrate, date = @date WHERE id = @Id");

            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@Id", card.Id));
            sqlCommand.Parameters.Add(new SqlParameter("@Name", card.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@Narrate", card.Narrate));
            sqlCommand.Parameters.Add(new SqlParameter("@Date", card.Date));


            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        //修改--Updata資料
        public void recoveryCard(Card card) {
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand(@"UPDATE TodoList01 SET schedule");

            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@schedule", card.Schedule));

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Clone();
            

        }
        //=====================

        //========修改完成狀態=
        public void UpDataSchedule(Card card)
        {

            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand(@"UPDATE TodoList01 SET schedule = @Schedule WHERE id = @Id");

            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@Id", card.Id));
            sqlCommand.Parameters.Add(new SqlParameter("@Schedule", card.Schedule));

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }
        //=====================
    }


}