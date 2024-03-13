abstract class IceCream
{
    public int Price { get; set; }
    public string MainFlavor { get; set; }
    public IceCream(int price, string mainFlavor)
    {
        Price = price;
        MainFlavor = mainFlavor;
    }
    public abstract string PrintInfo();
}
class RegularIceCream : IceCream
{
    public bool Waffle { get; set; }
    public string Topping { get; set; }
    public bool ChocolateSprinkles { get; set; }
    public RegularIceCream(int price, string mainFlavor, bool waffle, string topping, bool chocolateSprinkles) : base(price, mainFlavor)
    {
        Waffle = waffle;
        Topping = topping;
        ChocolateSprinkles = chocolateSprinkles;
    }
    public override string PrintInfo()
    {
        return $"Regular Ice Cream, Flavor: {MainFlavor}, Price: {Price}, Waffle: {Waffle}, Topping: {Topping}, Chocolate Sprinkles: {ChocolateSprinkles}";
    }
}
class FruitBasedIceCream : IceCream
{
    public bool Waffle { get; set; }
    public string Topping { get; set; }
    public FruitBasedIceCream(int price, string mainFlavor, bool waffle, string topping) : base(price, mainFlavor)
    {
        Waffle = waffle;
        Topping = topping;
    }
    public override string PrintInfo()
    {
        return $"FruitBasedIceCream, Flavor: {MainFlavor}, Price: {Price}, Waffle: {Waffle}, Topping: {Topping}";
    }
}
class Sorbet : IceCream
{
    public Sorbet(int price, string mainFlavor) : base(price, mainFlavor)
    {
    }
    public override string PrintInfo()
    {
        return $"Sorbet, Flavor:{MainFlavor}, Price: {Price}";
    }
}
class Gelato : IceCream
{
    public bool ChocolateSprinkles { get; set; }
    public Gelato(int price, string mainFlavor, bool chocolateSprinkles) : base(price, mainFlavor)
    {
        ChocolateSprinkles = chocolateSprinkles;
    }
    public override string PrintInfo()
    {
        return $"Gelato, Flavor:{MainFlavor}, Price: {Price},Chocolate Sprinkles: {ChocolateSprinkles}";
    }
}
enum WeekDay
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}
abstract class IceCreamFactory
{
    public abstract IceCream DailySpecial(WeekDay day); 
}
class GoodLood : IceCreamFactory
{
    public override IceCream DailySpecial(WeekDay day)
    {
        switch (day)
        {
            case WeekDay.Monday:
                return new RegularIceCream(11, "GoodLoodFlavor1", false, "Toppings11", true);
            case WeekDay.Tuesday:
                return new FruitBasedIceCream(12, "GoodLoodFlavor2", false, "Toppings22");
            case WeekDay.Wednesday:
                return new Sorbet(13, "GoodLoodFlavor3");
            case WeekDay.Thursday:
                return new Gelato(14, "GoodLoodFlavor4", true);
            case WeekDay.Friday:
                return new RegularIceCream(15, "GoodLoodFlavor5", false, "Toppings55", true);
            case WeekDay.Saturday:
                return new FruitBasedIceCream(16, "GoodLoodFlavor6", false, "Toppings66");
            case WeekDay.Sunday:
                return new Gelato(17, "GoodLoodFlavor7", true);
            default:
                throw new ArgumentException("Invalid day of the week");
        }
    }
}
class BudgetIceCreamFactory : IceCreamFactory
{
    public override IceCream DailySpecial(WeekDay day)
    {
        switch (day)
        {
            case WeekDay.Monday:
                return new RegularIceCream(1, "BudgetFlavor1", true, "Toppings1", false);
            case WeekDay.Tuesday:
                return new FruitBasedIceCream(2, "BudgetFlavor2", true, "Toppings2");
            case WeekDay.Wednesday:
                return new Sorbet(3, "BudgetFlavor3");
            case WeekDay.Thursday:
                return new Gelato(4, "BudgetFlavor4", false);
            case WeekDay.Friday:
                return new RegularIceCream(5, "BudgetFlavor5", true, "Toppings6", false);
            case WeekDay.Saturday:
                return new FruitBasedIceCream(6, "BudgetFlavor6", true, "Toppings7");
            case WeekDay.Sunday:
                return new Gelato(7, "BudgetFlavor7", false);
            default:
                throw new ArgumentException("Invalid day of the week");
        }
    }
}
class IceCreamShop
{
    IceCreamFactory iceCreamFactory_m;
    public IceCreamShop(IceCreamFactory test)
    {
        iceCreamFactory_m = test;
    }
    public void ChangeFactory(IceCreamFactory test)
    {
        iceCreamFactory_m = test;
    }
    public string AdvertiseDailySpecial(WeekDay day)
    {
       return $"{day}'s daily special is {iceCreamFactory_m.DailySpecial(day).PrintInfo()}";
    }
}
class Program
{
    static void Main(string[] args)
    {
        BudgetIceCreamFactory budgetIceCreamFactory = new BudgetIceCreamFactory();
        GoodLood goodLood = new GoodLood();

        IceCreamShop iceCreamShop = new IceCreamShop(goodLood);
        Console.WriteLine(iceCreamShop.AdvertiseDailySpecial(WeekDay.Monday));
        Console.WriteLine(iceCreamShop.AdvertiseDailySpecial(WeekDay.Tuesday));
        Console.WriteLine(iceCreamShop.AdvertiseDailySpecial(WeekDay.Wednesday));
        iceCreamShop.ChangeFactory(budgetIceCreamFactory);
        Console.WriteLine();
        Console.WriteLine(iceCreamShop.AdvertiseDailySpecial(WeekDay.Thursday));
        Console.WriteLine(iceCreamShop.AdvertiseDailySpecial(WeekDay.Friday));
    }
}