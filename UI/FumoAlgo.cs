// this namespace type is a .net 6 feature, namespace does not need to 
// enclose the entire file
using Models;
using System.ComponentModel.DataAnnotations;
using BL;
namespace FumoAlgo;

// class is a type
// public is an access modifer, which controls access to types and type members
// public, private - no children, protected, and internal - me and everyone in the same assembly
// default is internal for types like class
// private for type members, like methods, fields or properties

public class FumoAlgoMenu
{
    // blueprint for the menu
    // method defines behavior
    private readonly FABL _bl;

    public FumoAlgoMenu(FABL bl)
    {
        _bl = bl;
    }
    public void MainMenuStart()
    {
        /* test code for the database to see if we can get all users
        Console.WriteLine("Let's test out the DB");
        List<Customer> test = _bl.GetAllCustomers();
        foreach(Customer cust in test)
        {
            Console.WriteLine(cust.Name);
        }
        */
        Console.WriteLine("Welcome to Fumo and Algorithms!");
        // We will need a menu, listing some different objects
        // these options should be to login first
        // then give option to buy, sell, logout, exit
        Console.WriteLine("Here's where you login/signup");
        Console.WriteLine("Then we will make you pick a store");
        Console.WriteLine("     Or you can select account settings");
        Console.WriteLine("After that you can see the products");
        Console.WriteLine("     Or you can select account settings");
        Console.WriteLine("Then you can buy some products to your cart");
        bool exit = false;
        do{
            Console.WriteLine("Would you like to Log-in or Sign-Up?");
            Console.WriteLine("[1] Log-in");
            Console.WriteLine("[2] Sign-up");
            int choice;
            do
            {
                Console.Write("Enter your number of choice: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 2)
                {
                    break;
                }
                Console.WriteLine("Please enter the correct number");
            }
            while (true);

            switch(choice)
            {
                case 1:
                    // Log in customer
                    Console.WriteLine("Logging in...");
                break;
                case 2:
                    SignUp();
                break;
                default:
                
                    Console.WriteLine("This shouldn't appear!");
                break;
            }

        }while(exit == false);
    }

    private void SignUp()
    {
        
        // creating new customer data
        Customer customerToMake = new Customer();
        Console.WriteLine("Creating new user...");

        EnterCustomerInfo:
        Console.WriteLine("enter name:");
        string? name = Console.ReadLine();
        Console.WriteLine("enter in your email:");
        string? email = Console.ReadLine();

        Console.WriteLine("enter password:");
        string? password = Console.ReadLine();

        try
        {
            customerToMake.Email = email;
            customerToMake.Password = password;
            customerToMake.Name = name;
        }
        catch(ValidationException ex)
        {
            Console.WriteLine(ex.Message);
            goto EnterCustomerInfo;
        }

        _bl.CreateCustomer(customerToMake);
    }
}    