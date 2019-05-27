using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sales_mvc.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} required")]
        [StringLength(60, MinimumLength =5,ErrorMessage ="NOME DEVE TER ENTRE 5 E 50 CARACTERES")]
        public string Name { get; set; }


        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "{0} required")]
        [Display(Name="Birth Date")]
        [DisplayFormat(DataFormatString ="{0:dd:MM:yyyy}")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        [Range(100.0,50000, ErrorMessage ="{0} must be from {1} to {2}")]
        [Required(ErrorMessage = "{0} required")]
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
