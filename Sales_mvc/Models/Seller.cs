using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sales_mvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name="Birth Date")]
        [DisplayFormat(DataFormatString ="{0:dd:MM:yyyy}")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString ="{0:f2}")]
        public double BaseSalary { get; set; }
        public Department department { get; set; }
        public int departmentId { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDay, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDay = birthDay;
            BaseSalary = baseSalary;
            this.department = department;
        }

        public void AddSales(SalesRecord salesRecord)
        {
            Sales.Add(salesRecord);
        }

        public void RemoveSales(SalesRecord salesRecord)
        {
            Sales.Remove(salesRecord);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amoount);
        }
    }
}
