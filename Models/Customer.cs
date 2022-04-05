using System.ComponentModel.DataAnnotations;

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
            name = value;
        }
    }
    public string Email    
    {
        get => email;

        set{
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new Exception("Name cannot be empty");
            }
            email = value;
        }
    }
    public int CustomerID{get;set;}
    public string Password{get;set;}
    
}