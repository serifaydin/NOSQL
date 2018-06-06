using System;

namespace CA_MongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService productService = ProductService.ProductClientAsSingleton();
            //productService.ProductInsert();
            //productService.ProductList();
            //productService.ProductUpdate("5b17a2be59609e359032d21d");
            //productService.ProductDelete("5b17a2be59609e359032d21d");
            productService.ProductListWhere(false);

            Console.ReadKey();
        }
    }
}