using System;
using System.Collections.Generic;

#nullable disable

namespace TripEssential.Data.Entities
{
    public partial class TripItem
    {
        public TripItem()
        {
            Knapsacks = new HashSet<Knapsack>();
        }

        public Guid TripItemId { get; set; }
        public string ItemName { get; set; }
        public decimal WeightInGrams { get; set; }
        public int Ranking { get; set; }

        public virtual ICollection<Knapsack> Knapsacks { get; set; }
    }
}
