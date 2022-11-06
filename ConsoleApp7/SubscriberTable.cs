using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ConsoleApp7
{
    internal class SubscriberTable
    {
        private string tableName;
        public SubscriberTable()
        {
            tableName = "Project";
        }
        public Subscriber GetById(int id)
        {
            Subscriber subscriber = null;
            SQLiteConnection conn = Singleton.GetInstance();

            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM " + tableName + " WHERE id = @Id", conn))
            {
                SQLiteParameter param = new SQLiteParameter();
                param.ParameterName = "@Id";
                param.Value = id;

                command.Parameters.Add(param);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    subscriber = new Subscriber
                    {
                        id = Convert.ToInt32(reader[0].ToString()),
                        phone = reader[1].ToString(),
                        address = reader[2].ToString(),
                        owner = reader[3].ToString(),
                        sumTime = Convert.ToInt32(reader[4].ToString()),
                    };
                }
                reader.Close();
                return subscriber;
            }
        }
        public IEnumerable<Subscriber> GetAll()
        {
            SQLiteConnection conn = Singleton.GetInstance();

            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM " + tableName, conn))
            {
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Subscriber project = new Subscriber
                    {
                        id = Convert.ToInt32(reader[0].ToString()),
                        phone = reader[1].ToString(),
                        address = reader[2].ToString(),
                        owner = reader[3].ToString(),
                        sumTime = Convert.ToInt32(reader[4].ToString()),
                    };
                    yield return project;
                }
                reader.Close();
            }
        }

        public int GetAvg(int x)
        {
            SQLiteConnection conn = Singleton.GetInstance();

            using (SQLiteCommand command = new SQLiteCommand("SELECT AVG(price) FROM " + tableName + " WHERE sumTime > " + x, conn))
            {
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return Convert.ToInt32(reader[0]);
                }
                return 0;
            }
        }

        public void Save(Subscriber project)
        {
            SQLiteConnection conn = Singleton.GetInstance();

            SQLiteCommand command = null;

            if (project.id < 1)
            {
                using (command = new SQLiteCommand("INSERT INTO " + tableName + "(phone, address, owner, sumTime) " +
                    "VALUES (@phone, @address, @owner, @sumTime)", conn))
                {
                    command.Parameters.AddWithValue("@phone", project.phone);
                    command.Parameters.AddWithValue("@address", project.address);
                    command.Parameters.AddWithValue("@owner", project.owner);
                    command.Parameters.AddWithValue("@sumTime", project.sumTime);
                    command.ExecuteNonQuery();
                    command.CommandText = "Select seq from sqlite_sequence where name = '" + tableName + "'";
                    project.id = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            else
            {
                using (command = new SQLiteCommand("UPDATE " + tableName +
                    " SET phone = @phone, address = @address, owner = @owner, sumTime = @sumTime " +
                    " WHERE id = @id", conn))
                {
                    command.Parameters.Add(new SQLiteParameter("@phone", project.phone));
                    command.Parameters.Add(new SQLiteParameter("@address", project.address));
                    command.Parameters.Add(new SQLiteParameter("@owner", project.owner));
                    command.Parameters.Add(new SQLiteParameter("@sumTime", project.sumTime));
                    command.Parameters.Add(new SQLiteParameter("@id", project.id));
                    command.ExecuteNonQuery();
                }
            }

        }

        public void Remove(Subscriber project)
        {
            SQLiteConnection conn = Singleton.GetInstance();

            using (SQLiteCommand command = new SQLiteCommand("DELETE FROM " + tableName + " WHERE id = @id", conn))
            {
                command.Parameters.Add(new SQLiteParameter("@id", project.id));
                command.ExecuteNonQuery();
                project.id = 0;
            }
        }
    }
}
