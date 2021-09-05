using System.Threading.Tasks;
using NUnit.Framework;

namespace TripEssential.BLL.UnitTest
{
    public class GetKnapsackCapacityUnitTest
    {
        [SetUp]
        public void Setup()
        {
            FirmamentUtilities.Utilities.DatabaseHelper.ConnectionString = UnitTestHelper.ConnectionString;
        }

        [Test]
        public async Task GetKnapsackCapacity()
        {
            await TripEssentialBLL.TripItemHelper.GetKnapsackCapacity();

            Assert.Pass();
        }
    }
}