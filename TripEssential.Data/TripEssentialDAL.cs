using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TripEssential.Data.Entities;

namespace TripEssential.Data
{
    public static class TripEssentialDAL
    {
        public static async Task<TripItem> GetTripItemByTripItemId(TripEssentialContext dbContext, Guid tripItemId)
        {
            try
            {
                return await (from tripItem in dbContext.TripItems.Cast<TripItem>()
                              where tripItem.TripItemId == tripItemId
                              select tripItem).
                              FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<decimal> GetKnapsackCapacity(TripEssentialContext dbContext)
        {
            try
            {
                decimal capacityInGrams = await (from knapsack in dbContext.Knapsacks.Cast<Knapsack>()
                                                 where knapsack.DeletionDate == FirmamentUtilities.Utilities.DateHelper.DefaultDate
                                                 select knapsack.TripItem.WeightInGrams).
                                                 SumAsync();

                return capacityInGrams / 1000;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<Knapsack> GetKnapsackByTripItemId(TripEssentialContext dbContext, Guid tripItemId)
        {
            try
            {
                return await (from knapsack in dbContext.Knapsacks.Cast<Knapsack>()
                              where knapsack.TripItemId == tripItemId &&
                                    knapsack.DeletionDate == FirmamentUtilities.Utilities.DateHelper.DefaultDate
                              select knapsack).
                              FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<List<TripItem>> GetTripItems(TripEssentialContext dbContext)
        {
            try
            {
                List<string> _knapsackItemNames = await (from knapsack in dbContext.Knapsacks.Cast<Knapsack>()
                                                         where knapsack.DeletionDate == FirmamentUtilities.Utilities.DateHelper.DefaultDate
                                                         select knapsack.ItemName).
                                                         ToListAsync();

                return await (from tripItem in dbContext.TripItems.Cast<TripItem>()
                              where !_knapsackItemNames.Contains(tripItem.ItemName)
                              select tripItem).
                              ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<List<Knapsack>> GetKnapsacktems(TripEssentialContext dbContext)
        {
            try
            {
                return await (from knapsack in dbContext.Knapsacks.Cast<Knapsack>()
                              where knapsack.DeletionDate == FirmamentUtilities.Utilities.DateHelper.DefaultDate
                              select knapsack).
                              ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<bool> IsKnapsackFull(TripEssentialContext dbContext, decimal weightInGramsToAdd)
        {
            try
            {

                decimal _weightInGrams = await (from knapsack in dbContext.Knapsacks.Cast<Knapsack>()
                                                join tripItem in dbContext.TripItems.Cast<TripItem>()
                                                on knapsack.TripItemId equals tripItem.TripItemId
                                                where knapsack.DeletionDate == FirmamentUtilities.Utilities.DateHelper.DefaultDate
                                                select tripItem.WeightInGrams).
                                                SumAsync();

                if (weightInGramsToAdd + _weightInGrams <= 4000M)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
