namespace GildedRoseKata;

public static class ItemHelper
{

    public static void CheckAndDecreaseQuality(Item item)
    {
        if (NotMinQuality(item.Quality))
        {
            ReduceQuality(item);
        }
    }

    private static bool NotMinQuality(int checkNumber)
    {
        return checkNumber > 0;
    }

    public static void ConcertQualityRules(Item item)
    {
        if (IsTicket(item.Name))
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

    // normal items are where quality decreases over item
    public static bool NormalItem(string itemName)
    {
        return IsBrie(itemName) == false && IsTicket(itemName) == false;
    }

    public static bool NotLegendaryItem(string itemName)
    {
        return itemName != "Sulfuras, Hand of Ragnaros";
    }

    public static void CheckAndIncreaseQuality(Item item)
    {
        if (NotMaxQuality(item.Quality))
        {
            IncreaseQuality(item);
        }
    }

    private static bool NotMaxQuality(int checkNumber)
    {
        return checkNumber < 50;
    }

    public static bool SellByPassed(Item item)
    {
        return item.SellIn < 0;
    }

    public static void ReduceSellInTime(Item item)
    {
        item.SellIn -= 1;
    }

    private static void ReduceQuality(Item item)
    {
        item.Quality -= 1;
    }

    private static void IncreaseQuality(Item item)
    {
        item.Quality += 1;
    }

    public static bool IsBrie(string itemName)
    {
        return itemName == "Aged Brie";
    }

    public static bool IsTicket(string itemName)
    {
        return itemName == "Backstage passes to a TAFKAL80ETC concert";
    }

    public static bool IsConjured(string itemName)
    {
        return itemName == "Conjured Mana Cake";
    }
}