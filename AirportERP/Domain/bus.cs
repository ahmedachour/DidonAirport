using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class bus
    {
        public bus()
        {
            this.flights = new List<flight>();
        }

        public long id { get; set; }
        public string matricule { get; set; }
        public long effectif { get; set; }
        public virtual ICollection<flight> flights { get; set; }
    }
}
