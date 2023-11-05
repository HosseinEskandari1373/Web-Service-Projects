using ConnectXRM_Test.Call_Services;
using System;

namespace TestConnectXRM
{
    public class Program
    {
        //Main
        public static void Main(string[] args)
        {
            //Select the entity type to call the corresponding API
            Console.WriteLine("Please select an entity type");
            string crud = Console.ReadLine();

            switch (crud)
            {
                case "account":
                    {
                        var account = new CallServices().Entities();
                        Console.WriteLine("\n" + account);
                        Console.ReadKey();
                        break;
                    }
                case "contact":
                    {
                        var contact = new CallServices().Entities();
                        Console.WriteLine("\n" + contact);
                        Console.ReadKey();
                        break;
                    }
                default:
                    Console.WriteLine("Invalid Command");
                    break;
            } 
        }
    }
}




