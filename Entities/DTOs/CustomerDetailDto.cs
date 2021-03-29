using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerDetailDto:IDto
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; } //Ek User Adı
        public string LastName { get; set; } //Ek User Soyadı
        public string CompanyName { get; set; }

    }
}
