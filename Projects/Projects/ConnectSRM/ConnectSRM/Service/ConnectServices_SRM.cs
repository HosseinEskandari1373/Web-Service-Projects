using System;
using System.ServiceModel.Description;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace ConnectSRM.Services
{
    public class ConnectServices_SRM
    {
        //Authentication and get service organization
        public static IOrganizationService GetOrganizationService(
            Uri url, string username, string password)
        {
            //Validation with ClientCredentials
            ClientCredentials credentials = new ClientCredentials();
            credentials.Windows.ClientCredential.UserName = username;
            credentials.Windows.ClientCredential.Password = password;
            OrganizationServiceProxy service = new OrganizationServiceProxy(url, null, credentials, null);

            //Check Out Service
            if (service == null)
            {
                throw new Exception("Unable to Establish Connection");
            }
            else
            {
                Console.WriteLine("Connection Sussefuly!");
            }

            //.ایجاد شده نوشتن خط زیر لازم است Service برای استفاده از Early-Bound در روش
            service.EnableProxyTypes();
            return service;
        }
    }
}