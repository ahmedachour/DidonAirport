using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class baggage
    {
        public long id { get; set; }
        public float weight { get; set; }
        public Nullable<int> idUser { get; set; }
        public Nullable<int> idFlight { get; set; }
        public virtual flight flight { get; set; }
        public virtual user user { get; set; }
    }
}
