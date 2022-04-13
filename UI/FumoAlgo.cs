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
        Console.WriteLine("Welcome to Fumo and Algorithms!\n");
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
                if ((int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 2) || choice == 9 || choice == 1234)
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
                case 1234:
                    Console.WriteLine("Going to Administrator Menu...");
                    AdminMenu();
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
        Console.WriteLine("Creating new user...\n");

        EnterCustomerInfo:
        Console.WriteLine("enter name:");
        string? name = Console.ReadLine();
        Console.WriteLine("enter in your email:");
        string? email = Console.ReadLine();
        if(_bl.ValidateEmail(email) > 0)
        {
            Console.WriteLine("Email already exists...");
            goto EnterCustomerInfo;
        }
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
        Validate:
        Console.WriteLine("\nEnter your email:");
        string? tempEmail = Console.ReadLine().Trim() ?? "";
        Console.WriteLine("Enter your password:");
        string? tempPassW = Console.ReadLine().Trim() ?? "";
        if(_bl.ValidateEmailPass(tempEmail, tempPassW) != 1)
        {
            Console.WriteLine("Incorrect Email/Password Combination entered");
            Console.WriteLine("Would you like to sign up?");
            do
            {
                Console.WriteLine("[0] Sign-Up      [1] Login");
                int lisu_choice;
                if(int.TryParse(Console.ReadLine().Trim(), out lisu_choice) && lisu_choice >= 0 && lisu_choice <= 1)
                {
                    if(lisu_choice == 0)
                    {
                        SignUp();
                    }
                    else
                    {
                        goto Validate;
                    }
                }
                Console.WriteLine("Please enter a valid number");
            }while(true);
        }
        Customer success = _bl.FindCustomer(tempEmail, tempPassW);
        Console.WriteLine("Log-in Successful");
        Console.WriteLine("Logged in as " + success.Name);
        StoreMenu(success);
    }

    private void StoreMenu(Customer customer)
    {
        List<StoreFront> allStores = _bl.GetStoreFronts();
        int storeChoice;
        do
        {
            Console.WriteLine("Select your store:");
            foreach(StoreFront stores in allStores)
            {
                Console.WriteLine($"[{stores.StoreID}] {stores.Name} : {stores.City}, {stores.State}");
            }
            if(int.TryParse(Console.ReadLine().Trim(), out storeChoice) && storeChoice >= 1 && storeChoice <= allStores.Count())
            {
                break;
            }
            Console.WriteLine("Please enter a valid number");
        }while(true);
        Console.WriteLine("\nYou selected the store " + allStores.ElementAt(storeChoice-1).Name);
        int storeId = allStores.ElementAt(storeChoice-1).StoreID;
        StoreInventory(customer, storeId);
    }

    private void StoreInventory(Customer customer, int storeId)
    {
        Console.WriteLine("\nWelcome, here's our inventory:");
        List<Product> storeProduct = _bl.GetStoreProducts(storeId);
        int i = 1;
        foreach(Product sProd in storeProduct)
        {
            Console.WriteLine($"[{i}] {sProd.Name} {sProd.Price} Quantity: {sProd.Quantity} [PID:{sProd.ProductID}]");
            i++;
        }
        Console.WriteLine(" ");
        Console.WriteLine("Please enter your selection on what you want to buy or [12] to go back to store selection");
        int choice;
        do
        {
            if((int.TryParse(Console.ReadLine().Trim(), out choice) && choice >= 1 && choice <= storeProduct.Count()) || choice == 12)
            {
                break;
            }
            Console.WriteLine("Please enter a valid number");
        }while(true);

        if(choice == 12){StoreMenu(customer);}
        int prodID = storeProduct.ElementAt(choice-1).ProductID;
        // grab product instead to make a purchase with total, no name necessary
        // for now just use receipt 
        //but make a new table with total, storeID and customerID, and orderid for a primary key in ADS
        // and then make a new method called shopping cart that stores a list of items, which clears after purchase
        MakeReceipt(customer, storeId, prodID);
    }

    private void CartMenu(Cart sessionCart, Customer customer, int storeId)
    {
        // will never be called until one item exists in cart, though if all items are removed, should not make a receipt and remark cart is empty
        // should be able to view cart content, i.e. only prod name and prod price
        Console.WriteLine("Item added to cart");
        Console.WriteLine("Would you like to add more items, remove items, check items and price, or checkout?");
        Console.WriteLine("[0] Add items    [1] Remove items\n[2] Check items   [4] Checkout");
        Console.WriteLine("[5] Quit and go to Main Menu - will remove items from cart");
        do
        {
            // same choice thing for validation, maybe I'll change it up to make it my own function next project...
        }while(true);

    }

    private void MakeReceipt(Customer customer, int storeID, int prodID)
    {
        Console.WriteLine("You are buying this item, correct? [Y] [N]");
        string choice;
        do
        {
            choice = Console.ReadLine().Trim().ToUpper();
            if(( choice == "Y" ) || ( choice == "N" ))
            {
                break;
            }
            Console.WriteLine("Please enter Y or N");
        }while(true);

        if(choice == "Y")
        {
            _bl.CreateReceipt(storeID, customer.Id, prodID);
        }
        else
        {
            Console.WriteLine("Returning to inventory of current store...");
            StoreInventory(customer, storeID);
        }
    }

    private void AdminMenu()
    {
        Console.WriteLine("WIP, need to place in options to add stores, add quantity, sign in to the admin,  make admins, so on and so forth");
        Console.WriteLine("Please sign-in or exit to main menu.");
        //Console.WriteLine("Contact another administrator if you lost access to your password or email");

        Console.WriteLine("[0] Sign-In      [1] Go back to Main Menu    [2] Forgot Login/Lost access");
        string choice;
        do
        {
            choice = Console.ReadLine().Trim();
            if((choice == "0") || (choice == "1") || (choice == "2"))
            {
                break;
            }
            Console.WriteLine("Please Enter valid choice of 0, 1, or 2");
        }while(true);
        if (choice == "0")
        {
            Console.WriteLine("Initiating the sign in for administrator");
        }
        else if(choice == "1")
        {
            Console.WriteLine("Going back to Main Menu...");
            // MainMenuStart(); automatically breaks out because of how this is a loop and all
        }
        else
        {
            Console.WriteLine("Please contact an administrator for further help on recovering or changing your password. \nReturning to main menu...");
        }
    }    
}

