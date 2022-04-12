using DL;
using Models;
namespace BL;

public class FABL : IFABL
{
    private readonly DBRepository _repo;
    public FABL(DBRepository repo)
    {
        _repo = repo;
    }
    ///<summary>
    ///  CreateStore recieves information of a StoreFront (address, city, name) to make a store. StoreID is automatically made.
    ///</summary>
    public void CreateStore(StoreFront storeToCreate)
    {
        _repo.CreateStore(storeToCreate);
    }

    // public void CreateProduct(Product productToCreate)
    // {
    //     _repo.CreateProduct(productToCreate);
    // }

    ///<summary>
    ///  CreateCustomer recieves information of Customer to make one
    ///</summary>
    public void CreateCustomer(Customer customerToCreate)
    {
        _repo.CreateCustomer(customerToCreate);
    }

    public void CreateAdmin(Admin adminToCreate, int storeId)
    {
        _repo.CreateAdmin(adminToCreate, storeId);
    }
    ///<summary>
    ///  CreateReceipt will be adjusted to take in total price and date, no plan for updating this project to have all product names in an order
    ///</summary>
    public void CreateReceipt(int storeId, int customerId, int productId)
    {
        _repo.CreateReceipt(storeId, customerId, productId);
    }


    ///<summary>
    ///  FindCustomer is used for the login feature, checks database if email and password combination exists
    ///</summary>
    public Customer FindCustomer(string email, string password)
    {
        return _repo.FindCustomer(email, password);
    }

    ///<summary>
    ///  GetStoreFronts shows a list of all the storefronts 
    ///</summary>
    public List<StoreFront> GetStoreFronts()
    {
        return _repo.GetAllStoreFronts();
    }

    ///<summary>
    ///  GetAllCustomers shows a list of all the customers
    ///</summary>
    public List<Customer> GetAllCustomers()
    {
        return _repo.GetAllCustomers();
    }

    ///<summary>
    ///  GetProducts shows a list of all the products
    ///</summary>
    public List<Product> GetProducts()
    {
        return _repo.GetAllProducts();
    }

    ///<summary>
    ///  AddProduct recieves the product, wanted quantity, and desired storeID to place the product
    ///</summary>
    public void AddProduct(Product productToAdd, int quantity, int storeId)
    {
        _repo.AddProduct(productToAdd, quantity, storeId);
    }

    ///<summary>
    ///  GetStoreProducts shows a list of all the products given storeId
    ///</summary>
    public List<Product> GetStoreProducts(int storeId)
    {
        return _repo.GetStoreProducts(storeId);
    }

    public void DeleteCustomer(Customer customerToDelete)
    {
        throw new NotImplementedException();
        //return _repo.DeleteCustomer(customerToDelete);
    }

    public void DeleteStore(StoreFront storeToDelete)
    {
        throw new NotImplementedException();
        //return _repo.DeleteStore(storeToDelete);
    }
    public void DeleteProduct(Product productToDelete)
    {
        throw new NotImplementedException();
        //return _repo.DeleteProduct(productToDelete);
    }

    ///<summary>
    ///  ValidateEmail is used to see if email exists in database already
    ///</summary>
    public int ValidateEmail(string email)
    {
        return _repo.ValidateEmail(email);
    }

    public int ValidateEmailPass(string email, string password)
    {
        return _repo.ValidateEmailPass(email, password);
    }
}