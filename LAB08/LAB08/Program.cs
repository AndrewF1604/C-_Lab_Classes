public interface IComplex
{
    double Module { get; }
    double Phase { get; }
}
public class ComplexNumber : IComplex
{
    public double Real { get; }
    public double Imaginary { get; }
    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }
    public double Module
    {
        get { return Math.Sqrt(Real * Real + Imaginary * Imaginary); }
    }
    public double Phase
    {
        get { return Math.Atan2(Imaginary, Real); }
    }

    public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
    {
        return new ComplexNumber(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
    }
    public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
    {
        return new ComplexNumber(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
    }
    public string Display()
    {
        return $"{this.Real} {this.Imaginary}i";
    }
}
public class ComplexComposite : IComplex
{
    private readonly List<ComplexNumber> _complexNumbers;
    public ComplexComposite()
    {
        _complexNumbers = new List<ComplexNumber>();
    }
    public double Module
    {
        get
        {
            ComplexNumber temp = new ComplexNumber(0,0);
            foreach (ComplexNumber c in _complexNumbers)
            {
                temp += c;
            }
            return Math.Sqrt(temp.Real* temp.Real+temp.Imaginary* temp.Imaginary);
        }
    }
    public double Phase
    {
        get
        {
            ComplexNumber temp = new ComplexNumber(0, 0);
            foreach (ComplexNumber c in _complexNumbers)
            {
                temp += c;
            }
            return Math.Atan2(temp.Imaginary, temp.Real);
        }
    }
    public string Display()
    {
        ComplexNumber temp = new ComplexNumber(0, 0);
        foreach (ComplexNumber c in _complexNumbers)
        {
            temp += c;
        }
        return $"{temp.Real} {temp.Imaginary}i";
    }
    public void AddComplexNumber(ComplexNumber c)
    {
        _complexNumbers.Add(c);
    }
    public void RemoveComplexNumber(ComplexNumber c)
    {
        _complexNumbers.Remove(c);
    }
    public static ComplexComposite operator +(ComplexComposite cc, ComplexNumber c)
    {
        cc.AddComplexNumber(c);
        return cc;
    }
    public static ComplexComposite operator -(ComplexComposite cc, ComplexNumber c)
    {
        cc.RemoveComplexNumber(c);
        return cc;
    }
}
class Program
{
    static void Main(string[] args)
    {
        ComplexNumber z1 = new ComplexNumber(1, 2);
        ComplexNumber z2 = new ComplexNumber(-3, 4);
        ComplexNumber z3 = z1 + z2;
        ComplexNumber z4 = new ComplexNumber(5, 6);

        ComplexComposite sum = new ComplexComposite();

        sum.AddComplexNumber(z1);
        sum.AddComplexNumber(z2);
        sum.AddComplexNumber(z4);

        Console.WriteLine(z3.Display());
        Console.WriteLine(z3.Module);
        Console.WriteLine(z3.Phase);
        Console.WriteLine();
        Console.WriteLine(sum.Display());
        Console.WriteLine($"Module: {sum.Module}");
        Console.WriteLine($"Phase: {sum.Phase}");
    }
}