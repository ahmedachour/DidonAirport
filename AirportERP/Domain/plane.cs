using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class plane
    {
        public plane()
        {
            this.flights = new List<flight>();
        }

        public long id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public long effectif { get; set; }
        public Nullable<long> idRunway { get; set; }
        public virtual ICollection<flight> flights { get; set; }
        public virtual runway runway { get; set; }
    }
}
