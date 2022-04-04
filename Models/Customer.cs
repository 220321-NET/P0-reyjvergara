using System.Text;

namespace Models;

public class Customer
{
    private string name ="";
    private string email = "";
    public string Name
    {
        get => name;

        set{
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new Exception("Name cannot be empty");
            }
        }
    }
    public string Email{get;set;}
    public string CustomerID{get;set;}
    public string Password{get;set;}
    
}