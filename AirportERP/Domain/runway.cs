using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class runway
    {
        public runway()
        {
            this.planes = new List<plane>();
        }

        public long id { get; set; }
        public string name { get; set; }
        public long digitalNumber { get; set; }
        public virtual ICollection<plane> planes { get; set; }
    }
}
