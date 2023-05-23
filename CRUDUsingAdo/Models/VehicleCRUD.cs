using System.Data.SqlClient;

namespace CRUDUsingAdo.Models
{
    public class VehicleCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        private readonly IConfiguration configuration;
        public VehicleCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DbConnection"));
        }

        //list
        public List<Vehicle> GetVehicles()
        {
            List<Vehicle> list = new List<Vehicle>();
            string qry = "Select * from Vehicle";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.HasRows)
            {
                if(dr.Read())
                {
                    Vehicle vehicle = new Vehicle();
                    vehicle.Id = Convert.ToInt32(dr["id"]);
                    vehicle.Name = dr["name"].ToString();
                    vehicle.Color = dr["color"].ToString();
                    vehicle.Price = Convert.ToInt32(dr["price"]);
                    list.Add(vehicle);
                }
            }
            con.Close();
            return list;
        }
        public Vehicle GetVehiclesById(int id)
        {
            Vehicle vehicle = new Vehicle();
            string qry = "Select * from Vehicle where id=@id";
            cmd= new SqlCommand(qry, con);  
            cmd.Parameters.AddWithValue("id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.HasRows)
            {
                if(dr.Read())
                {
                    vehicle = new Vehicle();
                    vehicle.Id = Convert.ToInt32(dr["id"]);
                    vehicle.Name = dr["name"].ToString();
                    vehicle.Color = dr["color"].ToString();
                    vehicle.Price = Convert.ToInt32(dr["price"]);
                }
            }
            con.Close();
            return vehicle;
        }
        public int AddVehicle(Vehicle vehicle)
        {
            int result = 0;
            string qry="Insert into Vehicle values(@name,@color,@price)";
            cmd= new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", vehicle.Name);
            cmd.Parameters.AddWithValue("@color", vehicle.Color);
            cmd.Parameters.AddWithValue("@price", vehicle.Price);
            con.Open() ;
            result= cmd.ExecuteNonQuery();
            con.Close() ;
            return result;

        }
        public int EditVehicle(Vehicle vehicle)
        {
            int result = 0;
            string qry = "Update  Vehicle set name=@name,color=@color,price=@price where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", vehicle.Name);
            cmd.Parameters.AddWithValue("@color", vehicle.Color);
            cmd.Parameters.AddWithValue("@price", vehicle.Price);
            cmd.Parameters.AddWithValue("@id", vehicle.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        public int DeleteVehicle(int id)
        {
            int result = 0;
            string qry = "Delete from Vehicle where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id",id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
   
}
