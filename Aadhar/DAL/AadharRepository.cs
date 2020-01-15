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
        static string connString = "";
        static AadharDAL()
        {
            connString = "server=localhost;user id=root;database=project;persistsecurityinfo=True;port=3306;allowuservariables=True;password=Root1234@";
        }
        public static List<Aadhar> GetAll()
        {
            List<Aadhar> aadhars = new List<Aadhar>();
            string cmdText = "select * from aadhar";
            MySqlConnection connection = new MySqlConnection(connString);
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
                aadhar.ContactNo = int.Parse(reader["contactNo"].ToString());
                Address address = new Address();
                string cmdText1 = "select * from addresses where aadharNumber =" + aadhar.AadharNumber;
                MySqlConnection connection1 = new MySqlConnection(connString);
                connection1.Open();
                MySqlCommand command1 = new MySqlCommand(cmdText1, connection1);
                IDataReader reader1 = command1.ExecuteReader();
                if (reader1.Read())
                {
                    address.AadharNumber = aadhar.AadharNumber;
                    address.ApartmentNo = Convert.ToString(reader1["apartmentNo"]);
                    address.BuildingName = Convert.ToString(reader1["buildingName"]);
                    address.Street = Convert.ToString(reader1["street"]);
                    address.Landmark = Convert.ToString(reader1["landmark"]);
                    address.City = Convert.ToString(reader1["city"]);
                    address.State = Convert.ToString(reader1["state"]);
                    address.Pincode = Convert.ToString(reader1["pincode"]);
                }
                reader1.Close();
                connection1.Close();
                aadhar.Address = address;
                aadhars.Add(aadhar);
            }
            reader.Close();
            connection.Close();
            return aadhars;
        }
        public static Aadhar GetAadhar(int aadharNumber)
        {
            Aadhar aadhar = new Aadhar();
            Address address = new Address();
            string cmdText1 = "select * from aadhar where aadharNumber =" + aadharNumber;
            string cmdText2 = "select * from addresses where aadharNumber =" + aadharNumber;
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            MySqlCommand command2 = new MySqlCommand(cmdText2, connection);
            IDataReader reader2 = command2.ExecuteReader();
            if (reader2.Read())
            {
                address.AadharNumber = aadharNumber;
                address.ApartmentNo = Convert.ToString(reader2["apartmentNo"]);
                address.BuildingName = Convert.ToString(reader2["buildingName"]);
                address.Street = Convert.ToString(reader2["street"]);
                address.Landmark = Convert.ToString(reader2["landmark"]);
                address.City = Convert.ToString(reader2["city"]);
                address.State = Convert.ToString(reader2["state"]);
                address.Pincode = Convert.ToString(reader2["pincode"]);
            }
            reader2.Close();
            MySqlCommand command1 = new MySqlCommand(cmdText1, connection);
            IDataReader reader1 = command1.ExecuteReader();
            if (reader1.Read())
            {
                aadhar.AadharNumber = int.Parse(reader1["aadharNumber"].ToString());
                aadhar.Name = Convert.ToString(reader1["name"]);
                aadhar.Gender = Convert.ToString(reader1["gender"]);
                aadhar.DateOfBirth = Convert.ToDateTime(reader1["dateOfBirth"]);
                aadhar.ContactNo = int.Parse(reader1["contactNo"].ToString());
                aadhar.Address = address;
            }
            reader1.Close();
            connection.Close();
            return aadhar;
        }
        public static bool GetByContactNo(int contactNo)
        {
            bool status = false;
            Aadhar aadhar = new Aadhar();
            string cmdText = "select * from aadhar where contactNo = " + contactNo;
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            MySqlCommand command = new MySqlCommand(cmdText, connection);
            IDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                /*aadhar.AadharNumber = int.Parse(reader["aadharNumber"].ToString());
                aadhar = GetAadhar(aadhar.AadharNumber);*/
                status = true;
            }
            reader.Close();
            connection.Close();
            return status;
        }
        public static Aadhar GetAadharByContactNo(int contactNo)
        { 
            Aadhar aadhar = new Aadhar();
            string cmdText = "select * from aadhar where contactNo = " + contactNo;
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            MySqlCommand command = new MySqlCommand(cmdText, connection);
            IDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                aadhar.AadharNumber = int.Parse(reader["aadharNumber"].ToString());
                aadhar = GetAadhar(aadhar.AadharNumber);
            }
            reader.Close();
            connection.Close();
            return aadhar;
        }
    }
}
