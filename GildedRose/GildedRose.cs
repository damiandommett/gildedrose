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
                    if (ItemHelper.NormalItem(itemName))
                    {
                        ItemHelper.CheckAndDecreaseQuality(item);
                        if (itemName == "Conjured Mana Cake")
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
                        if (ItemHelper.NormalItem(itemName))
                        {
                            ItemHelper.CheckAndDecreaseQuality(item);
                        }
                        else if (itemName == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            item.Quality = 0;
                        }
                        else if (itemName == "Aged Brie")
                        {
                            ItemHelper.CheckAndIncreaseQuality(item);
                        }
                    }
                }
            }
        }

    }
}
