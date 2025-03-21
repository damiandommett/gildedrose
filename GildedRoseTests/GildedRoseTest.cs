﻿using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void create_named_item()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }

        [Fact]
        public void sell_in_time_reduces_each_day()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 2, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(1, Items[0].SellIn);
        }

        [Fact]
        public void sulfuras_sell_in_time_does_not_reduce_each_day()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 2, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(2, Items[0].SellIn);
        }

        [Fact]
        public void quality_reduces_each_day()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 2, Quality = 3 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(2, Items[0].Quality);
        }

        [Fact]
        public void sulfuras_quality_does_not_reduce_each_day()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 4, Quality = 3 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(3, Items[0].Quality);
        }


        [Fact]
        public void quality_cannot_be_negative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 3, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void if_sell_by_passed_quality_degrades_twice_as_fast()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = -1, Quality = 3 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(1, Items[0].Quality);
        }

        [Fact]
        public void if_sell_by_passed_for_concert_quality_is_zero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 4 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }
        [Fact]
        public void aged_brie_quality_increases_each_day()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 7, Quality = 2 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(3, Items[0].Quality);
        }

        [Fact]
        public void aged_brie_quality_cannot_exceed_fifty()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 7, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void sulfuras_quality_can_exceed_fifty()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 2, Quality = 90 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(90, Items[0].Quality);
        }

        [Fact]
        public void concert_quality_increases_by_one_more_than_ten_days_away()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 17, Quality = 6 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(7, Items[0].Quality);
        }

        [Fact]
        public void concert_quality_increases_by_two_less_than_ten_more_than_five_days_away()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 9 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(11, Items[0].Quality);
        }

        [Fact]
        public void concert_quality_increases_by_thre_less_than_five_days_away()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 12 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(15, Items[0].Quality);
        }

        [Fact]
        public void conjured_item_degrade_twice_as_fast()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 6, Quality = 4 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(2, Items[0].Quality);
        }

        [Fact]
        public void conjured_item_cannot_be_negative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 6, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }

    }
}
