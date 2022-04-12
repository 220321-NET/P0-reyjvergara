namespace Models;
public class Product
{
    public string Name {get; set;}
    public decimal Price {get; set;}
    public int StoreID {get; set;}
    public string Description {get; set;}
    public int Quantity{get; set;}
    public int ProductID{get;set;}

    public override string ToString()
    {
        string prodString = $"Id: {ProductID} Name: {Name}\nDescription: {Description}\n"; 
        return base.ToString();
    }
}
