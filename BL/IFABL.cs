namespace BL;

public interface IFABL
{
  void CreateStore(StoreFront storeToCreate);

  void CreateProduct(Product productToCreate);
  List<StoreFront> GetStoreFronts();
  List<Product> GetProducts();
  //void AddStore(StoreFront storeToAdd);
  void CreateCustomer(Customer customerToCreate);
  // void DeleteCustomer(Customer customerToDelete);
  // void DeleteProduct(Product productToDelete);
  // void DeleteStore(StoreFront storeToDelete);
}
