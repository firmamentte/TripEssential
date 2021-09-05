using System;

namespace TripEssential.BLL.DataContract
{
    public class TripItemResp
    {
        public Guid TripItemId { get; set; }
        public string ItemName { get; set; }
        public decimal WeightInKgs { get; set; }
        public int Ranking { get; set; }
    }
}
