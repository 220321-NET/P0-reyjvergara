namespace Models;

public class Cart
{
    public List<Product> customerCart {get; set;} = new List<Product>();

    decimal calculateTotal()
    {
        if(customerCart.Count() == 0){ return 0.00m ;}
        decimal sum = 0.00m;
        foreach(Product x in customerCart)
        {
            sum += x.Price;
        }
        return sum;
    }
}