using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var itemName = item.Name;

                if (ItemHelper.NotLegendaryItem(itemName))
                {
                    var isNormalItem = ItemHelper.NormalItem(itemName);
                    if (isNormalItem)
                    {
                        ItemHelper.CheckAndDecreaseQuality(item);
                        if (ItemHelper.IsConjured(itemName))
                        {
                            ItemHelper.CheckAndDecreaseQuality(item);
                        }
                    }
                    else
                    {
                        ItemHelper.CheckAndIncreaseQuality(item);
                        ItemHelper.ConcertQualityRules(item);
                    }

                    ItemHelper.ReduceSellInTime(item);

                    if (ItemHelper.SellByPassed(item))
                    {
                        if (isNormalItem)
                        {
                            ItemHelper.CheckAndDecreaseQuality(item);
                        }
                        else if (ItemHelper.IsTicket(itemName))
                        {
                            item.Quality = 0;
                        }
                        else if (ItemHelper.IsBrie(itemName))
                        {
                            ItemHelper.CheckAndIncreaseQuality(item);
                        }
                    }
                }
            }
        }

    }
}
