namespace Models;

public class Receipt
{
    private DateTime orderDate = DateTime.Now.Date;

    //public List<Product> receiptProduct {get; set;} = new List<Product>();
    public Product prod {get;set;}

    public int CustomerID{get;set;}
    public int StoreID{get;set;}

    /*public void GetCustReceipt()
    {
        for(int i = 0; i < receiptProduct.Count(); i++)
        {
            Console.WriteLine("A");
        }
    }*/

}