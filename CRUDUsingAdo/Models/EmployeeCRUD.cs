using System.Data.SqlClient;

namespace CRUDUsingAdo.Models
{
    public class EmployeeCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public EmployeeCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DbConnection"));
        }
        // list
        public List<Employee> GetEmployees()
        {
            List<Employee> list = new List<Employee>();
            string qry = "select * from Employee";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(dr["id"]);
                    employee.Name = dr["name"].ToString();
                    employee.City = dr["city"].ToString();
                    employee.Salary = Convert.ToInt32(dr["salary"]);

                    list.Add(employee);
                }
            }
            con.Close();
            return list;
        }
        // display single value against id
        public Employee GetEmployeeById(int id)
        {
            Employee employee = new Employee();
            string qry = "select * from Employee where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    employee.Id = Convert.ToInt32(dr["id"]);
                    employee.Name = dr["name"].ToString();
                    employee.City = dr["city"].ToString();
                    employee.Salary = Convert.ToInt32(dr["salary"]);
                }
            }
            con.Close();
            return employee;
        }
        // add//insert
        public int AddEmployee(Employee employee)
        {
            int result = 0;
            string qry = "insert into Employee values(@name,@city,@salary)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", employee.Name);
            cmd.Parameters.AddWithValue("@city", employee.City);
            cmd.Parameters.AddWithValue("@salary", employee.Salary);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        // edit//update
        public int EditEmployee(Employee employee)
        {
            int result = 0;
            string qry = "update Employee set name=@name,city=@city,salary=@salary where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", employee.Name);
            cmd.Parameters.AddWithValue("@city", employee.City);
            cmd.Parameters.AddWithValue("@salary",employee.Salary);
            cmd.Parameters.AddWithValue("@id", employee.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        // delete
        public int DeleteEmployee(int id)
        {
            int result = 0;
            string qry = "delete from Employee where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
