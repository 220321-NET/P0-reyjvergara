﻿namespace DL;
public interface IRepository
{
   // Console.WriteLine("Welcome to Fumo and Algorithms!");
   void ListNewProduct(Product newProductToAdd);

   List<Product> GetAllProducts();
}