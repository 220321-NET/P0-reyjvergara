using Microsoft.Data.SqlClient;
using System.Data;

namespace DL;

public class DBRepository : IRepository
{
    private readonly string _connectionString;

    public DBRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    // get products
    // get customer ********
    // get stores
    // kinda it for now
    public void CreateStore(StoreFront newStore)
    {
        throw new NotImplementedException();
    }

    public void CreateCustomer(Customer newCustomer)
    {
        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO  Users(Email, CPassword, CName) OUTPUT INSERTED.Id VALUES (@email, @password, @name)", connection);

        cmd.Parameters.AddWithValue("@email", newCustomer.Email);
        cmd.Parameters.AddWithValue("@password", newCustomer.Password);
        cmd.Parameters.AddWithValue("@name", newCustomer.Name);

        try
        {
            newCustomer.Id = (int) cmd.ExecuteScalar();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }

        connection.Close();
    }

    public Customer FindCustomer(string email, string password)
    {
        Customer customerToReturn = new Customer();
        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand("Select * from Users where Email = @email AND CPassword = @password", connection);
        cmd.Parameters.AddWithValue("@email", email.Trim());
        cmd.Parameters.AddWithValue("@password", password.Trim());
        SqlDataReader reader = cmd.ExecuteReader();

        if(reader.Read())
        {
            int id = reader.GetInt32(0);
            string emailRet = reader.GetString(1);
            string passw = reader.GetString(2);
            string name = reader.GetString(3);
            customerToReturn.Id = id;
            customerToReturn.Email = emailRet;
            customerToReturn.Password = passw;
            customerToReturn.Name = name;
        }
        reader.Close();
        connection.Close();
        /*}
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally{
            return customerToReturn;
        }*/
        return customerToReturn;
    }
    public List<Customer> GetAllCustomers()
    {
        List<Customer> customerFromStore = new List<Customer>();

        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand("Select * from Users", connection);
        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            int id = reader.GetInt32(0);
            string email = reader.GetString(1);
            string password = reader.GetString(2);
            string cname = reader.GetString(3);

            Customer user = new Customer
            {
                Id = id,
                Email = email,
                Name = cname,
                Password = password,
            };
            customerFromStore.Add(user);
        }
        reader.Close();
        connection.Close();

        return customerFromStore;
    }
    public void UpdateCustomer(Customer customerToUpdate)
    {
        DataSet customer = new DataSet();
        throw new NotImplementedException();
    }

    public void CreateProduct(Product newProduct)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public List<StoreFront> GetAllStoreFronts()
    {
        throw new NotImplementedException();
    }

}