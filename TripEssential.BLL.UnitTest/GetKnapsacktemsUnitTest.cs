using System.Threading.Tasks;
using NUnit.Framework;

namespace TripEssential.BLL.UnitTest
{
    public class GetKnapsacktemsUnitTest
    {
        [SetUp]
        public void Setup()
        {
            FirmamentUtilities.Utilities.DatabaseHelper.ConnectionString = UnitTestHelper.ConnectionString;
        }

        [Test]
        public async Task GetKnapsacktems()
        {
            await TripEssentialBLL.TripItemHelper.GetKnapsacktems();

            Assert.Pass();
        }
    }
}