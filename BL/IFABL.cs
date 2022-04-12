namespace BL;

/// <summary> 
/// Interface <c>IFABL</c> is the interface for the Fumo Algorithms Business Logic
/// </summary>
public interface IFABL
{
  void CreateStore(StoreFront storeToCreate);
  void CreateCustomer(Customer customerToCreate);
  void CreateAdmin(Admin adminToCreate, int storeId);
  List<StoreFront> GetStoreFronts();
  List<Product> GetProducts();
  //List<Receipt> GetReceipts();
  void AddProduct(Product productToAdd, int quantity, int storeId);
  void DeleteCustomer(Customer customerToDelete);
  void DeleteProduct(Product productToDelete);
  void DeleteStore(StoreFront storeToDelete);
}
