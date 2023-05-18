using System.Data.SqlClient;
namespace CRUDUsingAdo.Models
{
    public class ProductCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public ProductCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DbConnection"));
        }
        // list
        public List<Product> GetProducts()
        {
            List<Product> list = new List<Product>();
            string qry = "select * from Product";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product product = new Product();
                    product.Id = Convert.ToInt32(dr["id"]);
                    product.Name = dr["name"].ToString();
                    product.Company = dr["company"].ToString();
                    product.Price = Convert.ToInt32(dr["price"]);

                    list.Add(product);
                }
            }
            con.Close();
            return list;
        }
        // display single value against id
        public Product GetProductById(int id)
        {
            Product product = new Product();
            string qry = "select * from Product where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    product.Id = Convert.ToInt32(dr["id"]);
                    product.Name = dr["name"].ToString();
                    product.Company = dr["company"].ToString();
                    product.Price = Convert.ToInt32(dr["price"]);
                }
            }
            con.Close();
            return product;
        }
        // add//insert
        public int AddProduct(Product product)
        {
            int result = 0;
            string qry = "insert into Product values(@name,@company,@price)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@company", product.Company);
            cmd.Parameters.AddWithValue("@price", product.Price);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        // edit//update
        public int EditProduct(Product product)
        {
            int result = 0;
            string qry = "update Product set name=@name,company=@company,price=@price where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@company", product.Company);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@id", product.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        // delete
        public int DeleteProduct(int id)
        {
            int result = 0;
            string qry = "delete from Product where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }


}

