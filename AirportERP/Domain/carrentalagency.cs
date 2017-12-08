using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class carrentalagency
    {
        public carrentalagency()
        {
            this.cars = new List<car>();
        }

        public int id { get; set; }
        public string company_name { get; set; }
        public string email { get; set; }
        public string manager_name { get; set; }
        public string password { get; set; }
        public byte[] phone_number { get; set; }
        public virtual ICollection<car> cars { get; set; }
    }
}
