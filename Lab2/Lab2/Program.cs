interface IInternetConnection {
     abstract bool InternetConnection();
}
abstract class Robot
{
    private string Type;
    public Robot(string type)
    {
        Type = type;
    }
    public abstract int AnnualCost();
}
class ComputerRobot : Robot, IInternetConnection
{
    private bool internetConnection;
    //public bool InternetConnection { get; set; }
    public bool InternetConnection()
    {
        return internetConnection;
    }
    public ComputerRobot(bool _InternetConnection) : base("Computer")
    {
        internetConnection = _InternetConnection;
    }
public override int AnnualCost()
    {
        if (internetConnection) { return 10000; }
        else return 5000;
        
    }
}

class MechanicalRobot : Robot
{
    public MechanicalRobot() : base("Mechanical")
    {
    }
    public override int AnnualCost()
    {
        return 20000;
    }
}
abstract class Human
{
    private string name { get; set; }
    public string Name { get { return name; } }
    private int months;
    //public int Month { get { return months; }  } 
    public int Months { get; set; }

    public Human(string _name,int _months)
        {
            name = _name;
            Months = _months;
        }
    public virtual string To_String()
    {
        return ($"My name is {Name:C} working for {Months:C}");
    }
    public abstract int Cost(int months);   
}
class Handworker : Human
{
    public  override string To_String()
    {
        return ($"My name is {Name} working for {Months} as Handworker");
    }
    public Handworker(string _name,int _months):base (_name,_months)
        {
        }
    public override int Cost(int months)
    {
        return months*3000+500;
    }
}
class OfficeWorker : Human, IInternetConnection
{
    private bool internetConnection;
    public bool InternetConnection()
    {
        return internetConnection;
    }
    public OfficeWorker(string _name, int _months,bool _InternetConnection) : base(_name, _months)
    {
        internetConnection = _InternetConnection;
    }
    public override int Cost(int months)
    {
        return months*2500;
    }
    public override string To_String()
    {
        return ($"My name is {Name} working for {Months} as OfficeWorker. Connection:{internetConnection}");
    }
}
class Factory
{
private List<Robot> _robotsList = new List<Robot>();
private List<Human> _humansList = new List<Human>();
public List<IInternetConnection> List_webconnections(List<Robot> _robotsList, List<Human> _humansList)
    {
        List<IInternetConnection> _webList = new();
        foreach (Robot robot in _robotsList)
        {
            if (robot is IInternetConnection)
                _webList.Add((IInternetConnection)robot);
            else continue;
        }
        foreach(Human human in _humansList)
        {
            if(human is IInternetConnection)
                _webList.Add((IInternetConnection)human);
            else continue;
        }
        return _webList;
    }
public Factory(List<Robot> robotsList, List<Human> humansList)
{
    _robotsList = robotsList;
    _humansList = humansList;
}
public int Totalcost_Robots()
{
    int totalcost = 0;
    foreach (Robot robot in _robotsList)
    {
        totalcost += robot.AnnualCost();
    }
    return totalcost;
}
public int Totalcost_Humans()
{
    int totalcost = 0;
    foreach (Human human in _humansList)
    {
        totalcost += human.Cost(human.Months);
    }
    return totalcost;
}
public bool WebConnection_Humans()
    {
        bool webConnection = true;
        foreach (Human human in _humansList)
        {
            if (human is OfficeWorker)
            {   
                OfficeWorker officeWorker = human as OfficeWorker;
                if (officeWorker.InternetConnection() == false)
                {
                    webConnection = false;
                }
                else {
                    continue;
                }
            }
            else
            {
                continue;
            }
        }
        return webConnection;
    }
    public bool WebConnection_Robots()
    {
        bool webConnection = true;
        foreach (Robot robot in _robotsList)
        {
            if (robot is ComputerRobot)
            {
                ComputerRobot computerRobot = robot as ComputerRobot;
                if (computerRobot.InternetConnection() == false)
                {
                    webConnection = false;
                }
                else
                {
                    continue;
                }
            }
            else
            {
                continue;
            }
        }
        return webConnection;
    }
}
class Program
{
    static void Main(string[] args)
    {
        List<Robot> _robotsList = new () {new ComputerRobot(true), new ComputerRobot(true),new MechanicalRobot()};
        List<Human> _humansList = new() { new Handworker("Krzysztof",4), new Handworker("Jared", 7), new OfficeWorker("Koks", 5,true), new OfficeWorker("Maciek", 5, true) };
        Factory Test = new Factory(_robotsList, _humansList);
        foreach(Human human in _humansList)
        {
            Console.WriteLine(human.To_String());
        }
        Console.WriteLine();
        Console.WriteLine($"Connection status for humans:{Test.WebConnection_Humans()}");
        Console.WriteLine($"Connection status for robots:{Test.WebConnection_Robots()}");
        Console.WriteLine();
        Console.WriteLine($"Total cost of humans:{Test.Totalcost_Humans()}");
        Console.WriteLine($"Total cost of robots:{Test.Totalcost_Robots()}");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"{Test.List_webconnections(_robotsList, _humansList)[1].InternetConnection()}");
    }
}