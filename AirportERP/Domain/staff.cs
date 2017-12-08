using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class staff
    {
        public staff()
        {
            this.flights = new List<flight>();
            this.users = new List<user>();
        }

        public long id { get; set; }
        public string name { get; set; }
        public long effectif { get; set; }
        public virtual ICollection<flight> flights { get; set; }
        public virtual ICollection<user> users { get; set; }
    }
}
