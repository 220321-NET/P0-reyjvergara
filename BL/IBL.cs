namespace BL;
public interface IBL
{
  List<StoreFront> SearchStore(string searchString);
  List<StoreFront> GetAllStores();

  void AddStore(StoreFront storeToAdd);

}
