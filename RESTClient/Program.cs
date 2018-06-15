using Newtonsoft.Json;
using System;

namespace ProductToConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Get all products  : 1 ");
                Console.WriteLine("Get product by ID : 2 ");
                Console.WriteLine("Change product    : 3 ");
                Console.WriteLine("Delete product    : 4 ");
                Console.WriteLine("Add product       : 5 ");
                Console.WriteLine("Close             : 6 ");
                Console.Write("Enter your choice : ");

                // User enter number 
                var choice = Console.ReadLine();


                switch (choice)
                {
                    // if choice is 1, the program will return all products
                    case "1":
                        HTTPWebRequests.Get();
                        break;

                    // if choice is 2, the program will return product which have given id
                    case "2":
                        Console.Write("Enter ID : ");
                        var id = Console.ReadLine();
                        HTTPWebRequests.Get(id);
                        break;


                    // if choice is 1, the program will change product which have given id
                    case "3":
                        Console.Write("Enter id : ");
                        var id1 = int.Parse(Console.ReadLine());
                        Console.Write("Enter name : ");
                        var name1 = Console.ReadLine();
                        Console.Write("Enter price : ");
                        var price1 = double.Parse(Console.ReadLine());
                        HTTPWebRequests.Put(JsonConvert.SerializeObject(new Product(id1, name1, price1), Formatting.Indented), "text/json");
                        break;


                    // if choice is 1, the program will delete product which have given id
                    case "4":
                        Console.Write("Enter id : ");
                        var id2 = int.Parse(Console.ReadLine());
                        HTTPWebRequests.Delete(JsonConvert.SerializeObject(new Product(id2, null, null), Formatting.Indented), "text/json");
                        break;


                    // if choice is 1, the program will add given product
                    case "5":
                        Console.Write("Enter name : ");
                        var name = Console.ReadLine();
                        Console.Write("Enter price : ");
                        var price = double.Parse(Console.ReadLine());
                        HTTPWebRequests.Post(JsonConvert.SerializeObject(new Product(null, name, price), Formatting.Indented), "text/json");
                        break;

                    // End of program
                    case "6":
                        Console.WriteLine("Bye!");
                        break;

                    // if choice is incorrect, the program gives new chance
                    default:
                        Console.WriteLine("Incorrect choice!");
                        break;
                }

                if (choice == "6")
                    break;
            }

            Console.ReadLine();

        }
    }
}
