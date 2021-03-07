using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddPersonInputFields.Data
{
    public class PeopleDb
    {
        private readonly string _connectionString;

        public PeopleDb(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Person> GetPeople()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM People";
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Person> people = new List<Person>();
            while (reader.Read())
            {
                people.Add(new Person
                {

                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }
            return people;
        }
        public void AddPeople(List<Person> people)
        {

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO People VALUES (@firstName, @lastName, @age)";
            connection.Open();
            foreach (Person p in people)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@firstName", p.FirstName);
                cmd.Parameters.AddWithValue("@lastName", p.LastName);
                cmd.Parameters.AddWithValue("@age", p.Age);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
