using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Ucontrol_API.Context.BlobStorage;
using Ucontrol_API.Models;

namespace Ucontrol_API.Controllers
{
    public class ValuesController : ApiController
    {
        UploadService UService = new UploadService();
        // POST api/values
        [Route("api/generarfactura")]
        [HttpPost]
        public async Task<string> generarfactura([FromBody]Factura model)
        {
            try
            {
                if (model == null)
                {
                    return "Error, modelo de datos es nulo o no contiene la informacion con la estructura correcta.";
                }

                List<Cuerpo_factura> cuerpotopdf = new List<Cuerpo_factura>(); //clase con estructura de dataset en reporte, todo lo demas ira por parametro
                                                                               //extramos datos de json en model
                cuerpotopdf = model.cuerpoFactura.Select(c => new Cuerpo_factura
                {
                    _id = c._id,
                    BuyPrice = c.BuyPrice,
                    CodProduct = c.CodProduct,
                    Discount = c.Discount,
                    ShortName=c.Inventory.Product.ShortName,
                    Entregados = c.Entregados,
                    iniQuantity = c.iniQuantity,
                    Measure = c.Measure,
                    Price = c.Price,
                    PriceDiscount = c.PriceDiscount,
                    Product = c.Product,
                    ProductName = c.ProductName,
                    Quantity = c.Quantity,
                    State = c.State,
                    SubTotal = c.SubTotal
                }).ToList();

                //Comienzo generar reporte
                //verificar si hay datos
                if (cuerpotopdf.Count > 0)
                {
                    //Definir nombre de reporte aqui
                    var nombrereporte = "Factura_original.rpt"; //Evaluamos si ya fue configurado, si no es asi, se cargara el original
                    if (model.templatename != "NA")
                    {
                        nombrereporte = model.templatename + ".rpt";
                    }
                    else
                    {
                        nombrereporte = "Factura_original.rpt";
                    }


                    ReportDocument rd = new ReportDocument();

                    rd.Load(Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Reports"), nombrereporte));
                    rd.SetDataSource(cuerpotopdf);

                    var filePathOriginal = System.Web.HttpContext.Current.Server.MapPath("/Reports/pdfReports/");

                    System.Web.HttpContext.Current.Response.Buffer = false;
                    System.Web.HttpContext.Current.Response.ClearContent();
                    System.Web.HttpContext.Current.Response.ClearHeaders();


                    //Parametros **importante estos se dejaron por defecto
                    rd.SetParameterValue("Compania", model.cabeceraFactura.User.Company.Name);
                    rd.SetParameterValue("Nombre_cliente", model.cabeceraFactura.Customer.Name + " " + model.cabeceraFactura.Customer.LastName);
                    rd.SetParameterValue("Direccion", "");
                    rd.SetParameterValue("Municipio", "");
                    rd.SetParameterValue("Departamento", "");
                    rd.SetParameterValue("Fecha", model.cabeceraFactura.InvoiceDate.ToShortDateString());
                    rd.SetParameterValue("RegistroNo", "");
                   // rd.SetParameterValue("Giro", "");
                    rd.SetParameterValue("NIT", model.cabeceraFactura.Customer.Nit);
                    rd.SetParameterValue("Ventaacuentade", "");
                    rd.SetParameterValue("Formadepago", "");

                    //rd.SetParameterValue("Exempt", model.cabeceraFactura.Customer.Exempt);
                    //tomando el total
                    rd.SetParameterValue("Total", model.cabeceraFactura.Total);

                    //tomando el nrc del cliente
                    rd.SetParameterValue("Nrc", model.cabeceraFactura.Customer.Ncr);

                    //tomando el giro del cliente
                    rd.SetParameterValue("Giro", model.cabeceraFactura.Customer.Sector.Name);

                    //
                    //rd.SetParameterValue("CodSaleOrder", model.cabeceraFactura.saleOrder.CodSaleOrder);

                    //tomando la sumas de los subtotales
                    rd.SetParameterValue("SumasSubtotales", model.footer.SumasSubtotales);
                    rd.SetParameterValue("Retencion", model.footer.Impuestos.Retencion);
                    rd.SetParameterValue("iva", model.cabeceraFactura.iva);

                    //Tomando informacion del correlativo
                    rd.SetParameterValue("NResolucion", model.cabeceraFactura.DocumentCorrelative.NResolucion);

                    //guardamos en disco
                    rd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, filePathOriginal + model.cabeceraFactura._id + ".pdf");
                    rd.Dispose();
                    rd = null;

                    var pdfurl = await UService.UploadAsync(model.cabeceraFactura._id + ".pdf", filePathOriginal + model.cabeceraFactura._id + ".pdf");

                    return pdfurl;

                }
                else
                {
                    return "Error";
                }
            }
            catch (Exception ex)
            {
                return "Error on server: " + ex.Message;
            }
            

        }// POST api/values
        [Route("api/generarcotizacion")]
        [HttpPost]
        public async Task<string> generarcotizacion([FromBody]Cotizacion model)
        {
            try
            {
                if (model == null)
                {
                    return "Error, modelo de datos es nulo o no contiene la informacion con la estructura correcta.";
                }

                List<Cuerpo_cotizacion> cuerpotopdf = new List<Cuerpo_cotizacion>(); //clase con estructura de dataset en reporte, todo lo demas ira por parametro
                                                                               //extraemos datos de json en model
                cuerpotopdf = model.CuerpoCotizacion.Select(c => new Cuerpo_cotizacion
                {
                    _id = c._id,
                    CodProduct = c.CodProduct,
                    Discount = c.Discount,
                    Measure = c.Measure,
                    ShortName = c.Inventory.Product.ShortName,
                    Price = c.Price,
                    ProductName = c.ProductName,
                    Quantity = c.Quantity,
                    SubTotal = c.SubTotal,
                    CustomerQuote=c.CustomerQuote,
                    GrossSellPrice=c.GrossSellPrice,
                    OnRequest=c.OnRequest
                }).ToList();

                //Comienzo generar reporte
                //verificar si hay datos
                if (cuerpotopdf.Count > 0)
                {
                    //Definir nombre de reporte aqui
                    var nombrereporte = "Cotizacion_original.rpt"; //Evaluamos si ya fue configurado, si no es asi, se cargara el original
                    if (model.templatename != "NA")
                    {
                        nombrereporte = model.templatename + ".rpt";
                    }
                    else
                    {
                        nombrereporte = "Cotizacion_original.rpt";
                    }


                    ReportDocument rd = new ReportDocument();

                    rd.Load(Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Reports"), nombrereporte));
                    rd.SetDataSource(cuerpotopdf);

                    var filePathOriginal = System.Web.HttpContext.Current.Server.MapPath("/Reports/pdfReports/");

                    System.Web.HttpContext.Current.Response.Buffer = false;
                    System.Web.HttpContext.Current.Response.ClearContent();
                    System.Web.HttpContext.Current.Response.ClearHeaders();


                    //Parametros **importante estos se dejaron por defecto
                    rd.SetParameterValue("Company", model.CabeceraCotizacion.User.Company.Name);
                    rd.SetParameterValue("CustomerName", model.CabeceraCotizacion.Customer.Name + " " + model.CabeceraCotizacion.Customer.LastName);
                    rd.SetParameterValue("AddressedTo", model.CabeceraCotizacion.AddressedTo);
                    rd.SetParameterValue("State", model.CabeceraCotizacion.State);
                    rd.SetParameterValue("Description", model.CabeceraCotizacion.Description);
                    rd.SetParameterValue("Fecha", model.CabeceraCotizacion.CreationDate);
                    rd.SetParameterValue("SubTotal", model.footer.Subtotal);
                    rd.SetParameterValue("Total", model.footer.Total);
                    rd.SetParameterValue("NIT", model.CabeceraCotizacion.Customer.Nit);
                    rd.SetParameterValue("IVA", model.footer.Impuestos.IVA);
                    rd.SetParameterValue("DireccionCot", model.CabeceraCotizacion.Customer.City + ", " + model.CabeceraCotizacion.Customer.ZipCode + ", " + model.CabeceraCotizacion.Customer.Country);
                    rd.SetParameterValue("UserCot", model.CabeceraCotizacion.User.Name + " " + model.CabeceraCotizacion.User.LastName);
                    rd.SetParameterValue("Web", model.CabeceraCotizacion.User.Company.Web);
                    rd.SetParameterValue("Email", model.CabeceraCotizacion.User.Email);
                    rd.SetParameterValue("Address", model.CabeceraCotizacion.User.Company.Address);
                    rd.SetParameterValue("Retencion", model.footer.Impuestos.Retencion);
                    rd.SetParameterValue("CodCustomerQuote", model.CabeceraCotizacion.CodCustomerQuote);

                    //guardamos en disco
                    rd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, filePathOriginal + model.CabeceraCotizacion._id + ".pdf");
                    rd.Dispose();
                    rd = null;

                    var pdfurl = await UService.UploadAsync(model.CabeceraCotizacion._id + ".pdf", filePathOriginal + model.CabeceraCotizacion._id + ".pdf");

                    return pdfurl;

                }
                else
                {
                    return "Error";
                }
            }
            catch (Exception ex)
            {
                return "Error on server: " + ex.Message;
            }
            

        }

    }
}
