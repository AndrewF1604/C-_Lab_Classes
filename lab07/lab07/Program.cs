interface IVisitTouristAttraction
{
    string Visit();
}

class Museum
{
    int ticketPrice;

    string name;
    
    DateTime visitTime;
    TimeSpan duration ;

    public TimeSpan getduration()
    {
        return duration;
    }
    public DateTime getvisitTime()
    {
        return visitTime;
    }
    public Museum(string name, int ticketPrice, DateTime visitTime, TimeSpan duration)
    {
        this.name = name;
        this.ticketPrice = ticketPrice;
        this.visitTime = visitTime;
        this.duration = duration;
    }
    public string Visit(DateTime visitTime, TimeSpan duration)
    {
        return $"Visiting the {name} from {visitTime} to {visitTime + duration} spending {ticketPrice} pounds";
    }
    
}
class MuseumVisitCommand : IVisitTouristAttraction
{
    private Museum _museum;
    public MuseumVisitCommand(Museum museum)
    {
        _museum = museum;
    }

    public string Visit()
    {
        return _museum.Visit(_museum.getvisitTime(), _museum.getduration());
    }
}
class Park
{
    string name;
    DateTime visitTime;
    TimeSpan duration;
    public TimeSpan getduration()
    {
        return duration;
    }
    public DateTime getvisitTime()
    {
        return visitTime;
    }
    public Park(string name, DateTime visitTime, TimeSpan duration)
    {
        this.name = name;
        this.visitTime = visitTime;
        this.duration = duration;
    }
    public string Visit(DateTime visitTime, TimeSpan duration)
    {
        return $"Walking in the {name} from {visitTime} to {visitTime + duration}";
    }
}
class ParkVisitCommand : IVisitTouristAttraction
{

    private Park _park;
    public ParkVisitCommand(Park park)
    {
        _park = park;
    }
    public string Visit()
    {
        return _park.Visit(_park.getvisitTime(), _park.getduration());
    }
}
class Restaurant
{
    string name;
    string cuisine;
    bool tableReservation;
    TimeSpan duration;
    DateTime visitTime;
    int budget;
    public TimeSpan getduration()
    {
        return duration;
    }
    public DateTime getvisitTime()
    {
        return visitTime;
    }
    public int getbudget()
    {
        return budget;
    }
    public Restaurant(string name, string cuisine, bool tableReservation, TimeSpan duration, DateTime visitTime,int budget)
    {
        this.name = name;
        this.cuisine = cuisine;
        this.tableReservation = tableReservation;
        this.duration = duration;
        this.visitTime = visitTime;
        this.budget = budget;
    }
    public string Visit(TimeSpan duration, DateTime visitTime, int budget)
    {
        return $"Eating at the {name} the {cuisine} from {visitTime} to {visitTime + duration} with a budget of {budget}";
    }
}
class RestaurantVisitCommand : IVisitTouristAttraction
{
    private Restaurant _restaurant;

    public RestaurantVisitCommand(Restaurant restaurant)
    {
        _restaurant = restaurant;

    }

    public string Visit()
    {
        return _restaurant.Visit(_restaurant.getduration(), _restaurant.getvisitTime(), _restaurant.getbudget());
    }
}
class Monument
{
    string name;
    TimeSpan duration;
    DateTime visitTime;
    public TimeSpan getduration()
    {
        return duration;
    }
    public DateTime getvisitTime()
    {
        return visitTime;
    }
    public Monument(string name, TimeSpan duration, DateTime visitTime)
    {
        this.name = name;
        this.duration = duration;
        this.visitTime = visitTime;
    }

    public string Visit(DateTime visitTime, TimeSpan duration)
    {
        return $"Watching the {name} from {visitTime} to {visitTime + duration}";
    }
}
class MonumentVisitCommand : IVisitTouristAttraction
{
    private Monument _monument;
    public MonumentVisitCommand(Monument monument)
    {
        _monument = monument;
    }

    public string Visit()
    {
        return _monument.Visit(_monument.getvisitTime(), _monument.getduration());
    }
}
class TripScheduler
{
    private List<IVisitTouristAttraction> _visitCommands = new List<IVisitTouristAttraction>();

    public void AddVisitCommand(IVisitTouristAttraction visitCommand)
    {
        _visitCommands.Add(visitCommand);
    }
    public string Trip()
    {
        string temp="";
        foreach (var visitCommand in _visitCommands)
        {
            temp+=visitCommand.Visit()+'\n';
        }
        return temp;
    }
    public void Flush()
    {
        _visitCommands = new List<IVisitTouristAttraction>();
    }
}
class Program
{
    static void Main(string[] args)
    {
        TimeSpan museumVisitTime = new TimeSpan(3, 0, 0);
        DateTime museumScheduled = new DateTime(2023, 5, 10, 9, 0, 0);
        Museum museum = new Museum("National Museum",20, museumScheduled, museumVisitTime);

        TimeSpan restaurantVisitTime = new TimeSpan(2, 0, 0);
        DateTime restaurantScheduled = new DateTime(2023, 5, 10, 13, 0, 0);
        Restaurant restaurant = new Restaurant("Italiano", "Italian",true,restaurantVisitTime,restaurantScheduled,20);

        TimeSpan parkVisitTime = new TimeSpan(2, 0, 0);
        DateTime parkDuration = new DateTime(2023, 5, 10, 16, 0, 0);
        Park park = new Park("Central Park",parkDuration, parkVisitTime);

        TimeSpan monumentVisitTime = new TimeSpan(2, 0, 0);
        DateTime monumentDuration = new DateTime(2023, 5, 10, 19, 0, 0);
        Monument monument = new Monument("Statue of Liberty",monumentVisitTime , monumentDuration);

        List<IVisitTouristAttraction> commands = new List<IVisitTouristAttraction>();

        MuseumVisitCommand visitMuseum = new MuseumVisitCommand(museum);
        commands.Add(visitMuseum);

        RestaurantVisitCommand visitRestaurant = new RestaurantVisitCommand(restaurant);
        commands.Add(visitRestaurant);

        ParkVisitCommand visitPark = new ParkVisitCommand(park);
        commands.Add(visitPark);

        MonumentVisitCommand visitMonument = new MonumentVisitCommand(monument);
        commands.Add(visitMonument);

        TripScheduler tripScheduler = new TripScheduler();

        tripScheduler.AddVisitCommand(visitMuseum);
        tripScheduler.AddVisitCommand(visitRestaurant);
        tripScheduler.AddVisitCommand(visitPark);
        tripScheduler.AddVisitCommand(visitMonument);

        Console.WriteLine("First trip scenario:");

        Console.WriteLine(tripScheduler.Trip());

        tripScheduler.Flush();

        TimeSpan museumVisitTime2 = new TimeSpan(3, 23, 7);
        DateTime museumScheduled2 = new DateTime(2023, 1, 11, 9, 2, 1);
        Museum museum2 = new Museum("Ciechocinek", 1000, museumScheduled2, museumVisitTime2);

        TimeSpan restaurantVisitTime2 = new TimeSpan(1, 45, 0);
        DateTime restaurantScheduled2 = new DateTime(2023, 1, 11, 9, 3, 8);
        Restaurant restaurant2 = new Restaurant("Kabab u zbycha", "syf", false, restaurantVisitTime2, restaurantScheduled2, 10);

        MuseumVisitCommand visitMuseum2 = new MuseumVisitCommand(museum2);
        commands.Add(visitMuseum2);

        RestaurantVisitCommand visitRestaurant2 = new RestaurantVisitCommand(restaurant2);
        commands.Add(visitRestaurant2);

        tripScheduler.AddVisitCommand(visitRestaurant2);
        tripScheduler.AddVisitCommand(visitPark);
        tripScheduler.AddVisitCommand(visitMonument);
        tripScheduler.AddVisitCommand(visitMuseum2);

        Console.WriteLine("\nSecond trip scenario:");
        Console.WriteLine(tripScheduler.Trip());

        tripScheduler.Flush();

        TimeSpan museumVisitTime3 = new TimeSpan(6, 6, 6);
        DateTime museumScheduled3 = new DateTime(2069, 6, 23, 6, 6, 6);
        Museum museum3 = new Museum("Hurtownia Jaboli", 1000, museumScheduled3, museumVisitTime3);

        MuseumVisitCommand visitMuseum3 = new MuseumVisitCommand(museum3);
        commands.Add(visitMuseum3);

        TimeSpan restaurantVisitTime3 = new TimeSpan(4, 4, 4);
        DateTime restaurantScheduled3 = new DateTime(2029, 5, 6, 7, 2, 2);
        Restaurant restaurant3 = new Restaurant("La cucaracha", "Bombastic", false, restaurantVisitTime3, restaurantScheduled3, 20);

        RestaurantVisitCommand visitRestaurant3 = new RestaurantVisitCommand(restaurant3);
        commands.Add(visitRestaurant3);

        TimeSpan parkVisitTime2 = new TimeSpan(8, 8, 8);
        DateTime parkDuration2 = new DateTime(2025, 5, 10, 16, 0, 0);
        Park park2 = new Park("Park Strzelecki", parkDuration2, parkVisitTime2);

        ParkVisitCommand visitPark2 = new ParkVisitCommand(park2);
        commands.Add(visitPark2);

        tripScheduler.AddVisitCommand(visitPark2);
        tripScheduler.AddVisitCommand(visitRestaurant3);
        tripScheduler.AddVisitCommand(visitMuseum3);      
        tripScheduler.AddVisitCommand(visitMonument);
        
        Console.WriteLine("\nThird trip scenario:");
        Console.WriteLine(tripScheduler.Trip());

        Console.WriteLine("\nPossible commands");
        foreach (IVisitTouristAttraction possible in commands)
        {
            Console.WriteLine(possible.Visit());
        }
    }
}
