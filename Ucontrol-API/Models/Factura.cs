using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucontrol_API.Models
{
    public class Factura
    {
        public CabeceraFactura cabeceraFactura { get; set; }
        public List<CuerpoFactura> cuerpoFactura { get; set; }
        public string templatename { get; set; }
        public string tipodoc { get; set; }
        public Footer footer { get; set; }
    }

    public class Impuestos
    {
        public string Clasificacion { get; set; }
        public string IVA { get; set; }
        public string IVA2 { get; set; }
        public string Retencion { get; set; }
    }

    public class Footer
    {
        public Impuestos Impuestos { get; set; }
        public double SumasSubtotales { get; set; }
   
    }

    public class Customer
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string codCustomer { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string MobilPhone { get; set; }
        public string idNumber { get; set; }
        public bool Access { get; set; }
        public int PaymentTime { get; set; }
        public string Discount { get; set; }
        public string User { get; set; }
        public bool Active { get; set; }
        public string Company { get; set; }
        public string Ncr { get; set; }
        public Sector Sector { get; set; }
        public object Sector1 { get; set; }
        public object Sector2 { get; set; }
        public string Nit { get; set; }
        public string TypeofTaxpayer { get; set; }
        public string PaymentCondition { get; set; }
        public string Classification { get; set; }
        public bool Exempt { get; set; }
        public string Contributor { get; set; }
        public int __v { get; set; }
        public double AccountsReceivable { get; set; }
    }

    public class Sector
    {
        public string _id { get; set; }
        public string Categoria { get; set; }
        public string CodMin { get; set; }
        public string Name { get; set; }
        public string SubCategoria { get; set; }
        public string __v { get; set; }
    }

    public class Company
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string ShortName { get; set; }
        public string Web { get; set; }
        public bool Active { get; set; }
        public bool AccessToCustomers { get; set; }
        public bool AccessToSuppliers { get; set; }
        public bool RequieredIncome { get; set; }
        public bool RequieredOutput { get; set; }
        public bool CompanyRecords { get; set; }
        public bool WorksOpenQuote { get; set; }
        public int DaysQuotationValidity { get; set; }
        public int DaysOrderValidity { get; set; }
        public bool AvailableReservation { get; set; }
        public bool OrderWithWallet { get; set; }
        public bool AverageCost { get; set; }
        public int InvoiceLines { get; set; }
        public string Nit { get; set; }
        public string Ncr { get; set; }
        public object ActividadPrimaria { get; set; }
        public object ActividadSecundaria { get; set; }
        public object ActividadTerciaria { get; set; }
        public string Imprenta { get; set; }
        public int __v { get; set; }
        public string Address { get; set; }
        public int AccountingLevels { get; set; }
        public string TemplateCreditoFiscal { get; set; }
    }

    public class User
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public DateTime LastLogin { get; set; }
        public bool Active { get; set; }
        public string Image { get; set; }
        public string UserName { get; set; }
        public Company Company { get; set; }
        public string Rol { get; set; }
        public string Profile { get; set; }
        public int __v { get; set; }
    }

    public class DocumentType
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string Referencia { get; set; }
        public int __v { get; set; }
    }

    public class DocumentCorrelative
    {
        public string _id { get; set; }
        public string SerialNumberRange { get; set; }
        public string NResolucion { get; set; }
        public int StartNumber { get; set; }
        public int EndNumber { get; set; }
        public int CurrentNumber { get; set; }
        public bool State { get; set; }
        public DocumentType DocumentType { get; set; }
        public string Company { get; set; }
        public int __v { get; set; }
    }

    public class CabeceraFactura
    {
        public string _id { get; set; }
        public int CodInvoice { get; set; }
        public Customer Customer { get; set; }
        public decimal Total { get; set; }
        public User User { get; set; }
        public DateTime CreationDate { get; set; }
        public string State { get; set; }
        public string InvoiceComments { get; set; }
        public string CommentsofSale { get; set; }
        public object SaleOrder { get; set; }
        public bool Pagada { get; set; }
        public bool Entregada { get; set; }
        public string InvoiceNumber { get; set; }
        public DocumentCorrelative DocumentCorrelative { get; set; }
        public decimal iva { get; set; }
        public int __v { get; set; }
        public DateTime InvoiceDate { get; set; }
    }

    public class SaleOrderInvoice
    {
        public string _id { get; set; }
        public int CodInvoice { get; set; }
        public string Customer { get; set; }
        public int Total { get; set; }
        public string User { get; set; }
        public DateTime CreationDate { get; set; }
        public string State { get; set; }
        public string InvoiceComments { get; set; }
        public string CommentsofSale { get; set; }
        public object SaleOrder { get; set; }
        public bool Pagada { get; set; }
        public bool Entregada { get; set; }
        public string InvoiceNumber { get; set; }
        public string DocumentCorrelative { get; set; }
        public int iva { get; set; }
        public int __v { get; set; }
        public DateTime InvoiceDate { get; set; }
    }

    public class Measure
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public int __v { get; set; }
    }

    public class Product
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double SellPrice { get; set; }
        public string ShortName { get; set; }
        public string CatProduct { get; set; }
        public string Supplier { get; set; }
        public Measure Measure { get; set; }
        public string Company { get; set; }
        public int MinStock { get; set; }
        public int MaxStock { get; set; }
        public bool Active { get; set; }
        public double BuyPrice { get; set; }
        public string codproducts { get; set; }
        public double AverageCost { get; set; }
        public string Classification { get; set; }
        public int __v { get; set; }
    }

    public class Inventory
    {
        public string _id { get; set; }
        public Product Product { get; set; }
        public double Stock { get; set; }
        public string Description { get; set; }
        public string Bodega { get; set; }
        public string Company { get; set; }
        public int __v { get; set; }
    }

    public class CuerpoFactura
    {
        public string _id { get; set; }
        public string ProductName { get; set; }
        public SaleOrderInvoice SaleOrderInvoice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public double Price { get; set; }
        public Inventory Inventory { get; set; }
        public double SubTotal { get; set; }
        public int Entregados { get; set; }
        public bool State { get; set; }
        public string Measure { get; set; }
        public string CodProduct { get; set; }
        public string Product { get; set; }
        public int iniQuantity { get; set; }
        public double BuyPrice { get; set; }
        public double PriceDiscount { get; set; }
        public int __v { get; set; }
    }


}