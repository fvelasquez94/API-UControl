using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucontrol_API.Models
{
    public class Cotizacion
    {
        public CabeceraCotizacion CabeceraCotizacion { get; set; }
        public List<CuerpoCotizacion> CuerpoCotizacion { get; set; }
        public FooterCot footer { get; set; }
        public string templatename { get; set; }
    }
    public class CustomerCot : Customer
    {//C:\Users\LENOVO\Desktop\Ucontrol-API\Ucontrol-API\Models\Cotizacion.cs
        public string Images { get; set; }
        public string CatCustomer { get; set; }
        //public string City { get; set; }
        //public string ZipCode { get; set; }
        //public string Country { get; set; }
    }

    public class CompanyCot : Company
    {
        public string TemplateConsumidorFinal { get; set; }
        public string TemplateTicket { get; set; }
        //public string Web { get; set; }
        //public string Address { get; set; }
    }

    public class UserCot : User
    {
        //public string Name { get; set; }
        //public string LastName { get; set; }

    }

    public class CabeceraCotizacion
    {
        public string _id { get; set; }
        public CustomerCot Customer { get; set; }
        public double Total { get; set; }
        public bool Active { get; set; }
        public UserCot User { get; set; }
        public string CreationDate { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public int CodCustomerQuote { get; set; }
        public string CustomerName { get; set; }
        public string DateUpdate { get; set; }
        public double SubTotal { get; set; }
        public string Company { get; set; }
        public string AddressedTo { get; set; }
        public int __v { get; set; }
    }


    public class ProductCot: Product
    {
        public string TypeProduct { get; set; }
 
    }

    public class InventoryCot : Inventory
    {

    }

    public class CuerpoCotizacion
    {
        public string _id { get; set; }
        public string ProductName { get; set; }
        public string CustomerQuote { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public double Price { get; set; }
        public InventoryCot Inventory { get; set; }
        public string Measure { get; set; }
        public string CodProduct { get; set; }
        public double SubTotal { get; set; }
        public bool OnRequest { get; set; }
        public int GrossSellPrice { get; set; }
        public int __v { get; set; }
    }


    public class FooterCot: Footer
    {
        public double Subtotal { get; set; }
        public double Total { get; set; }
    }


}