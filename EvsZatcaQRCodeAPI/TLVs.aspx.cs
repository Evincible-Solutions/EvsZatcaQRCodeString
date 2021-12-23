using EvsZatcaQRCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvsZatcaQRCodeAPI
{
    public partial class TLVs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Seller = string.Empty;
            Seller = Request.QueryString["Seller"];
            string TaxNo = string.Empty;
            TaxNo = Request.QueryString["TaxNo"];
            string dateTime = string.Empty;
            dateTime = Request.QueryString["dateTime"];
            string Total = string.Empty;
            Total = Request.QueryString["Total"];
            string Tax = string.Empty;
            Tax = Request.QueryString["Tax"];
            if (!String.IsNullOrWhiteSpace(Seller) && !String.IsNullOrWhiteSpace(TaxNo) && !String.IsNullOrWhiteSpace(dateTime) && !String.IsNullOrWhiteSpace(Total) && !String.IsNullOrWhiteSpace(Tax))
            {
                double _Total;
                double _Tax;
                try
                {
                    _Total = Convert.ToDouble(Total);
                }
                catch (Exception ex)
                {
                    throw new Exception("Invalid Total Amount ",ex);
                }
                try
                {
                    _Tax = Convert.ToDouble(Tax);
                }
                catch (Exception ex)
                {
                    throw new Exception("Invalid Tax Amount ", ex);
                }
                Response.Write(TLV.TLVs(Seller,TaxNo, dateTime, _Total,_Tax));
            }
            else
            {
                Response.Write("Seller, VAT No, Datetime, Total Amount, Tax Amount is required");
            }
            
        }
    }
}