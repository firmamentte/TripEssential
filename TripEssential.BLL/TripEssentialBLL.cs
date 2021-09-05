using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TripEssential.BLL.DataContract;
using TripEssential.Data;
using TripEssential.Data.Entities;

namespace TripEssential.BLL
{
    public static class TripEssentialBLL
    {
        public static void InitialiseConnectionString(IConfiguration configuration)
        {
            try
            {
                if (configuration != null)
                {
                    if (string.IsNullOrWhiteSpace(FirmamentUtilities.Utilities.DatabaseHelper.ConnectionString))
                    {
                        FirmamentUtilities.Utilities.DatabaseHelper.ConnectionString = configuration.GetConnectionString("DatabasePath");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetEnumDescription(Enum enumValue)
        {
            return FirmamentUtilities.Utilities.GetEnumDescription(enumValue);
        }

        public static class TripItemHelper
        {
            public static async Task<List<TripItemResp>> GetTripItems()
            {
                try
                {
                    using TripEssentialContext _dbContext = new();

                    List<TripItemResp> _tripItemResps = new();

                    foreach (var tripItem in await TripEssentialDAL.GetTripItems(_dbContext))
                    {
                        _tripItemResps.Add(FillTripItemResp(tripItem));
                    }

                    return _tripItemResps;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            public static async Task<List<TripItemResp>> GetKnapsacktems()
            {
                try
                {
                    using TripEssentialContext _dbContext = new();

                    List<TripItemResp> _tripItemResps = new();

                    foreach (var knapsack in await TripEssentialDAL.GetKnapsacktems(_dbContext))
                    {
                        _tripItemResps.Add(FillTripItemResp(knapsack.TripItem));
                    }

                    return _tripItemResps;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            public static async Task<decimal> GetKnapsackCapacity()
            {
                try
                {
                    using TripEssentialContext _dbContext = new();

                    return await TripEssentialDAL.GetKnapsackCapacity(_dbContext);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            public static async Task AddOrRemoveKnapsackItem(AddOrRemoveKnapsackItemReq addOrRemoveKnapsackItemReq)
            {
                try
                {
                    using TripEssentialContext _dbContext = new();

                    Knapsack _knapsack = await TripEssentialDAL.GetKnapsackByTripItemId(_dbContext, addOrRemoveKnapsackItemReq.TripItemId);

                    if (_knapsack is null)
                    {
                        TripItem _tripItem = await TripEssentialDAL.GetTripItemByTripItemId(_dbContext, addOrRemoveKnapsackItemReq.TripItemId);

                        if (_tripItem is null)
                        {
                            throw new Exception("Invalid TripItemId. The resource has been removed, had its name changed, or is unavailable.");
                        }

                        if (await TripEssentialDAL.IsKnapsackFull(_dbContext, _tripItem.WeightInGrams))
                        {
                            throw new Exception("Knapsack bag capacity is 4kg");
                        }

                        _knapsack = new()
                        {
                            TripItem = await TripEssentialDAL.GetTripItemByTripItemId(_dbContext, addOrRemoveKnapsackItemReq.TripItemId),
                            DeletionDate = FirmamentUtilities.Utilities.DateHelper.DefaultDate
                        };

                        _dbContext.Knapsacks.Add(_knapsack);
                    }
                    else
                    {
                        _knapsack.DeletionDate = DateTime.Now;
                    }

                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            private static TripItemResp FillTripItemResp(TripItem tripItem)
            {
                try
                {
                    return new TripItemResp()
                    {
                        TripItemId = tripItem.TripItemId,
                        ItemName = tripItem.ItemName,
                        WeightInKgs = tripItem.WeightInKgs,
                        Ranking = tripItem.Ranking
                    };
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
