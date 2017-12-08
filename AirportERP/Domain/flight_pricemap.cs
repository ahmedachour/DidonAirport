using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class flight_pricemap
    {
        public int Flight_id { get; set; }
        public Nullable<float> priceMap { get; set; }
        public int priceMap_KEY { get; set; }
        public virtual flight flight { get; set; }
    }
}
