using System;
using System.Collections.Generic;
using System.Text;

namespace EvsZatcaQRCode
{
    public class TLV
    {
        static byte[] Seller;
        static byte[] VatNo;
        static byte[] dateTime;
        static byte[] Total;
        static byte[] Tax;

        public static string TLVs(String Seller, String TaxNo, DateTime dateTime, Double Total, Double Tax)
        {
            TLV.Seller = Encoding.UTF8.GetBytes(Seller);
            TLV.VatNo = Encoding.UTF8.GetBytes(TaxNo);

            TLV.dateTime = Encoding.UTF8.GetBytes(dateTime.ToString());
            TLV.Total = Encoding.UTF8.GetBytes(Total.ToString());
            TLV.Tax = Encoding.UTF8.GetBytes(Tax.ToString());
            return ToBase64();
        }

        private String getasText(int Tag, byte[] Value)
        {
            return (Tag).ToString("X2") + (Value.Length).ToString("X2") + BitConverter.ToString(Value).Replace("-", string.Empty);
        }

        private static byte[] getBytes(int id, byte[] Value)
        {
            byte[] val = new byte[2 + Value.Length];
            val[0] = (byte)id;
            val[1] = (byte)Value.Length;
            Value.CopyTo(val, 2);
            return val;
        }

        private String getString()
        {
            String TLV_Text = "";
            TLV_Text += this.getasText(1, TLV.Seller);
            TLV_Text += this.getasText(2, TLV.VatNo);
            TLV_Text += this.getasText(3, TLV.dateTime);
            TLV_Text += this.getasText(4, TLV.Total);
            TLV_Text += this.getasText(5, TLV.Tax);
            return TLV_Text;
        }

        public override string ToString()
        {
            return this.getString();
        }

        private static String ToBase64()
        {
            List<byte> TLV_Bytes = new List<byte>();
            TLV_Bytes.AddRange(getBytes(1, TLV.Seller));
            TLV_Bytes.AddRange(getBytes(2, TLV.VatNo));
            TLV_Bytes.AddRange(getBytes(3, TLV.dateTime));
            TLV_Bytes.AddRange(getBytes(4, TLV.Total));
            TLV_Bytes.AddRange(getBytes(5, TLV.Tax));
            return Convert.ToBase64String(TLV_Bytes.ToArray());
        }
    }
}
