﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Business
{
    class RequestApis
    {

        private static string APIUrl = "http://localhost:5001/api/prom/GetAllEmployees";
        public static async void GetDataWithoutAuthentication()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(APIUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(APIUrl);

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var rawResponse = readTask.GetAwaiter().GetResult();
                    Console.WriteLine(rawResponse);
                }
                Console.WriteLine("Complete");
            }
        }

    }


}
