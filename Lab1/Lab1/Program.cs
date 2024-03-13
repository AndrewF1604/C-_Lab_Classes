class Restaurant
{
    private string[] menu { get; set; }
    private string name { get; set; }
    private string address { get; set; }
    private int rating { get; set; }
    public Restaurant(string[] _menu, string _name, string _address, int _rating)
    {
        
        menu = _menu;
        name = _name;
        address = _address;
        rating = _rating;
    }

    public string Open()
    {
        return($"{name} is now open!");
    }
    public string Close()
    {
        return($"{name} is now closed.");
    }
    public virtual string CalculateBill(int numPeople, double pricePerPerson)
    {
        double bill = numPeople * pricePerPerson;
        return ($"Your bill is {bill:C}.");
    }
}
class FastFoodRestaurant : Restaurant
{
    private int orderNumber { get; set; }
    private bool driveThru { get; set; }

    public FastFoodRestaurant(string[] _menu ,string _name, string _address, int _rating, int _orderNumber, bool _driveThru) : base(_menu,_name, _address, _rating)
    {
        orderNumber = _orderNumber;
        driveThru = _driveThru;
    }

    public string TakeOrder(int _orderNumber)
    {
        orderNumber = _orderNumber;
        return ($"Order {orderNumber} has been taken.");
    }
    public string ServeOrder()
    {
        return($"Order {orderNumber} is ready. Please pick it up at the counter.");
    }
    public override string CalculateBill(int numPeople, double pricePerPerson)
    {
        double bill = numPeople * pricePerPerson;
        return($"Your fast food bill is {bill:C}.");
    }
}
class BurgerKing : FastFoodRestaurant
{
    private bool freeRefill { get; set; }
    private bool coupon { get; set; }

    public BurgerKing(string[] _menu, string _name, string _address, int _rating, int _orderNumber, bool _driveThru, bool _freeRefill,bool _coupon) : base(_menu, _name, _address, _rating, _orderNumber, _driveThru)
    {
        freeRefill = _freeRefill;
        coupon = _coupon;
    }

    public double AddCoupon(bool Coupon, double totalPrice)
    {
        if (Coupon)
        {
            double discountedPrice = totalPrice * 0.9;
            return discountedPrice;
        }
        else
        {
            return totalPrice;
        }
    }
}
    class ItalianRestaurant : Restaurant
{
    private bool reservations { get; set; }
    private bool wineList { get; set; }
    public ItalianRestaurant(string[] _menu, string _name, string _address, int _rating, bool _reservations, bool _wineList) : base(_menu, _name, _address, _rating)
    {
        reservations = _reservations;
        wineList = _wineList;
    }

    public static string MakeReservation()
    {
        return("Your reservation has been made.");
    }
    public override string CalculateBill(int numPeople, double pricePerPerson)
    {
        double bill = numPeople * pricePerPerson;
        double tip = bill * 0.15;
        return($"Your Italian restaurant bill is {bill:C}. Don't forget to leave a tip of {tip:C}!");
    }
}
class PizzaRestaurant : ItalianRestaurant
{

    private string[] toppings { get; set; }
    private bool delivery { get; set; }
    private bool takeout { get; set; }
    public PizzaRestaurant(string[] _menu, string _name, string _address, int _rating, bool _reservations, bool _wineList, string[] _toppings, bool _delivery,bool _takeout) : base(_menu, _name, _address, _rating, _reservations, _wineList)
    {
        toppings = _toppings;
        delivery = _delivery;
        takeout = _takeout;
    }

    public string OrderPizza(string[] toppings)
    {
        return($"One {string.Join(" and ", toppings)} pizza coming right up!");
    }
    public string ScheduleDelivery()
    {
        return("Your pizza will be delivered in 30 minutes or less.");
    }

    public override string CalculateBill(int numPeople, double pricePerPerson)
    {
        double bill = numPeople * pricePerPerson;
        double tip = bill * 0.20;
        return($"Your pizza restaurant bill is {bill:C}. Don't forget to leave a tip of {tip:C}!");
    }
}
class Program
{
    static void Main(string[] args)
    {
        string[] bkMenu = { "Whopper", "Chicken Fries", "Big Mac" };
        BurgerKing bk = new BurgerKing(bkMenu, "Burger King", "Czarnowiejska 69", 4, 1, true, true, true);
        Console.WriteLine(bk.Open());
        Console.WriteLine(bk.TakeOrder(1));
        Console.WriteLine(bk.ServeOrder());
        double totalPrice = 15.0;
        Console.WriteLine($"Total price before coupon: {totalPrice:C}");       //BURGER KING
        double discountedPrice = bk.AddCoupon(true, totalPrice);
        Console.WriteLine($"Total price after coupon: {discountedPrice:C}");
        Console.WriteLine(bk.Close());

        Console.WriteLine();


        string[] italianMenu = { "Spaghetti Carbonara", "Margherita Pizza", "Tiramisu" };
        ItalianRestaurant italian = new ItalianRestaurant(italianMenu, "Parmigiano Rigiano", "Lea 666", 5, true, true);
        Console.WriteLine(italian.Open());
        Console.WriteLine(ItalianRestaurant.MakeReservation());                     //ITALIAN
        int numPeople = 4;
        double pricePerPerson = 20.0;
        Console.WriteLine(italian.CalculateBill(numPeople, pricePerPerson));
        Console.WriteLine(italian.Close());

        Console.WriteLine();

        string[] pizzaToppings = { "pepperoni", "mushrooms", "onions" };
        PizzaRestaurant pizza = new PizzaRestaurant(italianMenu, "Dominium", "Nowy kleparz 42", 4, false, true, pizzaToppings, true, true);
        Console.WriteLine(pizza.Open());
        Console.WriteLine(pizza.OrderPizza(pizzaToppings));              //PIZZA
        Console.WriteLine(pizza.ScheduleDelivery());
        Console.WriteLine(pizza.CalculateBill(numPeople, pricePerPerson));
        Console.WriteLine(pizza.Close());
    }

}
