// this namespace type is a .net 6 feature, namespace does not need to 
// enclose the entire file
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
    public void MainMenu()
    {
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
    }
}