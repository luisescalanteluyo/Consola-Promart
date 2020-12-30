using ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void   Main(string[] args)
        {
            Console.WriteLine("Inicio Consola");
               
            GetApi_Dummyemployees();
            //  GetApi_Dummyemployees();

            Console.WriteLine("Fin Consola");

            Console.ReadLine();
        }

        //APi privada - realizado como proyecto
        static void GetApi_GetAllEmployees()
        {
            string APIUrl = "http://localhost:5001/api/prom/GetAllEmployees";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(APIUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response =  client.GetAsync(APIUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var rawResponse = readTask.GetAwaiter().GetResult();
                    Console.WriteLine(rawResponse);
                }
            }

           
        }


        //APi publica
        static void GetApi_Dummyemployees()
        {
            string APIUrl = "http://dummy.restapiexample.com/api/v1/employees";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(APIUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(APIUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var rawResponse = readTask.GetAwaiter().GetResult();

                    Console.WriteLine(rawResponse);

                    DummyEMployeesResponse ModelJson=  JsonConvert.DeserializeObject<DummyEMployeesResponse>(rawResponse);

                    Console.WriteLine(ModelJson);
                }
            }

        }


    }
}
