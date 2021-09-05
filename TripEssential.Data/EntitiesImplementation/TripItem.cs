
namespace TripEssential.Data.Entities
{
    public partial class TripItem
    {
        public decimal WeightInKgs
        {
            get
            {
                return WeightInGrams / 1000;
            }
        }
    }
}
