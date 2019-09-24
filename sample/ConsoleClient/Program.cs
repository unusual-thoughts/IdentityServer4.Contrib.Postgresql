using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            var options = new TokenClientOptions
            {
                Address = "http://localhost:5000/connect/token",
                ClientId = "ro.client",
                ClientSecret = "secret"
            };
            var tokenClient = new TokenClient(httpClient, options);
            var tokenResponse = await tokenClient.RequestClientCredentialsTokenAsync("api1");
            Console.WriteLine("Error : {0}", tokenResponse.Error);
            Console.WriteLine("Token : {0}", tokenResponse.AccessToken);
            Console.Read();
        }
    }
}
