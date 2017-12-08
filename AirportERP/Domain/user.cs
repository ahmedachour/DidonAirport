using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class user
    {
        public user()
        {
            this.baggages = new List<baggage>();
            this.carbookings = new List<carbooking>();
            this.meals = new List<meal>();
            this.tickets = new List<ticket>();
        }

        public string function { get; set; }
        public int id { get; set; }
        public Nullable<System.DateTime> birth_date { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string password { get; set; }
        public byte[] phone_number { get; set; }
        public string sexe { get; set; }
        public string department { get; set; }
        public string position { get; set; }
        public Nullable<long> idStaff { get; set; }
        public virtual ICollection<baggage> baggages { get; set; }
        public virtual ICollection<carbooking> carbookings { get; set; }
        public virtual ICollection<meal> meals { get; set; }
        public virtual staff staff { get; set; }
        public virtual ICollection<ticket> tickets { get; set; }
    }
}
