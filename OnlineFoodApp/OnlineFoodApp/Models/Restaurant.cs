using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineFoodApp.Models
{
    public class Restaurant
    {

        public int id { get; set; }
        public string displayName { get; set; }
        public string address { get; set; }
        public int priceForTwo { get; set; }
        public int adminId { get; set; }
    }
}
