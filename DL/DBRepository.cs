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

    public void CreateStore(StoreFront newStore)
    {
        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand("Insert into StoreFront(Name, City, State) OUTPUT Inserted.Id Values (@name, @city, @state)", connection);

        cmd.Parameters.AddWithValue("@name", newStore.Name);
        cmd.Parameters.AddWithValue("@city", newStore.City);
        cmd.Parameters.AddWithValue("@state", newStore.State);

        try
        {
            newStore.StoreID = (int) cmd.ExecuteScalar();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        connection.Close();
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

    public void CreateAdmin(Admin newAdmin, int storeId)
    {
        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand("Insert into Admin(Email, APassword, AName, StoreId) OUTPUT Inserted.Id Values (@email, @password, @name, @storeId)", connection);

        cmd.Parameters.AddWithValue("@email", newAdmin.Email);
        cmd.Parameters.AddWithValue("@password", newAdmin.Password);
        cmd.Parameters.AddWithValue("@name", newAdmin.Name);
        cmd.Parameters.AddWithValue("@storeId", storeId);

        try
        {
            newAdmin.Id = (int) cmd.ExecuteScalar();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }

        connection.Close();
    }

    public void AddProduct(Product newProduct, int quantity, int storeId)
    {
        throw new NotImplementedException();
        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand("Insert into Product(Name, Description, Price, Quantity, storeId) output inserted.Id Values(@name, @description, @price, @quantity, @storeId)", connection);

        cmd.Parameters.AddWithValue("@name", newProduct.Name);
        cmd.Parameters.AddWithValue("@description", newProduct.Description);
        cmd.Parameters.AddWithValue("@price", newProduct.Price);
        cmd.Parameters.AddWithValue("@quantity", quantity);
        cmd.Parameters.AddWithValue("@storeId", storeId);

        try
        {
            newProduct.ProductID = (int) cmd.ExecuteScalar();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        connection.Close();
    }

    public void CreateReceipt(int storeId, int customerId, int productId)
    {
        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand("Insert into Receipt(ProductName, TotalCost, StoreID, CustomerID) Values ((select Name from Product where Id = @prodId), (select Price from Product where Id = @prodId), @storeId, @customerId)", connection);
        SqlCommand cmd2 = new SqlCommand("UPDATE Product SET Quantity = Quantity -1 Where Id = @prodId  AND StoreID = @storeId", connection);
        cmd.Parameters.AddWithValue("@storeId", storeId);
        cmd.Parameters.AddWithValue("@customerId", customerId);
        cmd.Parameters.AddWithValue("@prodId", productId);
        cmd2.Parameters.AddWithValue("@prodId", productId);
        cmd2.Parameters.AddWithValue("@storeId", storeId);
        cmd.ExecuteNonQuery();
        cmd2.ExecuteNonQuery();
        connection.Close();
        Console.WriteLine("Bought item, returning to main menu...\n");
    }

    public List<Product> GetAllProducts()
    {
        throw new NotImplementedException();
    }


    public List<Product> GetStoreProducts(int storeId)
    {
        List<Product> storeProduct = new List<Product>();
        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand("Select * from Product where StoreID = @storeId", connection);
        cmd.Parameters.AddWithValue("@storeId", storeId);
        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            string description = reader.GetString(2);
            decimal price = reader.GetDecimal(3);
            int quantity = reader.GetInt32(4);
            int sid = storeId;
            Product prod = new Product
            {
                ProductID = id,
                Price = price,
                Name = name,
                Description = description,
                Quantity = quantity,
                StoreID = sid,
            };
            storeProduct.Add(prod);
        }
        reader.Close();
        connection.Close();
        return storeProduct;
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


    public List<StoreFront> GetAllStoreFronts()
    {
        List<StoreFront> allStores = new List<StoreFront>();

        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand("Select * from StoreFront", connection);
        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            string city = reader.GetString(2);
            string state = reader.GetString(3);

            StoreFront store = new StoreFront
            {
                StoreID = id,
                Name = name,
                City = city,
                State = state,
            };
            allStores.Add(store);
        }
        reader.Close();
        connection.Close();

        return allStores;
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

    public int ValidateEmail(string email)
    {
        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from users where Email like @email", connection);
        cmd.Parameters.AddWithValue("@email", email.Trim());
        int userCount = (int) cmd.ExecuteScalar();
        connection.Close();
        return userCount;
    }

    public int ValidateEmailPass(string email, string password)
    {
        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from users where Email like @email and CPassword like @password", connection);
        cmd.Parameters.AddWithValue("@email", email.Trim());
        cmd.Parameters.AddWithValue("@password", password.Trim());
        int userCount = (int) cmd.ExecuteScalar();
        connection.Close();
        return userCount;
    }

    public void DeleteCustomer(Customer customerToDelete)
    {
        throw new NotImplementedException();
    }

    public void DeleteStore(StoreFront storeToDelete)
    {
        throw new NotImplementedException();
    }
    public void DeleteProduct(Product productToDelete)
    {
        throw new NotImplementedException();
    }
}