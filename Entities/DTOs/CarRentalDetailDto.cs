using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarRentalDetailDto:IDto
    {
        public int RentalId { get; set; } //Rental
        public string CompanyName { get; set; } //Customer
        public string CarName { get; set; } //Car
        public string BrandName { get; set; } //Brand
        public string ColorName { get; set; } //Color
        public decimal DailyPrice { get; set; } //Car
        public DateTime RentDate { get; set; } //Rental
        public DateTime? ReturnDate { get; set; } //Rental

    }
}
