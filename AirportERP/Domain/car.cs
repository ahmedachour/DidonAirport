using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class car
    {
        public car()
        {
            this.carbookings = new List<carbooking>();
        }

        public int id { get; set; }
        public string brand { get; set; }
        public Nullable<int> category { get; set; }
        public string description { get; set; }
        public float price { get; set; }
        public string registrationNumber { get; set; }
        public Nullable<int> state { get; set; }
        public Nullable<int> idCarRentalAgency { get; set; }
        public virtual carrentalagency carrentalagency { get; set; }
        public virtual ICollection<carbooking> carbookings { get; set; }
    }
}
