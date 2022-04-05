namespace Models;

public class CustReceipt
{
    private DateTime orderDate = DateTime.Now.Date;

    public List<Product> receiptProduct {get; set;} = new List<Product>();

    public void GetCustReceipt()
    {
        for(int i = 0; i < receiptProduct.Count(); i++)
        {
            Console.WriteLine("A");
        }
    }

}