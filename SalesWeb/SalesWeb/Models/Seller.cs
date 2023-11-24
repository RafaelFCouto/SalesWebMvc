using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SalesWeb.Models
{
    public class Seller
    {

        public int  Id { get; set; }

        [Required (ErrorMessage = "{0} Required")]
        [StringLength(60, MinimumLength = 3,ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} Required")]
        [EmailAddress (ErrorMessage ="Enter a valid email")]
        public string Email { get; set; }




        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "{0} Required")]


        public DateTime BirthDate { get; set; }

        [DisplayFormat(DataFormatString ="{0:F2}")]
        [Range (100.0,50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [Required(ErrorMessage = "{0} Required")]
        public double Salary { get; set; }

        public Departament Departament { get; set; }


        public int DepartamentId { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double salary, Departament departament)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Salary = salary;
            Departament = departament;
        }


        public void AddSales(SalesRecord sr)
        {


            Sales.Add(sr);

        }

        public void RemoveSales (SalesRecord sr)
        {

            Sales.Remove(sr);


        }


        public double TotalSales (DateTime initial, DateTime finish)
        {


            return Sales.Where(sr => sr.Date >= initial && sr.Date <= finish).Sum(sr => sr.Amount);

        }



    }
}
