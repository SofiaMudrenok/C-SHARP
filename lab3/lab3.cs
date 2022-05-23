public class GeometicProgression{
    private double Geol;
    public double gl{get{return Geol;} set {Geol = value;}}
    private double Q;
    public double q{get{return Q;} set {Q = value;}}
    public GeometicProgression(double g, double d)
    {
        Geol =g;
        Q= d;
    }
    public GeometicProgression()
    {
        Console.Write("geol=");
        Geol = double.Parse(Console.ReadLine());
        Console.Write("q=");
        Q = double.Parse(Console.ReadLine());        
    }
    public GeometicProgression(GeometicProgression geom)
    {
        Geol =geom.gl;
        Q= geom.q;        
    }
    public double NNum(int n)
    {
        return Geol * Math.Pow(Q,(n-1));
    }
    public double NNum()
    {
        Console.Write("n=");
        int n = int.Parse(Console.ReadLine());
        return Geol * Math.Pow(Q,(n-1));
    }
    public double NSum(int n) 
    {
        return (Geol + NNum(n)* n /2);
    }
    public double NSum()
    {
        Console.Write("nsum=");
        int n = int.Parse(Console.ReadLine());
        return (Geol + NNum(n)* n /2);       
    }
}
static void Main(string[] args)
{
    GeometicProgression Geol =new GeometicProgression(2,4);
    Console.WriteLine(Geol.NNum());
    Console.WriteLine(Geol.NSum());
}