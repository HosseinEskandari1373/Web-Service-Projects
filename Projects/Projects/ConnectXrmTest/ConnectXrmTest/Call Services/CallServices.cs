using ConnectXRM_Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectXRM_Test.Call_Services
{
    public class CallServices
    {
        public object Entities()
        {
            try
            {
                //Select the Operation CRUD type To call the API
                Console.WriteLine("\n" + "Please enter the type of operation:");
                string crud = Console.ReadLine();

                switch (crud)
                {
                    //-------------------Contact-----------------------//
                    case "createcontact":
                        {
                            _ = CRUD.CreateContact();
                            break;
                        }
                    case "readcontact":
                        {
                            CRUD.ReadContact().Wait();
                            break;
                        }
                    case "updatecontact":
                        {
                            _ = CRUD.UpdateContact();
                            break;
                        }
                    case "deletecontact":
                        {
                            CRUD.DeleteContact();
                            break;
                        }

                    //-------------------Account-----------------------//
                    case "createaccount":
                        {
                            _ = CRUD.CreateAccount();
                            break;
                        }
                    case "readaccount":
                        {
                            CRUD.ReadAccount().Wait();
                            break;
                        }
                    case "updateaccount":
                        {
                            _ = CRUD.UpdateAccount();
                            break;
                        }
                    case "deleteaccount":
                        {
                            CRUD.DeleteAccount();
                            break;
                        }

                    default:
                        Console.WriteLine("Invalid Command");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!" + ex.Message);
                Console.ReadLine();
            }
            return null;
        }        
    }
}
