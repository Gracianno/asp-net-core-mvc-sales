using System;
using Sales_mvc.Models.Enuns;

namespace Sales_mvc.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amoount { get; set; }
        public SalesStatus Status { get; set; }

        public Seller seller { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amoount, SalesStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amoount = amoount;
            Status = status;
            this.seller = seller;
        }
    }
}
