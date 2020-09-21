using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;

namespace newProject01.Models
{


    public class DBmessage
    {
        private readonly string ConnStr = "Data Source=DESKTOP-6Q13NT2;Initial Catalog=test;Integrated Security=True";
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
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Schedule = reader.GetString(reader.GetOrdinal("schedule")),
                        Date = reader.GetString(reader.GetOrdinal("date")),

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


        public void NewCard(Card card)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand(
                @"INSERT INTO card (name, schedule, date)
                  VALUES (@name, @schedule, @date)"
                );
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@name", card.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@schedule", card.Schedule));
            sqlCommand.Parameters.Add(new SqlParameter("@date", card.Date));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        
        
        }
    }


}