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

    public void CreateStore(StoreFront storeToCreate)
    {
        _repo.CreateStore(storeToCreate);
    }

    public void CreateProduct(Product productToCreate)
    {
        _repo.CreateProduct(productToCreate);
    }

    public void CreateCustomer(Customer customerToCreate)
    {
        _repo.CreateCustomer(customerToCreate);
    }

    public void CreateReceipt(int storeId, int customerId, int productId)
    {
        _repo.CreateReceipt(storeId, customerId, productId);
    }

    public Customer FindCustomer(string email, string password)
    {
        return _repo.FindCustomer(email, password);
    }


    public List<StoreFront> GetStoreFronts()
    {
        return _repo.GetAllStoreFronts();
    }
    public List<Customer> GetAllCustomers()
    {
        return _repo.GetAllCustomers();
    }
    public List<Product> GetProducts()
    {
        return _repo.GetAllProducts();
    }

    public void AddProduct(Product productToAdd, int quantity, int storeId)
    {
        return _repo.AddProduct(productToAdd, quantity, storeId);
    }
    public List<Product> GetStoreProducts(int storeId)
    {
        return _repo.GetStoreProducts(storeId);
    }

    public void DeleteCustomer(Customer customerToDelete)
    {
        return _repo.DeleteCustomer(customerToDelete);
    }

    public void DeleteStore(StoreFront storeToDelete)
    {
        return _repo.DeleteStore(storeToDelete);
    }
    public void DeleteProduct(Product productToDelete)
    {
        return _repo.DeleteProduct(productToDelete);
    }
}