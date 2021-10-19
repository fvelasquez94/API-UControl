using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucontrol_API.Models
{
    public class Cuerpo_cotizacion
    {
        public string _id { get; set; }
        public string ProductName { get; set; }
        public string ShortName { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public double Price { get; set; }
        public double SubTotal { get; set; }
        public string Measure { get; set; }
        public string CodProduct { get; set; }
        public string CustomerQuote { get; set; }
        public bool OnRequest { get; set; }
        public int GrossSellPrice { get; set; }

    }
}