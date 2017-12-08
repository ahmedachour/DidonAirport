using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class flight
    {
        public flight()
        {
            this.baggages = new List<baggage>();
            this.tickets = new List<ticket>();
            this.meals = new List<meal>();
            this.flight_pricemap = new List<flight_pricemap>();
            this.flight_freeplacesmap = new List<flight_freeplacesmap>();
        }

        public int id { get; set; }
        public string company { get; set; }
        public Nullable<System.DateTime> date_arrival { get; set; }
        public Nullable<System.DateTime> date_departure { get; set; }
        public string destination { get; set; }
        public Nullable<long> idStaff { get; set; }
        public Nullable<long> idPlane { get; set; }
        public Nullable<long> idBus { get; set; }
        public virtual ICollection<baggage> baggages { get; set; }
        public virtual bus bus { get; set; }
        public virtual ICollection<ticket> tickets { get; set; }
        public virtual plane plane { get; set; }
        public virtual staff staff { get; set; }
        public virtual ICollection<meal> meals { get; set; }
        public virtual ICollection<flight_pricemap> flight_pricemap { get; set; }
        public virtual ICollection<flight_freeplacesmap> flight_freeplacesmap { get; set; }
    }
}
