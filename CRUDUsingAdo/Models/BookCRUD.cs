using System.Data.SqlClient;
namespace CRUDUsingAdo.Models
{
    public class BookCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        private readonly IConfiguration configuration;

        public BookCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DbConnection"));
        }
        // list
        public List<Book> GetBooks()
        {
            List<Book> list = new List<Book>();
            string qry = "select * from Book";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Book book = new Book();
                    book.Id = Convert.ToInt32(dr["id"]);
                    book.Name = dr["name"].ToString();
                    book.Authorname = dr["authorname"].ToString();
                    book.Price = Convert.ToInt32(dr["price"]);

                    list.Add(book);
                }
            }
            con.Close();
            return list;
        }
        // display single value against id
        public Book GetBookById(int id)
        {
            Book book = new Book();
            string qry = "select * from Book where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    book.Id = Convert.ToInt32(dr["id"]);
                    book.Name = dr["name"].ToString();
                    book.Authorname = dr["authorname"].ToString();
                    book.Price = Convert.ToInt32(dr["price"]);
                }
            }
            con.Close();
            return book;
        }
        // add//insert
        public int AddBook(Book book)
        {
            int result = 0;
            string qry = "insert into Book values(@name,@authorname,@price)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", book.Name);
            cmd.Parameters.AddWithValue("@authorname", book.Authorname);
            cmd.Parameters.AddWithValue("@price", book.Price);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        // edit//update
        public int EditBook(Book book)
        {
            int result = 0;
            string qry = "update Book set name=@name,authorname=@authorname,price=@price where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", book.Name);
            cmd.Parameters.AddWithValue("@authorname", book.Authorname);
            cmd.Parameters.AddWithValue("@price", book.Price);
            cmd.Parameters.AddWithValue("@id", book.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        // delete
        public int DeleteBook(int id)
        {
            int result = 0;
            string qry = "delete from Book where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
