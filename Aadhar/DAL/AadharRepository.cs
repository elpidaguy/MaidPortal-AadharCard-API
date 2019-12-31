using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using BOL;

namespace DAL
{
    public static class AadharDAL
    {
        public static List<Aadhar> GetAll()
        {
            List<Aadhar> aadhars = new List<Aadhar>();
            string cmdText = "select * from aadharDetails";
            MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;database=aadhar;persistsecurityinfo=True;port=3333;allowuservariables=True;password=actscdac");
            connection.Open();
            MySqlCommand command = new MySqlCommand(cmdText, connection);
            IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Aadhar aadhar = new Aadhar();
                aadhar.AadharNumber = int.Parse(reader["aadharNumber"].ToString());
                aadhar.Name = Convert.ToString(reader["name"]);
                aadhar.Gender = Convert.ToString(reader["gender"]);
                aadhar.DateOfBirth = Convert.ToDateTime(reader["dateOfBirth"]);
                aadhar.Address = Convert.ToString(reader["address"]);
                aadhars.Add(aadhar);
            }
            reader.Close();
            connection.Close();
            return aadhars;
        }
        public static Aadhar GetAadhar(int aadharNumber)
        {
            Aadhar aadhar = new Aadhar();
            string cmdText = "select * from aadharDetails where aadharNumber =" + aadharNumber;
            MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;database=aadhar;persistsecurityinfo=True;port=3333;allowuservariables=True;password=actscdac");
            connection.Open();
            MySqlCommand command = new MySqlCommand(cmdText, connection);
            IDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                aadhar.AadharNumber = int.Parse(reader["aadharNumber"].ToString());
                aadhar.Name = Convert.ToString(reader["name"]);
                aadhar.Gender = Convert.ToString(reader["gender"]);
                aadhar.DateOfBirth = Convert.ToDateTime(reader["dateOfBirth"]);
                aadhar.Address = Convert.ToString(reader["address"]);
            }
            reader.Close();
            connection.Close();
            return aadhar;
        }
    }
}
