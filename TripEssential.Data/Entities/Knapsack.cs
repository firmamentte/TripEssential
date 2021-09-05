using System;
using System.Collections.Generic;

#nullable disable

namespace TripEssential.Data.Entities
{
    public partial class Knapsack
    {
        public Guid KnapsackId { get; set; }
        public Guid TripItemId { get; set; }
        public DateTime DeletionDate { get; set; }

        public virtual TripItem TripItem { get; set; }
    }
}
