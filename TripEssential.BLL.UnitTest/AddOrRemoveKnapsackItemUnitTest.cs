using System;
using System.Threading.Tasks;
using NUnit.Framework;
using TripEssential.BLL.DataContract;

namespace TripEssential.BLL.UnitTest
{
    public class AddOrRemoveKnapsackItemUnitTest
    {
        [SetUp]
        public void Setup()
        {
            FirmamentUtilities.Utilities.DatabaseHelper.ConnectionString = UnitTestHelper.ConnectionString;
        }

        [Test]
        public async Task AddOrRemoveKnapsackItem()
        {
            await TripEssentialBLL.TripItemHelper.AddOrRemoveKnapsackItem(new AddOrRemoveKnapsackItemReq { TripItemId = Guid.Parse("ab6e3eac-4cf6-4d32-b058-6a45e2b2beda") });

            Assert.Pass();
        }
    }
}