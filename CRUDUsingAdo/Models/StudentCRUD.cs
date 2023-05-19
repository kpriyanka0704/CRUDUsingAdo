using System.Data.SqlClient;
namespace CRUDUsingAdo.Models
{
    public class StudentCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public StudentCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DbConnection"));
        }
        // list
        public List<Student> GetStudents()
        {
            List<Student> list = new List<Student>();
            string qry = "select * from Student";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student student = new Student();
                    student.Id = Convert.ToInt32(dr["id"]);
                    student.Name = dr["name"].ToString();
                    student.Branch = dr["branch"].ToString();
                    student.Email = dr["email"].ToString();
                    student.Percentage = Convert.ToInt32(dr["percentage"]);

                    list.Add(student);
                }
            }
            con.Close();
            return list;
        }
        // display single value against roll no
        public Student GetStudentById(int id)
        {
            Student student = new Student();
            string qry = "select * from Student where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    student.Id = Convert.ToInt32(dr["id"]);
                    student.Name = dr["name"].ToString();
                    student.Branch = dr["branch"].ToString();
                    student.Email = dr["email"].ToString();
                    student.Percentage = Convert.ToInt32(dr["percentage"]);
                }
            }
            con.Close();
            return student;
        }
        // add//insert
        public int AddStudent(Student student)
        {
            int result = 0;
            string qry = "insert into Student values(@name,@branch,@email,@percentage)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@branch", student.Branch);
            cmd.Parameters.AddWithValue("@email", student.Email);
            cmd.Parameters.AddWithValue("@percentage", student.Percentage);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        // edit//update
        public int EditStudent(Student student)
        {
            int result = 0;
            string qry = "update Student set name=@name,branch=@branch,email=@email,percentage=@percentage where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@branch", student.Branch);
            cmd.Parameters.AddWithValue("@email", student.Email);
            cmd.Parameters.AddWithValue("@percentage", student.Percentage);
            cmd.Parameters.AddWithValue("@id", student.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        // delete
        public int DeleteStudent(int id)
        {
            int result = 0;
            string qry = "delete from Student where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
