namespace DL;
public interface IRepository
{
   // Console.WriteLine("Welcome to Fumo and Algorithms!");

   List<Product> GetAllProducts();
   List<StoreFront> GetAllStoreFronts();
   List<Customer> GetAllCustomers();

   void CreateStore(StoreFront storeToAdd);
   //void CreateProduct(Product productToAdd);
   void CreateCustomer(Customer customerToAdd);
}
