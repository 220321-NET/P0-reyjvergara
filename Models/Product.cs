namespace Models;
public class Product
{
    public string Name {get; set;}
    public float Price {get; set;}
    public int StoreID {get; set;}
    public string Description {get; set;}
    public int ProductID{get;set;}
    //quantiyu???

    public override string ToString()
    {
        string prodString = $"Id: {ProductID} Name: {Name}\nDescription: {Description}\n"; 
        return base.ToString();
    }
}
