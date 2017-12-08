using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class flight_freeplacesmap
    {
        public int Flight_id { get; set; }
        public Nullable<int> freePlacesMap { get; set; }
        public int freePlacesMap_KEY { get; set; }
        public virtual flight flight { get; set; }
    }
}
