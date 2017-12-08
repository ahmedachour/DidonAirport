using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class ticket
    {
        public int idFlight { get; set; }
        public int idPassenger { get; set; }
        public Nullable<int> flightCategory { get; set; }
        public float price { get; set; }
        public virtual flight flight { get; set; }
        public virtual user user { get; set; }
    }
}
