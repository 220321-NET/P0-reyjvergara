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
        Console.WriteLine("Welcome to Fumo and Algorithms!");
        bool exit = false;
        do{
            Console.WriteLine("Would you like to Log-in or Sign-Up?");
            Console.WriteLine("[1] Log-in");
            Console.WriteLine("[2] Sign-up");
            Console.WriteLine("[9] Exit");
            int choice;
            do
            {
                Console.Write("Enter your number of choice: ");
                if ((int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 2) || choice == 9)
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
                    LogIn();
                break;
                case 2:
                    SignUp();
                break;
                case 9:
                    exit = true;
                    Console.WriteLine("Exiting, Good-bye!");
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
    private void LogIn()
    {
        //Validate:
        Console.WriteLine("Enter your email:");
        string? tempEmail = Console.ReadLine().Trim() ?? "";
        Console.WriteLine("Enter your password:");
        string? tempPassW = Console.ReadLine().Trim() ?? "";
        Customer success = _bl.FindCustomer(tempEmail, tempPassW);
        Console.WriteLine("Log-in Successful");
        Console.WriteLine("Logged in as " + success.Name);
        StoreMenu(success);
    }

    private void StoreMenu(Customer customer)
    {
        Console.WriteLine("Select your store:");

    }
}    

