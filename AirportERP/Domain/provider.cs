using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class provider
    {
        public provider()
        {
            this.meals = new List<meal>();
        }

        public int id { get; set; }
        public string companyName { get; set; }
        public string email { get; set; }
        public string managerName { get; set; }
        public string password { get; set; }
        public byte[] phoneNumber { get; set; }
        public virtual ICollection<meal> meals { get; set; }
    }
}
