using System;
using mis321_makeup_jgswartwood;
using MySql.Data.MySqlClient;

namespace api.models
{
    public class CarUtility
    {
        public List<Car> GetAllCars() {
            List<Car> myCars = new List<Car>();
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            string stm = "SELECT * FROM cars ORDER BY CarDate asc";

            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read()) {
                myCars.Add(new Car() {CarID = rdr.GetInt32(0), MakeAndModel = rdr.GetString(1), Mileage = rdr.GetInt32(2), CarDate = rdr.GetString(3), Hold = rdr.GetBoolean(4), Deleted = rdr.GetBoolean(5)});
            }
            con.Close();
            return myCars;
            
        }

        public void AddCar(Car myCar){
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            
            string stm = @"INSERT INTO cars(MakeAndModel, Mileage, CarDate, Hold, Deleted) VALUES(@MakeAndModel, @Mileage, @CarDate, @Hold, @Deleted)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@MakeAndModel", myCar.MakeAndModel);          
            cmd.Parameters.AddWithValue("@Mileage", myCar.Mileage);          
            cmd.Parameters.AddWithValue("@CarDate", myCar.CarDate);          
            cmd.Parameters.AddWithValue("@Hold", myCar.Hold);          
            cmd.Parameters.AddWithValue("@Deleted", myCar.Deleted);          
            

            cmd.ExecuteNonQuery();

            con.Close();

        }


        public void UpdateCar(Car myCar){
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();


            string stm = " ";
 
            if(myCar.Hold == false){
                stm = $"UPDATE cars SET Hold = 0 WHERE CarID = '{myCar.CarID}'";
            }
            if(myCar.Hold == true){
                stm = $"UPDATE cars SET Hold = 1 WHERE CarID = '{myCar.CarID}'";
            }       


            using var cmd = new MySqlCommand(stm, con);
            

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void DeleteCar(int id){
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $"UPDATE cars SET Deleted = 1 WHERE CarID = '{id}'";


            using var cmd = new MySqlCommand(stm, con);
            
            cmd.ExecuteNonQuery();

            con.Close();
            
        }
    }
}

