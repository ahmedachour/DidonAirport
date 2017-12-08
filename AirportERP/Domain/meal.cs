using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class meal
    {
        public int id { get; set; }
        public Nullable<int> category { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<int> idPassenger { get; set; }
        public Nullable<int> idProvider { get; set; }
        public Nullable<int> idFlight { get; set; }
        public virtual flight flight { get; set; }
        public virtual provider provider { get; set; }
        public virtual user user { get; set; }
    }
}
