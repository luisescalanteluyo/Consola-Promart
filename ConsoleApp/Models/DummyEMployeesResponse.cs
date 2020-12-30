using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Models
{
    public class DummyEMployeesResponse
    {
         
        public string status { get; set; }
        public List<Employees> data { get; set; }

        public string message { get; set; }
    }
}
