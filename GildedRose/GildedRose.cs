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
            for (var i = 0; i < Items.Count; i++)
            {
                var itemName = Items[i].Name;

                if (NotLegendaryItem(itemName))
                {
                    if (NormalItem(itemName))
                    {
                        CheckAndDecreaseQuality(Items[i]);
                    }
                    else
                    {
                        CheckAndIncreaseQuality(Items[i]);
                        ConcertQualityRules(Items[i]);
                    }

                    ReduceSellInTime(Items[i]);

                    if (SellByPassed(Items[i]))
                    {
                        if (itemName != "Aged Brie")
                        {
                            if (itemName != "Backstage passes to a TAFKAL80ETC concert")
                            {
                                CheckAndDecreaseQuality(Items[i]);
                            }
                            else
                            {
                                Items[i].Quality = 0;
                            }
                        }
                        else
                        {
                            CheckAndIncreaseQuality(Items[i]);
                        }
                    }
                }
            }
        }

        private void CheckAndDecreaseQuality(Item item)
        {
            if (NotMinQuality(item.Quality))
            {
                ReduceQuality(item);
            }
        }

        private bool NotMinQuality(int checkNumber)
        {
            return checkNumber > 0;
        }

        private void ConcertQualityRules(Item item)
        {
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.SellIn < 11)
                {
                    CheckAndIncreaseQuality(item);

                }

                if (item.SellIn < 6)
                {
                    CheckAndIncreaseQuality(item);
                }
            }
        }

        private static bool NormalItem(string itemName)
        {
            return itemName != "Aged Brie" && itemName != "Backstage passes to a TAFKAL80ETC concert";
        }

        private static bool NotLegendaryItem(string itemName)
        {
            return itemName != "Sulfuras, Hand of Ragnaros";
        }

        private void CheckAndIncreaseQuality(Item item)
        {
            if (NotMaxQuality(item.Quality))
            {
                IncreaseQuality(item);
            }
        }

        private bool NotMaxQuality(int checkNumber)
        {
            return checkNumber < 50;
        }

        private bool SellByPassed(Item item)
        {
            return item.SellIn < 0;
        }

        private void ReduceSellInTime(Item item)
        {
            item.SellIn -= 1;
        }

        private void ReduceQuality(Item item)
        {
            item.Quality -= 1;
        }

        private void IncreaseQuality(Item item)
        {
            item.Quality += 1;
        }

    }
}
