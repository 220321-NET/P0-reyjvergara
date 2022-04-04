using DL;
namespace BL;

public class FABL : IFABL
{
    private readonly IRepository _repo;
    public FABL(IRepository repo)
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

}