﻿using System;
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

                if (itemName != "Aged Brie" && itemName != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (itemName != "Sulfuras, Hand of Ragnaros")
                        {
                            ReduceQuality(Items[i]);
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        IncreaseQuality(Items[i]);

                        if (itemName == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    IncreaseQuality(Items[i]);
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    IncreaseQuality(Items[i]);
                                }
                            }
                        }
                    }
                }

                if (itemName != "Sulfuras, Hand of Ragnaros")
                {
                    ReduceSellInTime(Items[i]);
                }

                if (SellByPassed(Items[i]))
                {
                    if (itemName != "Aged Brie")
                    {
                        if (itemName != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (itemName != "Sulfuras, Hand of Ragnaros")
                                {
                                    ReduceQuality(Items[i]);
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = 0;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            IncreaseQuality(Items[i]);
                        }
                    }
                }
            }
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
