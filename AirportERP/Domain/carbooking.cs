using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class carbooking
    {
        public int idCar { get; set; }
        public int idPasssenger { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public float priceOfRent { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<int> idPassenger { get; set; }
        public virtual car car { get; set; }
        public virtual user user { get; set; }
    }
}
