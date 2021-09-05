using System.Threading.Tasks;
using NUnit.Framework;

namespace TripEssential.BLL.UnitTest
{
    public class GetTripItemsUnitTest
    {
        [SetUp]
        public void Setup()
        {
            FirmamentUtilities.Utilities.DatabaseHelper.ConnectionString = UnitTestHelper.ConnectionString;
        }

        [Test]
        public async Task GetTripItems()
        {
            await TripEssentialBLL.TripItemHelper.GetTripItems();

            Assert.Pass();
        }
    }
}